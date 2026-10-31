using System.Globalization;
using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

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
                this.showError("This visit is finalized and can no longer be edited.");
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.errorLabel.Visible = false;

            if (!tryParseDecimal(this.heightTextBox.Text, out var height))
            {
                this.showError("Height (in) must be a number.");
                return;
            }

            if (!tryParseDecimal(this.weightTextBox.Text, out var weight))
            {
                this.showError("Weight (lb) must be a number.");
                return;
            }

            if (!tryParseInt(this.systolicTextBox.Text, out var systolic))
            {
                this.showError("Systolic blood pressure (mmHg) must be a whole number.");
                return;
            }

            if (!tryParseInt(this.diastolicTextBox.Text, out var diastolic))
            {
                this.showError("Diastolic blood pressure (mmHg) must be a whole number.");
                return;
            }

            if (!tryParseDecimal(this.temperatureTextBox.Text, out var temperature))
            {
                this.showError("Body temperature (°F) must be a number.");
                return;
            }

            if (!tryParseInt(this.pulseTextBox.Text, out var pulse))
            {
                this.showError("Pulse (bpm) must be a whole number.");
                return;
            }

            var edited = new Visit
            {
                VisitId = this.visit.VisitId,
                VisitDateTime = this.visit.VisitDateTime,
                AppointmentId = this.visit.AppointmentId,
                PatientId = this.visit.PatientId,
                DoctorName = this.visit.DoctorName,
                Reason = this.visit.Reason,
                Height = height,
                Weight = weight,
                Systolic = systolic,
                Diastolic = diastolic,
                BodyTemperature = temperature,
                Pulse = pulse,
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

        private void orderTestsButton_Click(object sender, EventArgs e)
        {
        }

        private void viewEditTestsButton_Click(object sender, EventArgs e)
        {
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static bool tryParseDecimal(string text, out decimal? value)
        {
            value = null;

            if (string.IsNullOrWhiteSpace(text))
            {
                return true;
            }

            if (!decimal.TryParse(text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var parsed))
            {
                return false;
            }

            value = parsed;
            return true;
        }

        private static bool tryParseInt(string text, out int? value)
        {
            value = null;

            if (string.IsNullOrWhiteSpace(text))
            {
                return true;
            }

            if (!int.TryParse(text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var parsed))
            {
                return false;
            }

            value = parsed;
            return true;
        }

        private void showError(string message)
        {
            this.errorLabel.Text = message;
            this.errorLabel.Visible = true;
        }
    }
}
