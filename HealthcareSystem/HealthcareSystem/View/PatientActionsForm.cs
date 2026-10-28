using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using HealthcareSystem.Model.DAL;

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
        /// <param name="selectedPatient">The selected patient.</param>
        public PatientActionsForm(Patient selectedPatient)
        {
            this.InitializeComponent();

            this.SelectedPatient = selectedPatient;
            this.loggedInUserControl1.RefreshUser();
        }

        private void editPatientButton_Click(object sender, EventArgs e)
        {
            using var patientEditForm = new PatientEditForm(this.SelectedPatient);
            patientEditForm.ShowDialog();
        }

        private void viewAppointmentsButton_Click(object sender, EventArgs e)
        {

        }

        private void makeAppointmentButton_Click(object sender, EventArgs e)
        {
            var appointmentController = new AppointmentController(new AppointmentDal(), new DoctorDal());
            using var makeAppointmentForm = new MakeAppointmentForm(this.SelectedPatient, appointmentController);
            makeAppointmentForm.ShowDialog();
        }

        private void viewVisitsButton_Click(object sender, EventArgs e)
        {
            var visitController = new VisitController(new VisitDal());
            using var viewVisitsForm = new ViewVisitsForm(this.SelectedPatient, visitController);
            viewVisitsForm.ShowDialog();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
