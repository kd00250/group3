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
        this.patientInfoLabel.Text = $"{this.patient.FullName}, born {this.patient.DateOfBirth:MM/dd/yyyy}, Dr. {this.visit.DoctorName}";
        this.testEditController = testEditController;
        this.testNameBox.ReadOnly = true;
        this.unitBox.ReadOnly = true;
        this.highBox.ReadOnly = true;
        this.lowBox.ReadOnly = true;
        this.configureSelectGrid();
        this.loggedInUserControl2.RefreshUser();
        this.loadTests();
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

    private void loadTests()
    {
        try
        {
            var tests = this.testEditController.GetAllTests();
            this.testSelectGrid.DataSource = tests;
            this.testSelectGrid.DataSource = selectedTests;
            this.configureSelectColumns();
            this.testSelectGrid.ClearSelection();
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

        DataGridViewTextBoxColumn testNameColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "TestName",
            HeaderText = "Test Name",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.testSelectGrid.Columns.Add(testNameColumn);

        DataGridViewTextBoxColumn highValueColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "HighValue",
            HeaderText = "High Value",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.testSelectGrid.Columns.Add(highValueColumn);

        DataGridViewTextBoxColumn lowValueColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "LowValue",
            HeaderText = "Low Value",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.testSelectGrid.Columns.Add(lowValueColumn);

        DataGridViewTextBoxColumn unitColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "UnitName",
            HeaderText = "Unit",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.testSelectGrid.Columns.Add(unitColumn);
    }

    private void displayTest(Test test)
    {
        this.testNameBox.Text = test.TestName;
        this.highBox.Text = test.HighValue.ToString();
        this.lowBox.Text = test.LowValue.ToString();
        this.unitBox.Text = test.UnitName;
    }

    private void testSelectGrid_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.RowIndex < this.testSelectGrid.Rows.Count)
        {
            var selectedTest = (Test)this.testSelectGrid.Rows[e.RowIndex].DataBoundItem;
            this.displayTest(selectedTest);
        }


    }

    private void backButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    // Change to serve as save button for the test results
    private void confirmButton_Click(object sender, EventArgs e)
    {
        var selectedTests = this.testSelectGrid.DataSource as IList<Test>;
        if (selectedTests == null || selectedTests.Count == 0)
        {
            this.showMessage("Please select at least one test to order.", "No Tests Selected", MessageBoxIcon.Warning);
            return;
        }

        int visit_id = this.visit.VisitId;
        try
        {
            this.testEditController.ConfirmLabOrder(selectedTests, visit_id);
            this.showMessage("Lab order confirmed successfully.", "Success", MessageBoxIcon.Information);
            this.testSelectGrid.DataSource = null;
        }
        catch (MySqlException)
        {
            this.showMessage("Unable to confirm lab order due to a database error.", "Database Error", MessageBoxIcon.Error);
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

    #endregion
}