using Google.Protobuf.WellKnownTypes;
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

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(gender))
            {
                MessageBox.Show("Please fill in first name, last name, and gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
