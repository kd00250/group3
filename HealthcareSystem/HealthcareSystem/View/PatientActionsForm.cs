using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HealthcareSystem.Model;

namespace HealthcareSystem.View
{
    /// <summary>
    /// Shows the actions a nurse can take for one selected patient.
    /// </summary>
    public partial class PatientActionsForm : Form
    {
        /// <summary>
        /// Gets the selected patient.
        /// </summary>
        public Patient SelectedPatient { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientActionsForm"/> class.
        /// </summary>
        public PatientActionsForm(Patient selectedPatient)
        {
            this.InitializeComponent();

            this.SelectedPatient = selectedPatient;
            this.loggedInUserControl1.RefreshUser();
        }

        private void editPatientButton_Click(object sender, EventArgs e)
        {

        }

        private void viewAppointmentsButton_Click(object sender, EventArgs e)
        {

        }

        private void makeAppointmentButton_Click(object sender, EventArgs e)
        {

        }

        private void viewVisitsButton_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
