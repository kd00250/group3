using System.Text.RegularExpressions;
using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View;

public partial class OrderTestForm : Form
{
    #region Fields

    private const int MaxNameAndCityLength = 50;
    private const int MaxAddressLength = 100;
    private const int NothingSelectedIndex = -1;
    private const int MaxZipCodeLength = 10;
    private const int MaxPasswordLength = 255;
    private const int MaxPhoneNumberLength = 12;

    private readonly OrderTestController orderTestController;

    private int? selectedNurseId;

    #endregion

    #region Constructors

    public OrderTestForm(OrderTestController orderTestController)
    {
        this.InitializeComponent();

        this.orderTestController = orderTestController;
        this.configureSelectGrid();
        this.testNameBox.MaxLength = MaxNameAndCityLength;
        this.lowBox.MaxLength = MaxNameAndCityLength;
        this.highBox.MaxLength = MaxNameAndCityLength;
        this.unitBox.MaxLength = MaxNameAndCityLength;
        this.loggedInUserControl1.RefreshUser();
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


    // FIXME: This method is needs to load tests not nurses.
    private void loadTests() 
    {
        try
        {
            var tests = this.orderTestController.GetAllTests();

            this.testSelectGrid.DataSource = null;
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

    // FIXME: This method is needs to load tests not nurses.
    private void nurseDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        if (this.testSelectGrid.Rows[e.RowIndex].DataBoundItem
            is Test test)
        {
            this.displayTest(test);
        }
    }

    private void backButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void showMessage(string message, string title, MessageBoxIcon icon)
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
    }

    #endregion
}