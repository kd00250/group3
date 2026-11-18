using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View;

/// <summary>
///     The form for the edit test page.
/// </summary>
/// <seealso cref="System.Windows.Forms.Form" />
public partial class TestEditForm : Form
{
    #region Fields

    private readonly TestEditController testEditController;
    private readonly Visit visit;
    private readonly Patient patient;
    private readonly LabOrder labOrder;
    private Test? selectedTestDetails;
    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="TestEditForm"/> class.
    /// </summary>
    /// <param name="testEditController">The test edit controller.</param>
    /// <param name="visit">The visit.</param>
    /// <param name="patient">The patient.</param>
    /// <param name="labOrder">The lab order.</param>
    public TestEditForm(TestEditController testEditController, Visit visit, Patient patient, LabOrder labOrder)
    {
        this.InitializeComponent();
        this.visit = visit;
        this.patient = patient;
        this.labOrder = labOrder;
        this.patientInfoLabel.Text = $"{this.patient.FullName}, born {this.patient.DateOfBirth:MM/dd/yyyy}, Dr. {this.visit.DoctorName}";
        this.testEditController = testEditController;
        this.testNameBox.ReadOnly = true;
        this.unitBox.ReadOnly = true;
        this.highBox.ReadOnly = true;
        this.lowBox.ReadOnly = true;
        this.configureSelectGrid();
        this.loggedInUserControl1.RefreshUser();
        this.loadOrderedTests();
        this.abnormalCheckbox.Enabled = false;
        this.checkFinalization();
        this.testSelectGrid.ClearSelection();
    }

    #endregion

    #region Methods

    private void configureSelectGrid()
    {
        this.testSelectGrid.ReadOnly = true;
        this.testSelectGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.testSelectGrid.MultiSelect = false;
        this.testSelectGrid.AutoGenerateColumns = true;
        this.testSelectGrid.AllowUserToAddRows = false;
        this.testSelectGrid.AllowUserToDeleteRows = false;
        this.testSelectGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.testSelectGrid.AllowUserToResizeRows = false;
        this.testSelectGrid.RowHeadersVisible = false;
    }

    private void loadOrderedTests()
    {
        try
        {
            var tests = this.testEditController.GetAllOrderedTests(this.labOrder.LabOrderId);
            this.configureSelectColumns();
            this.testSelectGrid.DataSource = tests;
            this.testSelectGrid.ClearSelection();
        }
        catch (MySqlException)
        {
            this.showMessage("Unable to retrieve tests from the database.", "Database Error", MessageBoxIcon.Error);
        }
        catch (UnauthorizedAccessException ex)
        {
            this.showMessage(ex.Message, "Access Denied", MessageBoxIcon.Warning);

            Close();
        }
    }

    private void configureSelectColumns()
    {
        this.testSelectGrid.AutoGenerateColumns = false;
        this.testSelectGrid.Columns.Clear();

        DataGridViewTextBoxColumn orderedIdColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "labOrderId",
            HeaderText = "Order Id",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.testSelectGrid.Columns.Add(orderedIdColumn);

        DataGridViewTextBoxColumn testCodeColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "testCode",
            HeaderText = "Test Code",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.testSelectGrid.Columns.Add(testCodeColumn);

        DataGridViewTextBoxColumn datePreformedColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "dateTimePreformed",
            HeaderText = "Date Performed",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.testSelectGrid.Columns.Add(datePreformedColumn);

        DataGridViewTextBoxColumn resultColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "testResult",
            HeaderText = "Result",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.testSelectGrid.Columns.Add(resultColumn);

        DataGridViewTextBoxColumn isAbnormalColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "isAbnormal",
            HeaderText = "Is Abnormal",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.testSelectGrid.Columns.Add(isAbnormalColumn);
    }

    private void displayTest(Test test)
    {
        this.selectedTestDetails = test;
        this.resultErrorLabel.Text = string.Empty;
        this.testNameBox.Text = test.TestName;
        this.highBox.Text = test.HighValue.ToString();
        this.lowBox.Text = test.LowValue.ToString();
        this.unitBox.Text = test.UnitName;
        var selectedTest = this.testSelectGrid.SelectedRows[0].DataBoundItem as OrderedTest;
        this.resultBox.Text = selectedTest.testResult;
        this.abnormalCheckbox.Checked = selectedTest.isAbnormal;
        this.datePreformedPicker.Value = selectedTest.dateTimePreformed ?? DateTime.Now;
        this.updateAbnormalCheckbox();
        this.checkFinalization();
    }

    private void testSelectGrid_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || this.testSelectGrid.SelectedRows.Count == 0 || this.testSelectGrid.SelectedRows[0].DataBoundItem is not OrderedTest selectedTest)
        {
            return;
        }

        try
        {
            var test = this.testEditController.getTestById(selectedTest.testCode);
            this.displayTest(test);
        }
        catch (ArgumentException ex)
        {
            this.showMessage(ex.Message, "Test Not Found", MessageBoxIcon.Warning);
        }
        catch (MySqlException)
        {
            this.showMessage("Unable to retrieve test details from the database.", "Database Error", MessageBoxIcon.Error);
        }
    }

    private void backButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        var selectedTest = new OrderedTest();
        try
        {
            selectedTest = this.testSelectGrid.SelectedRows[0].DataBoundItem as OrderedTest;
        }
        catch (ArgumentOutOfRangeException)
        {
            this.showMessage("Please select a test to save.", "No Test Selected", MessageBoxIcon.Warning);
            return;
        }

        if (selectedTest == null || this.selectedTestDetails == null || this.selectedTestDetails.TestCode != selectedTest.testCode)
        {
            this.showMessage("Please select a test to save.", "No Test Selected", MessageBoxIcon.Warning);
            return;
        }

        bool isAbnormal;
        try
        {
            isAbnormal = this.testEditController.DetermineAbnormal(this.selectedTestDetails, this.resultBox.Text, this.abnormalCheckbox.Checked);
        }
        catch (ArgumentException ex)
        {
            this.resultErrorLabel.Text = ex.Message;
            return;
        }

        var toSave = new OrderedTest
        {
            labOrderId = selectedTest.labOrderId,
            testCode = selectedTest.testCode,
            testResult = this.resultBox.Text,
            dateTimePreformed = this.datePreformedPicker.Value,
            isAbnormal = isAbnormal
        };

        try
        {
            this.testEditController.UpdateOrderedTests(toSave);
            this.testSelectGrid.DataSource = null;
            this.testSelectGrid.DataSource = this.testEditController.GetAllOrderedTests(this.labOrder.LabOrderId);
            this.selectTest(toSave.testCode);

            this.abnormalCheckbox.Checked = isAbnormal;
            this.resultErrorLabel.Text = string.Empty;
            this.showMessage("Ordered test saved successfully.", "Success", MessageBoxIcon.Information);
        }
        catch (MySqlException)
        {
            this.showMessage("Unable to update ordered test due to a database error.", "Database Error", MessageBoxIcon.Error);
        }
        catch (UnauthorizedAccessException ex)
        {
            this.showMessage(ex.Message, "Access Denied", MessageBoxIcon.Warning);
            Close();
        }
    }

    private void showMessage(string message, string title, MessageBoxIcon icon)
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
    }

    private void checkFinalization()
    {
        if (this.visit.IsFinalized)
        {
            this.resultBox.ReadOnly = true;
            this.datePreformedPicker.Enabled = false;
            this.saveButton.Enabled = false;
            this.abnormalCheckbox.Enabled = false;
        }
    }

    private void TestEditForm_Shown(object sender, EventArgs e)
    {
        this.testSelectGrid.ClearSelection();
    }

    private void selectTest(string testCode)
    {
        foreach (DataGridViewRow row in this.testSelectGrid.Rows)
        {
            if (row.DataBoundItem is OrderedTest orderedTest && orderedTest.testCode == testCode)
            {
                row.Selected = true;
                this.testSelectGrid.CurrentCell = row.Cells[0];
                break;
            }
        }
    }

    private void updateAbnormalCheckbox()
    {
        if (this.selectedTestDetails == null)
        {
            return;
        }

        var hasResult = !string.IsNullOrWhiteSpace(this.resultBox.Text);
        var nurseDecides = !this.testEditController.HasNormalRange(this.selectedTestDetails);

        this.abnormalCheckbox.Enabled = hasResult && nurseDecides;

        if (!hasResult)
        {
            this.abnormalCheckbox.Checked = false;
        }
    }

    private void resultBox_TextChanged(object sender, EventArgs e)
    {
        this.resultErrorLabel.Text = string.Empty;
        this.updateAbnormalCheckbox();
    }
    #endregion
}