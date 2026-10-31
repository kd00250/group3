using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;
using Mysqlx;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace HealthcareSystem.View
{
    /// <summary>
    /// Lets a nurse register a new patient.
    /// </summary>
    public partial class PatientRegistrationForm : Form
    {
        private readonly PatientController patientController;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientRegistrationForm"/> class.
        /// </summary>
        /// <param name="patientController">The patient controller.</param>
        public PatientRegistrationForm(PatientController patientController)
        {
            this.InitializeComponent();

            this.dateOfBirthPicker.MaxDate = DateTime.Today;
            this.patientController = patientController;
            this.loggedInUserControl1.RefreshUser();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (!this.validateFields())
            {
                return;
            }

            var patient = new Patient
            {
                FirstName = this.firstNameTextBox.Text,
                LastName = this.lastNameTextBox.Text,
                Gender = this.genderComboBox.Text,
                DateOfBirth = this.dateOfBirthPicker.Value.Date,
                StreetAddress = this.streetTextBox.Text,
                City = this.cityTextBox.Text,
                State = this.stateComboBox.Text,
                ZipCode = this.zipTextBox.Text,
                PhoneNumber = this.phoneTextBox.Text,
                IsActive = this.isActiveCheckbox.Checked
            };

            try
            {
                var patientId = this.patientController.RegisterPatient(patient);
                MessageBox.Show($"Patient registered. Patient ID: {patientId}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.clearForm();
            }
            catch (ArgumentException ex)
            {
                this.showError(ex.Message);
            }
            catch (MySqlException)
            {
                this.showError("Unable to save to the database.");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearForm()
        {
            this.firstNameTextBox.Clear();
            this.lastNameTextBox.Clear();
            this.genderComboBox.SelectedIndex = -1;
            this.dateOfBirthPicker.Value = DateTime.Today;
            this.streetTextBox.Clear();
            this.cityTextBox.Clear();
            this.stateComboBox.SelectedIndex = -1;
            this.zipTextBox.Clear();
            this.phoneTextBox.Clear();
            this.isActiveCheckbox.Checked = false;
            this.clearValidationErrors();
            this.firstNameTextBox.Focus();
        }

        private bool validateFields()
        {
            this.clearValidationErrors();

            bool isValid = true;

            if (!this.firstNameValidation())
            {
                isValid = false;
            }

            if (!this.lastNameValidation())
            {
                isValid = false;
            }

            if (!this.genderValidation())
            {
                isValid = false;
            }

            if (!this.streetAddressValidation())
            {
                isValid = false;
            }

            if (!this.cityValidation())
            {
                isValid = false;
            }

            if (!this.zipCodeValidation())
            {
                isValid = false;
            }

            if (!this.phoneNumberValidation())
            {
                isValid = false;
            }

            return isValid;
        }

        private bool genderValidation()
        {
            if (string.IsNullOrWhiteSpace(this.genderComboBox.Text))
            {
                this.showFieldError(this.genderErrorLabel, "Please select a gender.");

                return false;
            }

            return true;
        }

        private bool lastNameValidation()
        {
            var lastName = this.lastNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(lastName))
            {
                this.showFieldError(this.lastNameErrorLabel, "Last name is required.");

                return false;
            }

            if (!Regex.IsMatch(lastName, @"^[a-zA-Z ]+$"))
            {
                this.showFieldError(this.lastNameErrorLabel, "Last name can only contain letters.");

                return false;
            }

            return true;
        }

        private bool firstNameValidation()
        {
            var firstName = this.firstNameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(firstName))
            {
                this.showFieldError(this.firstNameErrorLabel, "First name is required.");

                return false;
            }

            if (!Regex.IsMatch(firstName, @"^[a-zA-Z ]+$"))
            {
                this.showFieldError(this.firstNameErrorLabel, "First name can only contain letters.");

                return false;
            }

            return true;
        }

        private bool streetAddressValidation()
        {
            var streetAddress = this.streetTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(streetAddress))
            {
                return true;
            }

            if (!Regex.IsMatch(streetAddress, @"^[\p{L}\p{M}0-9 -]+$"))
            {
                this.showFieldError(this.streetAddressErrorLabel, "Street address can only contain letters, numbers, spaces, and hyphens.");

                return false;
            }

            return true;
        }

        private bool cityValidation()
        {
            var city = this.cityTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(city))
            {
                return true;
            }

            if (!Regex.IsMatch(city, @"^[\p{L}\p{M} -]+$"))
            {
                this.showFieldError(this.cityErrorLabel, "City can only contain letters, spaces, and hyphens.");

                return false;
            }

            return true;
        }

        private bool zipCodeValidation()
        {
            var zipCode = this.zipTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(zipCode))
            {
                return true;
            }

            if (!Regex.IsMatch(zipCode, @"^[0-9-]+$"))
            {
                this.showFieldError(this.zipCodeErrorLabel, "ZIP code can only contain numbers and a hyphen.");

                return false;
            }

            if (!Regex.IsMatch(zipCode, @"^[0-9]{5}(-[0-9]{4})?$"))
            {
                this.showFieldError(this.zipCodeErrorLabel, "ZIP code must be in the format XXXXX or XXXXX-XXXX.");

                return false;
            }

            return true;
        }

        private bool phoneNumberValidation()
        {
            var phoneNumber = this.phoneTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return true;
            }

            if (!Regex.IsMatch(phoneNumber, @"^[0-9-]+$"))
            {
                this.showFieldError(this.phoneNumberErrorLabel, "Phone number can only contain numbers and hyphens.");

                return false;
            }

            if (!Regex.IsMatch(phoneNumber, @"^[0-9]{3}-[0-9]{3}-[0-9]{4}$"))
            {
                this.showFieldError(this.phoneNumberErrorLabel, "Phone number must be in the format XXX-XXX-XXXX.");

                return false;
            }

            return true;
        }

        private void clearValidationErrors()
        {
            this.firstNameErrorLabel.Visible = false;
            this.lastNameErrorLabel.Visible = false;
            this.genderErrorLabel.Visible = false;
            this.streetAddressErrorLabel.Visible = false;
            this.cityErrorLabel.Visible = false;
            this.zipCodeErrorLabel.Visible = false;
            this.phoneNumberErrorLabel.Visible = false;
            this.errorLabel.Visible = false;
        }

        private void showFieldError(Label errorLabel, string message)
        {
            errorLabel.Text = message;
            errorLabel.Visible = true;
        }

        private void showError(string message)
        {
            this.errorLabel.Text = message;
            this.errorLabel.Visible = true;
        }
    }
}
