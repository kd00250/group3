using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View
{
    /// <summary>
    /// Shows a patients upcoming and past appointments.
    /// </summary>
    public partial class PatientAppointmentsForm : Form
    {
        private readonly Patient patient;
        private readonly AppointmentController appointmentController;

        public PatientAppointmentsForm(Patient patient, AppointmentController appointmentController)
        {
            this.InitializeComponent();

            this.patient = patient;
            this.appointmentController = appointmentController;
            this.loggedInUserControl1.RefreshUser();

            this.patientLabel.Text = $"Appointments for {this.patient.FullName} born {this.patient.DateOfBirth:MM/dd/yyyy}";
            this.errorLabel.Visible = false;

            configureGrid(this.upcomingGridView);
            configureGrid(this.pastGridView);

            this.loadAppointments();
        }

        private void loadAppointments()
        {
            try
            {
                var (upcoming, past) = this.appointmentController.GetAppointmentsForPatient(this.patient.PatientId);

                this.upcomingGridView.DataSource = upcoming;
                configureColumns(this.upcomingGridView);
                this.upcomingEmptyLabel.Text = upcoming.Count == 0 ? "No upcoming appointments." : string.Empty;

                this.pastGridView.DataSource = past;
                configureColumns(this.pastGridView);
                this.pastEmptyLabel.Text = past.Count == 0 ? "No past appointments." : string.Empty;
            }
            catch (MySqlException)
            {
                this.errorLabel.Text = "Unable to load appointments from the database.";
                this.errorLabel.Visible = true;
            }
        }

        private static void configureGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private static void configureColumns(DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.Visible = false;
            }

            showColumn(grid, nameof(Appointment.AppointmentDate), "Date", "MM/dd/yyyy", 0);
            showColumn(grid, nameof(Appointment.AppointmentDateTime), "Time", "hh:mm tt", 1);
            showColumn(grid, nameof(Appointment.DoctorFullName), "Doctor", null, 2);
            showColumn(grid, nameof(Appointment.Reason), "Reason", null, 3);

            grid.ClearSelection();
        }

        private static void showColumn(DataGridView grid, string propertyName, string headerText, string? format, int position)
        {
            var column = grid.Columns[propertyName];
            column.Visible = true;
            column.HeaderText = headerText;
            column.DisplayIndex = position;

            if (format != null)
            {
                column.DefaultCellStyle.Format = format;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
