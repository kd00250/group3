using Google.Protobuf.WellKnownTypes;
using System.Text.RegularExpressions;
using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HealthcareSystem
{
    public partial class PatientEditForm : Form
    {
        /// <summary>
        /// Gets the selected patient.
        /// </summary>
        public Patient SelectedPatient { get; private set; }

        public PatientEditForm(Patient SelectedPatient)
        {
            InitializeComponent();
            this.loggedInUserControl1.RefreshUser();
            this.firstBox.Text = SelectedPatient.FirstName;
            this.lastBox.Text = SelectedPatient.LastName;
            this.dateOfBirthPicker.ShowCheckBox = false; 
            this.dateOfBirthPicker.Value = SelectedPatient.DateOfBirth;
            this.streetBox.Text = SelectedPatient.StreetAddress;
            this.cityBox.Text = SelectedPatient.City;
            this.zipBox.Text = SelectedPatient.ZipCode;
            this.phoneBox.Text = SelectedPatient.PhoneNumber;
            this.activeCheck.Checked = SelectedPatient.IsActive;
            if (SelectedPatient.State != null && this.stateCombo.Items.Contains(SelectedPatient.State))
            {
                this.stateCombo.SelectedItem = SelectedPatient.State;
            }
            else
            {
                this.stateCombo.SelectedIndex = 0;
            }
            if (SelectedPatient.Gender != null && this.genderCombo.Items.Contains(SelectedPatient.Gender))
            {
                this.genderCombo.SelectedItem = SelectedPatient.Gender;
            }
            else
            {
                this.genderCombo.SelectedIndex = 0;
            }
            this.SelectedPatient = SelectedPatient;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!this.validateFields())
            {
                return;
            }

            var firstName = firstBox.Text.Trim();
            var lastName = lastBox.Text.Trim();
            var gender = genderCombo.SelectedItem?.ToString();
            var dateOfBirth = dateOfBirthPicker.Value;
            var streetAddress = streetBox.Text.Trim();
            var city = cityBox.Text.Trim();
            var state = stateCombo.SelectedItem?.ToString();
            var zipCode = zipBox.Text.Trim();
            var phoneNumber = phoneBox.Text.Trim();
            var isActive = activeCheck.Checked;
            try
            {
                PatientEditController.editPatient(SelectedPatient, firstName, lastName, gender, dateOfBirth, streetAddress, city, state, zipCode, phoneNumber, isActive);
                MessageBox.Show("Patient information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

            if (!this.streetAddressValidation())
            {
                isValid = false;
            }

            return isValid;
        }

        private bool genderValidation()
        {
            if (this.genderCombo.SelectedIndex == -1)
            {
                this.showFieldError(this.genderErrorLabel, "Please select a gender.");
                return false;
            }

            return true;
        }

        private bool lastNameValidation()
        {
            var lastName = this.lastBox.Text.Trim();

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
            var firstName = this.firstBox.Text.Trim();

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

        private bool cityValidation()
        {
            var city = this.cityBox.Text.Trim();

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
            var zipCode = this.zipBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(zipCode))
            {
                return true;
            }

            if (!Regex.IsMatch(zipCode, @"^[0-9-]+$"))
            {
                this.showFieldError(this.zipCodeErrorLabel, "ZIP code can only contain numbers and a hyphen.");

                return false;
            }

            if (!Regex.IsMatch(zipCode, @"^\d{5}(-\d{4})?$"))
            {
                this.showFieldError(this.zipCodeErrorLabel, "ZIP code must be in the format XXXXX or XXXXX-XXXX.");

                return false;
            }

            return true;
        }

        private bool phoneNumberValidation()
        {
            var phoneNumber = this.phoneBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return true;
            }

            if (!Regex.IsMatch(phoneNumber, @"^[0-9-]+$"))
            {
                this.showFieldError(this.phoneNumberErrorLabel, "Phone number can only contain numbers and hyphens.");

                return false;
            }

            if (!Regex.IsMatch(phoneNumber, @"^\d{3}-\d{3}-\d{4}$"))
            {
                this.showFieldError(this.phoneNumberErrorLabel, "Phone number must be in the format XXX-XXX-XXXX.");

                return false;
            }

            return true;
        }

        private bool streetAddressValidation()
        {
            var streetAddress = this.streetBox.Text.Trim();

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

        private void clearValidationErrors()
        {
            this.firstNameErrorLabel.Visible = false;
            this.lastNameErrorLabel.Visible = false;
            this.genderErrorLabel.Visible = false;
            this.streetAddressErrorLabel.Visible = false;
            this.cityErrorLabel.Visible = false;
            this.zipCodeErrorLabel.Visible = false;
            this.phoneNumberErrorLabel.Visible = false;
        }

        private void showFieldError(Label errorLabel, string message)
        {
            errorLabel.Text = message;
            errorLabel.Visible = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
