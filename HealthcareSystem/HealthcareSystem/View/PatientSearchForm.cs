using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;
using Mysqlx;

namespace HealthcareSystem.View
{
    /// <summary>
    /// Lets a nurse search for patients by full name, date of birth, or both, and select one to work with.
    /// </summary>
    public partial class PatientSearchForm : Form
    {
        private readonly PatientController patientController;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientSearchForm"/> class.
        /// </summary>
        /// <param name="patientController">The patient controller.</param>
        public PatientSearchForm(PatientController patientController)
        {
            InitializeComponent();

            this.patientController = patientController;
            this.loggedInUserControl1.RefreshUser();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.clearResults();

            var firstName = this.firstNameTextBox.Text;
            var lastName = this.lastNameTextBox.Text;
            DateTime? dateOfBirth = this.dateOfBirthPicker.Checked ? this.dateOfBirthPicker.Value.Date : null;

            try
            {
                var patients = this.patientController.SearchPatients(firstName, lastName, dateOfBirth);
                this.resultsGridView.DataSource = patients;
                this.configureColumns();

                this.resultCountLabel.Text = patients.Count switch
                {
                    0 => "No patients found.",
                    1 => "1 patient found.",
                    _ => $"{patients.Count} patients found."
                };
            }
            catch (ArgumentException ex)
            {
                this.showError(ex.Message);
            }
            catch (MySqlException)
            {
                this.showError("Unable to connect to the database.");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.firstNameTextBox.Clear();
            this.lastNameTextBox.Clear();
            this.dateOfBirthPicker.Checked = false;
            this.clearResults();
            this.firstNameTextBox.Focus();
        }

        private void resultsGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.selectButton.Enabled = this.resultsGridView.CurrentRow?.DataBoundItem is Patient;
        }

        private void resultsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.openSelectedPatient();
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            this.openSelectedPatient();
        }

        private void clearResults()
        {
            this.resultsGridView.DataSource = null;
            this.selectButton.Enabled = false;
            this.errorLabel.Visible = false;
            this.resultCountLabel.Text = string.Empty;
        }

        private void configureColumns()
        {
            this.resultsGridView.Columns[nameof(Patient.PersonId)]!.Visible = false;
            this.resultsGridView.Columns[nameof(Patient.FullName)]!.Visible = false;

            this.resultsGridView.Columns[nameof(Patient.PatientId)]!.HeaderText = "Patient ID";
            this.resultsGridView.Columns[nameof(Patient.FirstName)]!.HeaderText = "First Name";
            this.resultsGridView.Columns[nameof(Patient.LastName)]!.HeaderText = "Last Name";
            this.resultsGridView.Columns[nameof(Patient.DateOfBirth)]!.HeaderText = "Date of Birth";
            this.resultsGridView.Columns[nameof(Patient.StreetAddress)]!.HeaderText = "Street Address";
            this.resultsGridView.Columns[nameof(Patient.ZipCode)]!.HeaderText = "Zip Code";
            this.resultsGridView.Columns[nameof(Patient.PhoneNumber)]!.HeaderText = "Phone";
            this.resultsGridView.Columns[nameof(Patient.IsActive)]!.HeaderText = "Active";

            this.resultsGridView.Columns[nameof(Patient.DateOfBirth)]!.DefaultCellStyle.Format = "MM/dd/yyyy";

        }

        private void showError(string message)
        {
            this.errorLabel.Text = message;
            this.errorLabel.Visible = true;
        }

        private void openSelectedPatient()
        {
            if (this.resultsGridView.CurrentRow?.DataBoundItem is not Patient selectedPatient)
            {
                return;
            }

            using var patientActionsForm = new PatientActionsForm(selectedPatient);
            patientActionsForm.ShowDialog();

            this.searchButton.PerformClick();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
