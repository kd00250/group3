using System.ComponentModel;
using System.Text.RegularExpressions;
using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View;

public partial class TestEditForm: Form
{
    #region Fields

    private BindingList<Test> selectedTests = new BindingList<Test>();
    private readonly TestEditController testEditController;
    private readonly Visit visit;
    private readonly Patient patient;
    private readonly LabOrder labOrder;
    #endregion

    #region Constructors

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
        this.loggedInUserControl2.RefreshUser();
        this.loadOrderedTests();
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
        this.testNameBox.Text = test.TestName;
        this.highBox.Text = test.HighValue.ToString();
        this.lowBox.Text = test.LowValue.ToString();
        this.unitBox.Text = test.UnitName;
        var selectedTest = this.testSelectGrid.SelectedRows[0].DataBoundItem as OrderedTest;
        this.datePreformedPicker.Value = selectedTest.dateTimePreformed ?? DateTime.Now;
        this.resultBox.Text = selectedTest.testResult.ToString();
        this.abnormalCheck.Checked = selectedTest.isAbnormal;
    }

    private void testSelectGrid_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.RowIndex < this.testSelectGrid.Rows.Count)
        {
            if (this.testSelectGrid.SelectedRows.Count == 0) return;
            var selectedTest = this.testSelectGrid.SelectedRows[0].DataBoundItem as OrderedTest;
            var testId = selectedTest.testCode;
            var test = this.testEditController.getTestById(testId);
            this.displayTest(test);
        }


    }

    private void backButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        var selectedTest = this.testSelectGrid.SelectedRows[0].DataBoundItem as OrderedTest;
        if (selectedTest == null)
        {
            this.showMessage("Please select a test to save.", "No Test Selected", MessageBoxIcon.Warning);
            return;
        }
        if (!this.validateFields())
        {
            return;
        }
        try
        {
            selectedTest.testResult = (double?)double.Parse(this.resultBox.Text);
            selectedTest.dateTimePreformed = this.datePreformedPicker.Value;
            selectedTest.isAbnormal = this.abnormalCheck.Checked;
            this.testEditController.UpdateOrderedTests(selectedTest);
            this.testSelectGrid.DataSource = null;
            this.testSelectGrid.DataSource = this.testEditController.GetAllOrderedTests(this.labOrder.LabOrderId);
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

    private bool validateFields()
    {
        if (!this.validateResultBox())
        {
            return false;
        }
        return true;
    }

    private bool validateResultBox()
    {
        if (string.IsNullOrWhiteSpace(this.resultBox.Text))
        {
            this.resultErrorLabel.Text = "Result field cannot be empty.";
            return false;
        }
        if (double.TryParse(this.resultBox.Text, out double result))
        {
            if (result < 0)
            {
                this.resultErrorLabel.Text = "Result cannot be negative.";
                return false;
            }
            if (result > 99999999)
            {
                this.resultErrorLabel.Text = "Result is too large.";
                return false;
            }
        }
        else
        {
            this.resultErrorLabel.Text = "Result must be a valid number.";
            return false;
        }
        return true;
    }

    #endregion
}