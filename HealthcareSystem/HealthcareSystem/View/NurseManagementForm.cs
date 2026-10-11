using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View;

public partial class NurseManagementForm : Form
{
    #region Fields

    private readonly NurseController nurseController;

    private int? selectedNurseId;

    #endregion

    #region Constructors

    public NurseManagementForm(NurseController nurseController)
    {
        this.InitializeComponent();

        this.nurseController = nurseController;
        this.configureNurseGrid();
        this.configureGenderComboBox();
        this.configureStateComboBox();
        this.dateOfBirthDatePicker.MaxDate = DateTime.Today;
        this.loggedInUserControl1.RefreshUser();

        this.clearFields();
    }

    #endregion

    #region Methods

    private void configureNurseGrid()
    {
        this.nurseDataGridView.ReadOnly = true;
        this.nurseDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.nurseDataGridView.MultiSelect = false;
        this.nurseDataGridView.AutoGenerateColumns = true;
        this.nurseDataGridView.AllowUserToAddRows = false;
        this.nurseDataGridView.AllowUserToDeleteRows = false;
        this.nurseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.nurseDataGridView.AllowUserToResizeRows = false;
        this.nurseDataGridView.RowHeadersVisible = false;
    }

    private void configureGenderComboBox()
    {
        this.genderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        this.genderComboBox.Items.Clear();
        this.genderComboBox.Items.AddRange("Male", "Female");
    }

    private void configureStateComboBox()
    {
        this.stateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        this.stateComboBox.Items.Clear();
        this.stateComboBox.Items.AddRange("AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL",
            "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM",
            "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI",
            "WY");
    }

    private void loadNurses()
    {
        try
        {
            var nurses = this.nurseController.GetAllNurses();

            this.nurseDataGridView.DataSource = null;
            this.nurseDataGridView.DataSource = nurses;
            this.nurseDataGridView.ClearSelection();
        }
        catch (MySqlException)
        {
            MessageBox.Show(
                "Unable to retrieve nurses from the database.",
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (UnauthorizedAccessException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            Close();
        }
    }

    private Nurse getNurseFromFields()
    {
        return new Nurse
        {
            NurseId = this.selectedNurseId ?? 0,

            FirstName = this.firstNameTextBox.Text.Trim(),
            LastName = this.lastNameTextBox.Text.Trim(),

            Gender = this.genderComboBox.SelectedItem?.ToString() ?? string.Empty,

            DateOfBirth = this.dateOfBirthDatePicker.Value.Date,

            StreetAddress = this.streetAddressTextBox.Text.Trim(),
            City = this.cityTextBox.Text.Trim(),

            State = this.stateComboBox.SelectedItem?.ToString() ?? string.Empty,

            ZipCode = this.zipCodeTextBox.Text.Trim(),
            PhoneNumber = this.phoneNumberTextBox.Text.Trim()
        };
    }

    private void displayNurse(Nurse nurse)
    {
        this.selectedNurseId = nurse.NurseId;
        this.firstNameTextBox.Text = nurse.FirstName;
        this.lastNameTextBox.Text = nurse.LastName;
        this.genderComboBox.SelectedItem = nurse.Gender;
        this.dateOfBirthDatePicker.Value = nurse.DateOfBirth;
        this.streetAddressTextBox.Text = nurse.StreetAddress ?? "";
        this.cityTextBox.Text = nurse.City ?? "";
        this.stateComboBox.SelectedItem = nurse.State;
        this.zipCodeTextBox.Text = nurse.ZipCode ?? "";
        this.phoneNumberTextBox.Text = nurse.PhoneNumber ?? "";
        this.addNurseButton.Enabled = false;
        this.updateNurseButton.Enabled = true;
    }

    private void clearFields()
    {
        this.selectedNurseId = null;
        this.firstNameTextBox.Clear();
        this.lastNameTextBox.Clear();
        this.genderComboBox.SelectedIndex = -1;
        this.dateOfBirthDatePicker.Value = DateTime.Today;
        this.streetAddressTextBox.Clear();
        this.cityTextBox.Clear();
        this.stateComboBox.SelectedIndex = -1;
        this.zipCodeTextBox.Clear();
        this.phoneNumberTextBox.Clear();
        this.addNurseButton.Enabled = true;
        this.updateNurseButton.Enabled = false;

        this.nurseDataGridView.ClearSelection();
    }

    private void addNurseButton_Click(object sender, EventArgs e)
    {
        try
        {
            var nurse = this.getNurseFromFields();
            var nurseId = this.nurseController.AddNurse(nurse);

            MessageBox.Show(
                $"Nurse added successfully. Nurse ID: {nurseId}",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.clearFields();
            this.loadNurses();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (MySqlException)
        {
            MessageBox.Show(
                "Unable to add nurse to the database.",
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (UnauthorizedAccessException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private void updateNurseButton_Click(object sender, EventArgs e)
    {
        if (this.selectedNurseId == null)
        {
            MessageBox.Show(
                "Please select a nurse to update.",
                "Update Nurse",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        try
        {
            var nurse = this.getNurseFromFields();

            var updated = this.nurseController.UpdateNurse(nurse);

            MessageBox.Show(
                updated ? "Nurse updated successfully." : "No database rows were changed.", "Update Nurse",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.clearFields();
            this.loadNurses();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (MySqlException)
        {
            MessageBox.Show(
                "Unable to update nurse.",
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (UnauthorizedAccessException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Access Denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        this.loadNurses();
    }

    private void nurseDataGridView_CellClick(
        object sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        if (this.nurseDataGridView.Rows[e.RowIndex].DataBoundItem
            is Nurse nurse)
        {
            this.displayNurse(nurse);
        }
    }

    private void clearButton_Click(object sender, EventArgs e)
    {
        this.clearFields();
    }

    private void refreshButton_Click(object sender, EventArgs e)
    {
        this.clearFields();
        this.loadNurses();
    }

    #endregion
}