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
            this.genderCombo.SelectedItem = SelectedPatient.Gender;
            this.dateOfBirthPicker.ShowCheckBox = false; 
            this.dateOfBirthPicker.Value = SelectedPatient.DateOfBirth;
            this.streetBox.Text = SelectedPatient.StreetAddress;
            this.cityBox.Text = SelectedPatient.City;
            this.stateCombo.SelectedItem = SelectedPatient.State;
            this.zipBox.Text = SelectedPatient.ZipCode;
            this.phoneBox.Text = SelectedPatient.PhoneNumber;
            this.SelectedPatient = SelectedPatient;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            var firstName = firstBox.Text;
            var lastName = lastBox.Text;
            var gender = genderCombo.SelectedItem?.ToString();
            var dateOfBirth = dateOfBirthPicker.Value;
            var streetAddress = streetBox.Text;
            var city = cityBox.Text;
            var state = stateCombo.SelectedItem?.ToString();
            var zipCode = zipBox.Text;
            var phoneNumber = phoneBox.Text;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(streetAddress) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(state) || string.IsNullOrEmpty(zipCode) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                PatientEditController.editPatient(SelectedPatient, firstName, lastName, gender, dateOfBirth, streetAddress, city, state, zipCode, phoneNumber);
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
