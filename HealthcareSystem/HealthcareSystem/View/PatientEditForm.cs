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
            this.SelectedPatient = SelectedPatient;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            var selectedAttribute = attributeCombo.SelectedItem?.ToString();
            var nextValue = valueBox.Text;
            if (string.IsNullOrEmpty(selectedAttribute) || string.IsNullOrEmpty(nextValue))
            {
                throw new ArgumentException("Please fill in all fields.");
            }
            try
            {
                PatientEditController.editPatient(SelectedPatient, selectedAttribute, nextValue);
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
