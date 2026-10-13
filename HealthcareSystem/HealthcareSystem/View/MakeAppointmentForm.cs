using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySql.Data.MySqlClient;

namespace HealthcareSystem.View
{
    /// <summary>
    /// Lets a nurse book an appointment for a selected patient with a selected doctor at a selected date and time.
    /// </summary>
    public partial class MakeAppointmentForm : Form
    {
        private readonly Patient patient;
        private readonly AppointmentController appointmentController;

        public MakeAppointmentForm(Patient patient, AppointmentController appointmentController)
        {
            InitializeComponent();
            this.patient = patient;
            this.appointmentController = appointmentController;
            this.loggedInUserControl1.RefreshUser();

            this.patientLabel.Text = $"Appointment for {this.patient.FullName} (born {this.patient.DateOfBirth:MM/dd/yyyy})";

            this.appointmentDatePicker.MinDate = DateTime.Today;
            this.appointmentDatePicker.Value = DateTime.Today;

            this.timeComboBox.FormattingEnabled = true;
            this.timeComboBox.FormatString = "h:mm tt";

            this.errorLabel.Visible = false;
            this.availabilityLabel.Text = string.Empty;

            if (!patient.IsActive)
            {
                this.showError("This patient is not active. Make the patient active before booking an appointment.");
                this.bookButton.Enabled = false;
            }

            this.loadDoctors();
        }

        private void loadDoctors()
        {
            try
            {
                this.doctorComboBox.DisplayMember = nameof(Doctor.FullName);
                this.doctorComboBox.DataSource = this.appointmentController.GetAllDoctors();
                this.doctorComboBox.SelectedIndex = -1;
            }
            catch (MySqlException e)
            {
                this.showError("Unable to load doctors from the database.");
                this.bookButton.Enabled = false;
            }
        }

        private void doctorComboBox_SelectedIndexChange(object sender, EventArgs e)
        {
            this.refreshAvailableTimes();
        }

        private void appointmentDatePicker_ValueChanged(object sender, EventArgs e)
        {
            this.refreshAvailableTimes();
        }

        private void refreshAvailableTimes()
        {
            this.timeComboBox.Items.Clear();
            this.availabilityLabel.Text = string.Empty;

            var doctor = this.doctorComboBox.SelectedItem as Doctor;

            if (doctor == null)
            {
                return;
            }

            try
            {
                var date = this.appointmentDatePicker.Value.Date;
                var availableTimes = this.appointmentController.GetAvailableTimeSlots(doctor.DoctorId, date);

                foreach (var time in availableTimes)
                {
                    this.timeComboBox.Items.Add(date + time);
                }

                if (availableTimes.Count == 0)
                {
                    this.availabilityLabel.Text = $"Dr. {doctor.FullName} has no available times for {date:MM/dd/yyyy}.";
                }
            }
            catch (MySqlException e)
            {
                this.showError("Unable to fetch available times from the database.");
            }
        }

        private void bookButton_Click(object sender, EventArgs e)
        {
            this.errorLabel.Visible = false;

            var doctor = this.doctorComboBox.SelectedItem as Doctor;
            var date = this.appointmentDatePicker.Value.Date;
            var time = (this.timeComboBox.SelectedItem as DateTime?)?.TimeOfDay;
            var reason = this.reasonTextBox.Text;

            try
            {
              var appointmentId = this.appointmentController.BookAppointment(this.patient, doctor, date, time, reason);

              MessageBox.Show(
                  $"Appointment ID:{appointmentId} has been booked for {this.patient.FullName} with Dr. {doctor.FullName} " +
                  $"on {date:MM/dd/yyyy} at {date + time!.Value:h:mm tt}.",
                  "Appointment Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);

              DialogResult = DialogResult.OK;
              Close();
            }
            catch (ArgumentException ex)
            {
                this.showError(ex.Message);
            }
            catch (MySqlException ex)
            {
                this.showError("Unable to book the appointment in the database.");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showError(string message)
        {
            this.errorLabel.Text = message;
            this.errorLabel.Visible = true;
        }
    }
}
