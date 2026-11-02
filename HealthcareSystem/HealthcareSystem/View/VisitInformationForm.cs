using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.Globalization;

namespace HealthcareSystem.View
{
    /// <summary>
    /// Shows the information for one visit and lets a nurse enter or edit the routine checkup (vitals and symptoms) until the visit is finalized.
    /// </summary>
    public partial class VisitInformationForm : Form
    {
        private readonly Visit visit;
        private readonly Patient patient;
        private readonly VisitController visitController;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisitInformationForm"/> class.
        /// </summary>
        /// <param name="visit">The visit to show.</param>
        /// <param name="patient">The patient the visit belongs to.</param>
        /// <param name="visitController">The visit controller.</param>
        public VisitInformationForm(Visit visit, Patient patient, VisitController visitController)
        {
            this.InitializeComponent();

            this.visit = visit;
            this.patient = patient;
            this.visitController = visitController;
            this.loggedInUserControl1.RefreshUser();

            this.patientLabel.Text = $"{this.patient.FullName}, born {this.patient.DateOfBirth:MM/dd/yyyy}, Dr. {this.visit.DoctorName}";
            this.visitLabel.Text = $"Visit {this.visit.VisitId} on {this.visit.VisitDateTime:MM/dd/yyyy h:mm tt}" +
                                   (string.IsNullOrWhiteSpace(this.visit.Reason) ? string.Empty : $" - {this.visit.Reason}");

            this.showVisit();

            if (this.visit.IsFinalized)
            {
                this.setReadOnly();
            }
        }

        private void showVisit()
        {
            this.heightTextBox.Text = this.visit.Height?.ToString("0.##", CultureInfo.CurrentCulture) ?? string.Empty;
            this.weightTextBox.Text = this.visit.Weight?.ToString("0.##", CultureInfo.CurrentCulture) ?? string.Empty;
            this.systolicTextBox.Text = this.visit.Systolic?.ToString(CultureInfo.CurrentCulture) ?? string.Empty;
            this.diastolicTextBox.Text = this.visit.Diastolic?.ToString(CultureInfo.CurrentCulture) ?? string.Empty;
            this.temperatureTextBox.Text = this.visit.BodyTemperature?.ToString("0.#", CultureInfo.CurrentCulture) ?? string.Empty;
            this.pulseTextBox.Text = this.visit.Pulse?.ToString(CultureInfo.CurrentCulture) ?? string.Empty;
            this.symptomsTextBox.Text = this.visit.Symptoms ?? string.Empty;

            this.nurseLabel.Text = $"Recorded by: {(string.IsNullOrWhiteSpace(this.visit.NurseName) ? "not yet recorded" : this.visit.NurseName)}";
            this.checkedLabel.Text = $"Checked: {(this.visit.CheckDateTime.HasValue ? this.visit.CheckDateTime.Value.ToString("MM/dd/yyyy h:mm tt") : "not yet recorded")}";
            this.finalizedLabel.Text = $"Finalized: {(this.visit.IsFinalized ? "Yes" : "No")}";

            this.validateFields();
        }

        private void setReadOnly()
        {
            this.heightTextBox.ReadOnly = true;
            this.weightTextBox.ReadOnly = true;
            this.systolicTextBox.ReadOnly = true;
            this.diastolicTextBox.ReadOnly = true;
            this.temperatureTextBox.ReadOnly = true;
            this.pulseTextBox.ReadOnly = true;
            this.symptomsTextBox.ReadOnly = true;
            this.saveButton.Enabled = false;
        }

        private void field_TextChanged(object? sender, EventArgs e)
        {
            this.validateFields();
        }

        /// <summary>
        /// Checks every field for a missing or non-numeric value, shows the problem next to it, and enables Save only when every field is valid.
        /// </summary>
        private void validateFields()
        {
            var errors = new[]
            {
                this.showFieldError(this.heightErrorLabel, validateDecimal(this.heightTextBox.Text)),
                this.showFieldError(this.weightErrorLabel, validateDecimal(this.weightTextBox.Text)),
                this.showFieldError(this.systolicErrorLabel, validateInteger(this.systolicTextBox.Text)),
                this.showFieldError(this.diastolicErrorLabel, validateInteger(this.diastolicTextBox.Text)),
                this.showFieldError(this.temperatureErrorLabel, validateDecimal(this.temperatureTextBox.Text)),
                this.showFieldError(this.pulseErrorLabel, validateInteger(this.pulseTextBox.Text)),
                this.showFieldError(this.symptomsErrorLabel, string.IsNullOrWhiteSpace(this.symptomsTextBox.Text) ? "Required." : null)
            };

            this.saveButton.Enabled = !this.visit.IsFinalized && errors.All(error => error == null);
        }

        private string? showFieldError(Label errorLabel, string? error)
        {
            errorLabel.Text = error ?? string.Empty;

            return error;
        }

        private static string? validateDecimal(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "Required.";
            }

            return decimal.TryParse(text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out _) ? null : "Enter a valid number.";
        }

        private static string? validateInteger(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "Required.";
            }

            return int.TryParse(text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out _) ? null : "Enter a whole number.";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var edited = new Visit
            {
                VisitId = this.visit.VisitId,
                VisitDateTime = this.visit.VisitDateTime,
                AppointmentId = this.visit.AppointmentId,
                PatientId = this.visit.PatientId,
                DoctorName = this.visit.DoctorName,
                Reason = this.visit.Reason,
                Height = decimal.Parse(this.heightTextBox.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture),
                Weight = decimal.Parse(this.weightTextBox.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture),
                Systolic = int.Parse(this.systolicTextBox.Text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture),
                Diastolic = int.Parse(this.diastolicTextBox.Text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture),
                BodyTemperature = decimal.Parse(this.temperatureTextBox.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture),
                Pulse = int.Parse(this.pulseTextBox.Text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture),
                Symptoms = this.symptomsTextBox.Text,
                CheckDateTime = this.visit.CheckDateTime,
                IsFinalized = this.visit.IsFinalized
            };

            try
            {
                this.visitController.SaveVisit(edited);

                this.visit.Height = edited.Height;
                this.visit.Weight = edited.Weight;
                this.visit.Systolic = edited.Systolic;
                this.visit.Diastolic = edited.Diastolic;
                this.visit.BodyTemperature = edited.BodyTemperature;
                this.visit.Pulse = edited.Pulse;
                this.visit.Symptoms = edited.Symptoms;
                this.visit.CheckDateTime = edited.CheckDateTime;
                this.visit.NurseId = edited.NurseId;
                this.visit.NurseName = edited.NurseName;
                this.showVisit();

                MessageBox.Show("Visit information has been saved.", "Visit Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                this.showError(ex.Message);
            }
            catch (MySqlException)
            {
                this.showError("Unable to save the visit in the database.");
            }
        }

        private void decimalTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (sender is not TextBox textBox || char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                return;
            }

            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            var alreadyHasSeparator = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength).Contains(separator);

            e.Handled = e.KeyChar.ToString() != separator || alreadyHasSeparator;
        }

        private void integerTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void orderTestsButton_Click(object sender, EventArgs e)
        {
            var orderTestController = new OrderTestController(new Model.DAL.OrderTestDal());
            var orderTestForm = new OrderTestForm(orderTestController, this.visit.VisitId);
            orderTestForm.ShowDialog();
        }

        private void viewEditTestsButton_Click(object sender, EventArgs e)
        {
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showError(string message)
        {
            MessageBox.Show(message, "Unable to Save Visit", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}