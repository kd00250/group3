using System.ComponentModel;
using System.Text.RegularExpressions;
using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View;

public partial class ViewOrdersForm : Form
{
    #region Fields

    private BindingList<Test> selectedTests = new BindingList<Test>();
    private readonly ViewOrdersController viewOrdersController;
    private readonly Visit visit;
    private readonly Patient patient;

    #endregion

    #region Constructors

    public ViewOrdersForm(ViewOrdersController viewOrdersController, Visit visit, Patient patient)
    {
        this.InitializeComponent();
        this.visit = visit;
        this.patient = patient;
        this.patientInfoLabel.Text = $"{this.patient.FullName}, born {this.patient.DateOfBirth:MM/dd/yyyy}, Dr. {this.visit.DoctorName}";
        this.viewOrdersController = viewOrdersController;
        this.configureSelectGrid();
        this.loggedInUserControl2.RefreshUser();
        this.loadOrders();
    }

    #endregion

    #region Methods

    private void configureSelectGrid()
    {
        this.orderSelectGrid.ReadOnly = true;
        this.orderSelectGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.orderSelectGrid.MultiSelect = false;
        this.orderSelectGrid.AutoGenerateColumns = true;
        this.orderSelectGrid.AllowUserToAddRows = false;
        this.orderSelectGrid.AllowUserToDeleteRows = false;
        this.orderSelectGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.orderSelectGrid.AllowUserToResizeRows = false;
        this.orderSelectGrid.RowHeadersVisible = false;
    }

    // should load orders for the visit instead of tests.
    private void loadOrders()
    {
        try
        {
            var orders = this.viewOrdersController.GetOrdersByVisitId(this.visit.VisitId);
            this.orderSelectGrid.DataSource = orders;
            this.configureSelectColumns();
            this.orderSelectGrid.ClearSelection();
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
        this.orderSelectGrid.AutoGenerateColumns = false;
        this.orderSelectGrid.Columns.Clear();

        DataGridViewTextBoxColumn labIdColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "LabId",
            HeaderText = "Lab ID",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.orderSelectGrid.Columns.Add(labIdColumn);

        DataGridViewTextBoxColumn orderDateColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "OrderDate",
            HeaderText = "Order Date",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.orderSelectGrid.Columns.Add(orderDateColumn);

        DataGridViewTextBoxColumn visitIdColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "VisitId",
            HeaderText = "Visit ID",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        };
        this.orderSelectGrid.Columns.Add(visitIdColumn);

    }

    private void backButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    // Update this method to handle the order submission logic
    private void selectButton_Click(object sender, EventArgs e)
    {
        
        var selectedOrder = this.orderSelectGrid.DataSource as IList<LabOrder>;
        if (selectedTests == null || selectedTests.Count == 0)
        {
            this.showMessage("Please select at least one lab order.", "No Lab Orders Selected", MessageBoxIcon.Warning);
            return;
        }
        LabOrder selectedLabOrder = null;
        try
        {
            selectedLabOrder = this.orderSelectGrid.CurrentRow?.DataBoundItem as LabOrder;
        } catch (Exception ex)
        {
            this.showMessage($"An error occurred while selecting the lab order: {ex.Message}", "Error", MessageBoxIcon.Error);
        }

        if (selectedLabOrder == null)
        {
            this.showMessage("Failed to select a lab order.", "Selection Error", MessageBoxIcon.Error);
            return;
        }
        var testEditController = new TestEditController(new Model.DAL.TestEditDal());
        var testEditForm = new TestEditForm(testEditController, this.visit, this.patient, selectedLabOrder);
        testEditForm.ShowDialog();

    }

    private void showMessage(string message, string title, MessageBoxIcon icon)
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
    }

    #endregion
}