using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View
{
    /// <summary>
    /// Lets an administrator view the statistics of the tests performed at least twice during a specified date range.
    /// </summary>
    public partial class TestStatisticsForm : Form
    {
        private const int DefaultRangeDays = 30;

        private readonly TestStatisticsController testStatisticsController;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestStatisticsForm"/> class.
        /// </summary>
        /// <param name="testStatisticsController">The test statistics controller.</param>
        public TestStatisticsForm(TestStatisticsController testStatisticsController)
        {
            InitializeComponent();
            this.testStatisticsController = testStatisticsController;
            this.loggedInUserControl1.RefreshUser();

            this.startDatePicker.Value = DateTime.Today.AddDays(-DefaultRangeDays);
            this.endDatePicker.Value = DateTime.Today;


        }


        private void showStatisticsButton_Click(object sender, EventArgs e)
        {
            this.clearResults();

            var startDate = this.startDatePicker.Value.Date;
            var endDate = this.endDatePicker.Value.Date;

            try
            {
                var testStatistics = this.testStatisticsController.GetMostPerformedTestsDuringDates(startDate, endDate);

                this.statisticsDataGridView.DataSource = testStatistics;
                this.configureColumns();

                this.resultCountLabel.Text = testStatistics.Count switch
                {
                    0 => "No tests were performed at least twice in this date range.",
                    1 => "1 test found.",
                    _ => $"{testStatistics.Count} tests found."
                };
            }
            catch (ArgumentException ex)
            {
                this.showError(this.dateRangeErrorLabel, ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                this.showError(this.errorLabel, ex.Message);
            }
            catch (MySqlException)
            {
                this.showError(this.errorLabel, "Unable to retrieve test statistics from the database.");
            }

        }

        private void configureColumns()
        {
            this.statisticsDataGridView.Columns[nameof(TestStatistic.TestCode)]!.HeaderText = "Test Code";
            this.statisticsDataGridView.Columns[nameof(TestStatistic.TestName)]!.HeaderText = "Test Name";
            this.statisticsDataGridView.Columns[nameof(TestStatistic.TimesPerformed)]!.HeaderText = "Times Performed";
            this.statisticsDataGridView.Columns[nameof(TestStatistic.TotalTestsPerformed)]!.HeaderText = "All Tests Performed";
            this.statisticsDataGridView.Columns[nameof(TestStatistic.PercentagePerformed)]!.HeaderText = "Percentage of All Tests";
            this.statisticsDataGridView.Columns[nameof(TestStatistic.NormalResults)]!.HeaderText = "Normal Results";
            this.statisticsDataGridView.Columns[nameof(TestStatistic.AbnormalResults)]!.HeaderText = "Abnormal Results";

            this.statisticsDataGridView.Columns[nameof(TestStatistic.PercentagePerformed)]!.DefaultCellStyle.Format = "0.00'%'";
        }

        private void clearResults()
        {
            this.statisticsDataGridView.DataSource = null;
            this.resultCountLabel.Text = string.Empty;
            this.dateRangeErrorLabel.Visible = false;
            this.errorLabel.Visible = false;
        }

        private void showError(Label label, string message)
        {
            label.Visible = true;
            label.Text = message;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
