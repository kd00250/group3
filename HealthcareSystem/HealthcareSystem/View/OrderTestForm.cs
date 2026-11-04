using System.ComponentModel;
using System.Text.RegularExpressions;
using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View;

public partial class OrderTestForm : Form
{
    #region Fields

    private BindingList<Test> selectedTests = new BindingList<Test>();
    private readonly OrderTestController orderTestController;
    private readonly Visit visit;
    private readonly Patient patient;

    #endregion

    #region Constructors

    public OrderTestForm(OrderTestController orderTestController, Visit visit, Patient patient)
    {
        this.InitializeComponent();
        this.visit = visit;
        this.patient = patient;
        this.patientInfoLabel.Text = $"{this.patient.FullName}, born {this.patient.DateOfBirth:MM/dd/yyyy}, Dr. {this.visit.DoctorName}";
        this.orderTestController = orderTestController;
        this.testNameBox.ReadOnly = true;
        this.unitBox.ReadOnly = true;
        this.highBox.ReadOnly = true;
        this.lowBox.ReadOnly = true;
        this.configureSelectGrid();
        this.configureSelectedGrid();
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

    private void configureSelectedGrid()
    {
        this.selectedTestGrid.ReadOnly = true;
        this.selectedTestGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.selectedTestGrid.MultiSelect = false;
        this.selectedTestGrid.AutoGenerateColumns = true;
        this.selectedTestGrid.AllowUserToAddRows = false;
        this.selectedTestGrid.AllowUserToDeleteRows = false;
        this.selectedTestGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.selectedTestGrid.AllowUserToResizeRows = false;
        this.selectedTestGrid.RowHeadersVisible = false;
    }

    private void loadTests()
    {
        try
        {
            var tests = this.orderTestController.GetAllTests();
            this.testSelectGrid.DataSource = tests;
            this.selectedTestGrid.DataSource = selectedTests;
            this.configureSelectColumns();
            this.configureSelectedColumns();
            this.testSelectGrid.ClearSelection();
            this.selectedTestGrid.ClearSelection();
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

    private void configureSelectedColumns()
    {
        this.selectedTestGrid.AutoGenerateColumns = false;
        this.selectedTestGrid.Columns.Clear();

        DataGridViewTextBoxColumn testNameColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "TestName",
            HeaderText = "Test Name",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.selectedTestGrid.Columns.Add(testNameColumn);

        DataGridViewTextBoxColumn highValueColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "HighValue",
            HeaderText = "High Value",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.selectedTestGrid.Columns.Add(highValueColumn);

        DataGridViewTextBoxColumn lowValueColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "LowValue",
            HeaderText = "Low Value",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.selectedTestGrid.Columns.Add(lowValueColumn);

        DataGridViewTextBoxColumn unitColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "UnitName",
            HeaderText = "Unit",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.selectedTestGrid.Columns.Add(unitColumn);
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

    private void addButton_Click(object sender, EventArgs e)
    {
        if (this.testSelectGrid.SelectedRows.Count == 0)
        {
            this.showMessage("Please select a test to add.", "No Test Selected", MessageBoxIcon.Warning);
            return;
        }
        var selectedTest = this.testSelectGrid.SelectedRows[0].DataBoundItem as Test;
        if (selectedTest != null)
        {
            var selectedTests = this.selectedTestGrid.DataSource as IList<Test> ?? new List<Test>();
            if (!selectedTests.Contains(selectedTest))
            {
                this.selectedTests.Add(selectedTest);
                this.selectedTestGrid.Refresh();
                this.selectedTestGrid.ClearSelection();
            }
            else
            {
                this.showMessage("This test has already been added.", "Duplicate Test", MessageBoxIcon.Warning);
            }
        }
    }

    private void removeButton_Click(object sender, EventArgs e)
    {
        if (this.selectedTestGrid.SelectedRows.Count == 0)
        {
            this.showMessage("Please select a test to remove.", "No Test Selected", MessageBoxIcon.Warning);
            return;
        }
        var selectedTest = this.selectedTestGrid.SelectedRows[0].DataBoundItem as Test;
        if (selectedTest != null)
        {
            var selectedTests = this.selectedTestGrid.DataSource as IList<Test>;
            if (selectedTests != null && selectedTests.Contains(selectedTest))
            {
                selectedTests.Remove(selectedTest);
                this.selectedTestGrid.DataSource = null;
                this.selectedTestGrid.DataSource = selectedTests;
                this.selectedTestGrid.ClearSelection();
            }
        }
    }

    private void confirmButton_Click(object sender, EventArgs e)
    {
        var selectedTests = this.selectedTestGrid.DataSource as IList<Test>;
        if (selectedTests == null || selectedTests.Count == 0)
        {
            this.showMessage("Please select at least one test to order.", "No Tests Selected", MessageBoxIcon.Warning);
            return;
        }

        int visit_id = this.visit.VisitId;
        try
        {
            this.orderTestController.ConfirmLabOrder(selectedTests, visit_id);
            this.showMessage("Lab order confirmed successfully.", "Success", MessageBoxIcon.Information);
            this.selectedTestGrid.DataSource = null;
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