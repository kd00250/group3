using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View
{
    /// <summary>
    /// Lists the visits for a selected patient and lets a nurse open one to view or edit it.
    /// </summary>
    public partial class ViewVisitsForm : Form
    {
        private readonly Patient patient;
        private readonly VisitController visitController;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewVisitsForm"/> class.
        /// </summary>
        /// <param name="patient">The patient whose visits are shown.</param>
        /// <param name="visitController">The visit controller.</param>
        public ViewVisitsForm(Patient patient, VisitController visitController)
        {
            this.InitializeComponent();

            this.patient = patient;
            this.visitController = visitController;
            this.loggedInUserControl1.RefreshUser();

            this.patientLabel.Text = $"Visits for {this.patient.FullName} (born {this.patient.DateOfBirth:MM/dd/yyyy})";
            this.loadVisits();
        }

        private void loadVisits()
        {
            this.visitsGridView.DataSource = null;
            this.selectButton.Enabled = false;
            this.errorLabel.Visible = false;
            this.visitCountLabel.Text = string.Empty;

            try
            {
                var visits = this.visitController.GetVisitsForPatient(this.patient);
                this.visitsGridView.DataSource = visits;
                this.configureColumns();

                this.visitCountLabel.Text = visits.Count switch
                {
                    0 => "No visits found.",
                    1 => "1 visit found.",
                    _ => $"{visits.Count} visits found."
                };
            }
            catch (MySqlException)
            {
                this.showError("Unable to load visits from the database.");
            }
        }

        private void configureColumns()
        {
            foreach (DataGridViewColumn column in this.visitsGridView.Columns)
            {
                column.Visible = false;
            }

            this.showColumn(nameof(Visit.VisitId), "Visit ID");
            this.showColumn(nameof(Visit.VisitDateTime), "Visit Date/Time").DefaultCellStyle.Format = "MM/dd/yyyy h:mm tt";
            this.showColumn(nameof(Visit.DoctorName), "Doctor");
            this.showColumn(nameof(Visit.Reason), "Reason");
            this.showColumn(nameof(Visit.IsFinalized), "Finalized");
        }

        private DataGridViewColumn showColumn(string name, string headerText)
        {
            var column = this.visitsGridView.Columns[name]!;
            column.Visible = true;
            column.HeaderText = headerText;

            return column;
        }

        private void visitsGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.selectButton.Enabled = this.visitsGridView.CurrentRow?.DataBoundItem is Visit;
        }

        private void visitsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.openSelectedVisit();
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            this.openSelectedVisit();
        }

        private void openSelectedVisit()
        {
            if (this.visitsGridView.CurrentRow?.DataBoundItem is not Visit selectedVisit)
            {
                return;
            }

            using var visitInformationForm = new VisitInformationForm(selectedVisit, this.patient, this.visitController);
            visitInformationForm.ShowDialog();

            this.loadVisits();
        }

        private void showError(string message)
        {
            this.errorLabel.Text = message;
            this.errorLabel.Visible = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
