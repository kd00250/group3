using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View
{
    /// <summary>
    /// Lets a nurse book, edit, or view an appointment for a selected patient with a selected doctor at a selected date and time.
    /// </summary>
    public partial class AppointmentForm : Form
    {
        private readonly Patient patient;
        private readonly AppointmentController appointmentController;
        private readonly AppointmentFormMode mode;
        private readonly Appointment? appointment;


        /// <summary>
        /// Initializes the form for booking a new appointment.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="appointmentController">The appointment controller.</param>
        public AppointmentForm(Patient patient, AppointmentController appointmentController)
            : this(patient, appointmentController, null, AppointmentFormMode.Create)
        {
        }

        /// <summary>
        /// Initializes the form for editing or viewing an existing appointment.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="appointmentController">The appointment controller.</param>
        /// <param name="appointment">The appointment to edit or view.</param>
        /// <param name="mode">The mode of the form.</param>
        public AppointmentForm(Patient patient, AppointmentController appointmentController, Appointment? appointment, AppointmentFormMode mode)
        {
            InitializeComponent();
            this.patient = patient;
            this.appointmentController = appointmentController;
            this.mode = mode;
            this.appointment = appointment;
            this.loggedInUserControl1.RefreshUser();

            this.patientLabel.Text = $"Appointment for {this.patient.FullName} (born {this.patient.DateOfBirth:MM/dd/yyyy})";

            this.timeComboBox.FormattingEnabled = true;
            this.timeComboBox.FormatString = "h:mm tt";

            this.errorLabel.Visible = false;
            this.availabilityLabel.Text = string.Empty;

            this.loadDoctors();

            switch (this.mode)
            {
                case AppointmentFormMode.Create:
                    this.setUpCreateMode();
                    break;
                case AppointmentFormMode.Edit:
                    this.setUpEditMode();
                    break;
                case AppointmentFormMode.View:
                    this.setUpViewMode();
                    break;
            }
        }

        private void loadDoctors()
        {
            try
            {
                this.doctorComboBox.DisplayMember = nameof(Doctor.FullName);
                this.doctorComboBox.ValueMember = nameof(Doctor.DoctorId);
                this.doctorComboBox.DataSource = this.appointmentController.GetAllDoctors();
                this.doctorComboBox.SelectedIndex = -1;
            }
            catch (MySqlException e)
            {
                this.showError(this.errorLabel, "Unable to load doctors from the database.");
                this.bookButton.Enabled = false;
            }
        }

        private void setUpCreateMode()
        {
            Text = "Healthcare System - Make Appointment";
            this.bookButton.Text = "Book Appointment";

            this.appointmentDatePicker.MinDate = DateTime.Today;
            this.appointmentDatePicker.Value = DateTime.Today;

            this.blockIfPatientInactive();
        }

        private void setUpEditMode()
        {
            Text = "Healthcare System - Edit Appointment";
            this.bookButton.Text = "Save Changes";

            this.appointmentDatePicker.MinDate = DateTime.Today;
            this.appointmentDatePicker.Value = this.appointment!.AppointmentDate;
            this.doctorComboBox.SelectedValue = this.appointment.DoctorId;
            this.selectTime(this.appointment.AppointmentTime);
            this.reasonTextBox.Text = this.appointment.Reason ?? string.Empty;

            this.blockIfPatientInactive();
        }

        private void setUpViewMode()
        {
            Text = "Healthcare System - Appointment Details";

            this.doctorComboBox.SelectedValue = this.appointment!.DoctorId;
            this.appointmentDatePicker.Value = this.appointment.AppointmentDate;

            this.timeComboBox.Items.Clear();
            this.timeComboBox.Items.Add(this.appointment.AppointmentDateTime);
            this.timeComboBox.SelectedIndex = 0;

            this.reasonTextBox.Text = this.appointment.Reason ?? string.Empty;

            this.doctorComboBox.Enabled = false;
            this.appointmentDatePicker.Enabled = false;
            this.timeComboBox.Enabled = false;
            this.reasonTextBox.ReadOnly = true;
            this.bookButton.Visible = false;
        }

        private void blockIfPatientInactive()
        {
            if (!this.patient.IsActive)
            {
                this.showError(this.errorLabel, "This patient is not active. Make the patient active before making or changing an appointment.");
                this.bookButton.Enabled = false;
            }
        }

        private void selectTime(TimeSpan time)
        {
            foreach (var item in this.timeComboBox.Items)
            {
                if (item is DateTime slot && slot.TimeOfDay == time)
                {
                    this.timeComboBox.SelectedItem = item;
                    return;
                }
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
            if (this.mode == AppointmentFormMode.View)
            {
                return;
            }

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
                var availableTimes = this.appointmentController.GetAvailableTimeSlots(doctor.DoctorId, date, this.appointment?.AppointmentId);

                foreach (var time in availableTimes)
                {
                    this.timeComboBox.Items.Add(date + time);
                }

                if (availableTimes.Count == 0)
                {
                    this.availabilityLabel.Text = $"Dr. {doctor.FullName} has no available times for {date:MM/dd/yyyy}.";
                    this.timeErrorLabel.Visible = false;
                }
            }
            catch (MySqlException e)
            {
                this.showError(this.errorLabel, "Unable to fetch available times from the database.");
            }
        }

        private void bookButton_Click(object sender, EventArgs e)
        {
            this.clearFieldErrors();

            if (!this.validateInputs())
            {
                return;
            }

            var doctor = this.doctorComboBox.SelectedItem as Doctor;
            var date = this.appointmentDatePicker.Value.Date;
            var time = (this.timeComboBox.SelectedItem as DateTime?)?.TimeOfDay;
            var reason = this.reasonTextBox.Text;

            try
            {
                if (this.mode == AppointmentFormMode.Edit)
                {
                    this.saveChanges(doctor, date, time, reason);
                }
                else
                {
                    this.bookNewAppointment(doctor, date, time, reason);
                }
            }
            catch (ArgumentException ex)
            {
                this.showError(this.errorLabel, ex.Message);
            }
            catch (MySqlException ex)
            {
                this.showError(this.errorLabel, "Unable to book the appointment in the database.");
            }
        }

        private void bookNewAppointment(Doctor? doctor, DateTime date, TimeSpan? time, string reason)
        {
            var appointmentId = this.appointmentController.BookAppointment(this.patient, doctor, date, time, reason);

            MessageBox.Show(
                $"Appointment ID:{appointmentId} has been booked for {this.patient.FullName} with Dr. {doctor.FullName} " +
                $"on {date:MM/dd/yyyy} at {date + time!.Value:h:mm tt}.",
                "Appointment Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void saveChanges(Doctor? doctor, DateTime date, TimeSpan? time, string reason)
        {
            var updated = this.appointmentController.UpdateAppointment(this.patient, this.appointment!, doctor, date, time, reason);

            if (!updated)
            {
                this.showError(this.errorLabel, "Failed to update the appointment.");
                return;
            }

            MessageBox.Show(
                $"Appointment updated: Dr. {doctor!.LastName} on {date:MM/dd/yyyy} at {date + time!.Value:h:mm tt}.",
                "Appointment Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void clearFieldErrors()
        {
            this.doctorErrorLabel.Visible = false;
            this.reasonErrorLabel.Visible = false;
            this.timeErrorLabel.Visible = false;
            this.errorLabel.Visible = false;
        }

        private bool validateInputs()
        {
            var isValid = true;

            if (this.doctorComboBox.SelectedItem == null)
            {
                this.showError(this.doctorErrorLabel, "Please select a doctor.");
                isValid = false;
            }

            if (this.timeComboBox.SelectedItem == null)
            {
                if (string.IsNullOrEmpty(this.availabilityLabel.Text))
                {
                    this.showError(this.timeErrorLabel, "Please select a time.");
                }

                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(this.reasonTextBox.Text))
            {
                this.showError(this.reasonErrorLabel, "Please enter a reason for the appointment.");
                isValid = false;
            }

            return isValid;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showError(Label errorLabel, string message)
        {
            errorLabel.Text = message;
            errorLabel.Visible = true;
        }
    }
}
