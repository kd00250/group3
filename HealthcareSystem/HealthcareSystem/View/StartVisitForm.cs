using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View
{
    public partial class StartVisitForm : Form
    {
        private readonly Patient selectedPatient;
        private readonly VisitController visitController;

        public StartVisitForm(Patient selectedPatient, VisitController visitController)
        {
            this.InitializeComponent();
            this.selectedPatient = selectedPatient;
            this.visitController = visitController;

            this.loggedInUserControl1.RefreshUser();

            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.startVisitButton.Enabled = false;
            this.dataGridView1.SelectionChanged += this.dataGridView1_SelectionChanged;

            this.loadAppointments();
        }

        /// <summary>
        ///     Loads the available appointments for the patient.
        /// </summary>
        private void loadAppointments()
        {
            var appointments = this.visitController.GetAvailableAppointments(this.selectedPatient);

            this.dataGridView1.DataSource = appointments;

            this.dataGridView1.Columns[nameof(Appointment.PatientId)]!.Visible = false;
            this.dataGridView1.Columns[nameof(Appointment.AppointmentDate)]!.Visible = false;
            this.dataGridView1.Columns[nameof(Appointment.AppointmentTime)]!.Visible = false;
            this.dataGridView1.Columns[nameof(Appointment.DoctorId)]!.Visible = false;
            this.dataGridView1.Columns[nameof(Appointment.DoctorName)]!.HeaderText = "Doctor Name";

            if (this.dataGridView1.Columns[nameof(Appointment.AppointmentDateTime)] is DataGridViewColumn dateTimeColumn)
            {
                dateTimeColumn.DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt";
            }

            this.dataGridView1.ClearSelection();

            this.startVisitButton.Enabled = false;
        }

        private void backButton_Click(object? sender, EventArgs e)
        {
            Close();

        }

        private void startVisitButton_Click(object? sender, EventArgs e)
        {

            var appointment = this.dataGridView1.SelectedRows[0].DataBoundItem as Appointment;

            if (appointment == null)
            {
                MessageBox.Show(
                    "Please select a valid appointment.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            try
            {
                var visit = this.visitController.StartVisit(this.selectedPatient, appointment);
                using var visitInformationForm = new VisitInformationForm(visit, this.selectedPatient, this.visitController);

                visitInformationForm.ShowDialog(this);

                this.loadAppointments();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show(
                    "A visit has already been started for this appointment.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.loadAppointments();
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Unable to start the visit due to a database error.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            this.startVisitButton.Enabled =
                this.dataGridView1.SelectedRows.Count > 0;
        }
    }
}
