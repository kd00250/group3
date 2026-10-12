using System.Text.RegularExpressions;
using HealthcareSystem.Controller;
using HealthcareSystem.Model;
using MySqlConnector;

namespace HealthcareSystem.View;

public partial class NurseManagementForm : Form
{
    #region Fields

    private const int MaxNameAndCityLength = 50;
    private const int MaxAddressLength = 100;
    private const int NothingSelectedIndex = -1;
    private const int MaxZipCodeLength = 10;
    private const int MaxPasswordLength = 255;
    private const int MaxPhoneNumberLength = 12;

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
        this.firstNameTextBox.MaxLength = MaxNameAndCityLength;
        this.lastNameTextBox.MaxLength = MaxNameAndCityLength;
        this.cityTextBox.MaxLength = MaxNameAndCityLength;
        this.streetAddressTextBox.MaxLength = MaxAddressLength;
        this.zipCodeTextBox.MaxLength = MaxZipCodeLength;
        this.usernameTextBox.MaxLength = MaxNameAndCityLength;
        this.passwordTextBox.MaxLength = MaxPasswordLength;
        this.phoneNumberTextBox.MaxLength = MaxPhoneNumberLength;

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

    private NurseCredentials getCredentialsFromFields()
    {
        return new NurseCredentials
        {
            Username = this.usernameTextBox.Text.Trim(),
            Password = this.passwordTextBox.Text
        };
    }

    private bool usernameValidation()
    {
        var username = this.usernameTextBox.Text;

        if (string.IsNullOrWhiteSpace(username))
        {
            this.showError(this.usernameErrorLabel, "Username is required.");
            return false;
        }

        if (username != username.Trim())
        {
            this.showError(this.usernameErrorLabel, "Username cannot start or end with spaces.");
            return false;
        }

        return true;
    }

    private bool passwordValidation()
    {
        var password = this.passwordTextBox.Text;

        if (string.IsNullOrWhiteSpace(password))
        {
            this.showError(this.passwordErrorLabel, "Password is required.");
            return false;
        }

        if (password != password.Trim())
        {
            this.showError(this.passwordErrorLabel, "Password cannot start or end with spaces.");
            return false;
        }

        return true;
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
            this.showMessage("Unable to retrieve nurses from the database.", "Database Error", MessageBoxIcon.Error);
        }
        catch (UnauthorizedAccessException ex)
        {
            this.showMessage(ex.Message, "Access Denied", MessageBoxIcon.Warning);

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

        this.usernameTextBox.Clear();
        this.passwordTextBox.Clear();
        this.usernameTextBox.Enabled = false;
        this.passwordTextBox.Enabled = false;

        this.clearValidationErrors();
    }

    private void clearFields()
    {
        this.selectedNurseId = null;

        this.firstNameTextBox.Clear();
        this.lastNameTextBox.Clear();
        this.genderComboBox.SelectedIndex = NothingSelectedIndex;
        this.dateOfBirthDatePicker.Value = DateTime.Today;
        this.streetAddressTextBox.Clear();
        this.cityTextBox.Clear();
        this.stateComboBox.SelectedIndex = NothingSelectedIndex;
        this.zipCodeTextBox.Clear();
        this.phoneNumberTextBox.Clear();

        this.usernameTextBox.Clear();
        this.passwordTextBox.Clear();

        this.usernameTextBox.Enabled = true;
        this.passwordTextBox.Enabled = true;

        this.addNurseButton.Enabled = true;
        this.updateNurseButton.Enabled = false;

        this.clearValidationErrors();
        this.nurseDataGridView.ClearSelection();
    }

    private bool validateNewNurse()
    {
        var isValid = this.validateFields();

        if (!this.usernameValidation())
        {
            isValid = false;
        }

        if (!this.passwordValidation())
        {
            isValid = false;
        }

        return isValid;
    }

    private void addNurseButton_Click(object sender, EventArgs e)
    {
        if (!this.validateNewNurse())
        {
            return;
        }

        try
        {
            var nurse = this.getNurseFromFields();
            var credentials = this.getCredentialsFromFields();
            var nurseId = this.nurseController.AddNurse(nurse, credentials);

            this.showMessage($"Nurse added successfully. Nurse ID: {nurseId}", "Success", MessageBoxIcon.Information);

            this.clearFields();
            this.loadNurses();
        }
        catch (ArgumentException ex)
        {
            this.showMessage(ex.Message, "Validation Error", MessageBoxIcon.Warning);
        }
        catch (MySqlException ex) when (ex.Number == 1062)
        {
            this.showMessage("A record with the same username already exists. Try a different the username.",
                "Duplicate", MessageBoxIcon.Warning);
        }
        catch (MySqlException)
        {
            this.showMessage("Unable to add nurse to the database.", "Database Error", MessageBoxIcon.Error);
        }
        catch (UnauthorizedAccessException ex)
        {
            this.showMessage(ex.Message, "Access Denied", MessageBoxIcon.Warning);
        }
    }

    private void updateNurseButton_Click(object sender, EventArgs e)
    {
        if (this.selectedNurseId == null)
        {
            this.showMessage("Please select a nurse to update.", "Update Nurse", MessageBoxIcon.Warning);

            return;
        }

        if (!this.validateFields())
        {
            return;
        }

        try
        {
            var nurse = this.getNurseFromFields();

            var updated = this.nurseController.UpdateNurse(nurse);
            this.showMessage(updated ? "Nurse updated successfully." : "No database rows were changed.", "Update Nurse",
                MessageBoxIcon.Information);

            this.clearFields();
            this.loadNurses();
        }
        catch (ArgumentException ex)
        {
            this.showMessage(ex.Message, "Validation Error", MessageBoxIcon.Warning);
        }
        catch (MySqlException)
        {
            this.showMessage("Unable to update nurse.", "Database Error", MessageBoxIcon.Error);
        }
        catch (UnauthorizedAccessException ex)
        {
            this.showMessage(ex.Message, "Access Denied", MessageBoxIcon.Warning);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        this.loadNurses();
    }

    private bool validateFields()
    {
        this.clearValidationErrors();

        var isValid = true;

        isValid = this.firstNameValidation(isValid);

        isValid = this.lastNameValidation(isValid);

        if (this.genderComboBox.SelectedIndex == NothingSelectedIndex)
        {
            this.showError(this.genderErrorLabel, "Please select a gender.");
            isValid = false;
        }

        var dateOfBirth = this.dateOfBirthDatePicker.Value.Date;

        isValid = this.dateOfBirthValidation(dateOfBirth, isValid);

        isValid = this.streetAddressValidation(isValid);

        isValid = this.cityValidation(isValid);

        if (this.stateComboBox.SelectedIndex == NothingSelectedIndex)
        {
            this.showError(this.stateErrorLabel, "Please select a state.");
            isValid = false;
        }

        var zipCode = this.zipCodeTextBox.Text.Trim();

        isValid = this.zipCodeValidation(zipCode, isValid);

        var phoneNumber = this.phoneNumberTextBox.Text.Trim();

        isValid = this.phoneNumberValidation(phoneNumber, isValid);

        return isValid;
    }

    private bool zipCodeValidation(string zipCode, bool isValid)
    {
        if (string.IsNullOrWhiteSpace(zipCode))
        {
            this.showError(this.zipCodeErrorLabel, "ZIP code is required.");
            isValid = false;
        }
        else if (!Regex.IsMatch(zipCode, @"^[0-9]{5}(-[0-9]{4})?$"))
        {
            this.showError(this.zipCodeErrorLabel, "ZIP code must be ##### or #####-####.");
            isValid = false;
        }

        return isValid;
    }

    private bool phoneNumberValidation(string phoneNumber, bool isValid)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            this.showError(this.phoneNumberErrorLabel, "Phone number is required.");
            isValid = false;
        }
        else if (!Regex.IsMatch(phoneNumber, @"^\d{3}-\d{3}-\d{4}$"))
        {
            this.showError(this.phoneNumberErrorLabel, "Enter a phone number in the format 123-456-7890.");
            isValid = false;
        }

        return isValid;
    }

    private bool cityValidation(bool isValid)
    {
        if (string.IsNullOrWhiteSpace(this.cityTextBox.Text))
        {
            this.showError(this.cityErrorLabel, "City is required.");
            isValid = false;
        }
        else if (!Regex.IsMatch(this.cityTextBox.Text.Trim(), @"^[a-zA-Z ]+$"))
        {
            this.showError(this.cityErrorLabel, "City can only contain letters.");
            isValid = false;
        }
        else if (this.cityTextBox.Text.Trim().Length > MaxNameAndCityLength)
        {
            this.showError(this.cityErrorLabel, "City cannot exceed 50 characters.");
            isValid = false;
        }

        return isValid;
    }

    private bool streetAddressValidation(bool isValid)
    {
        if (string.IsNullOrWhiteSpace(this.streetAddressTextBox.Text))
        {
            this.showError(this.streetAddressErrorLabel, "Street address is required.");
            isValid = false;
        }
        else if (!Regex.IsMatch(this.streetAddressTextBox.Text.Trim(), @"^[a-zA-Z0-9 ]+$"))
        {
            this.showError(this.streetAddressErrorLabel,
                "Street address can only contain letters, numbers, and spaces.");
            isValid = false;
        }
        else if (this.streetAddressTextBox.Text.Trim().Length > MaxAddressLength)
        {
            this.showError(this.streetAddressErrorLabel, "Street address cannot exceed 100 characters.");
            isValid = false;
        }

        return isValid;
    }

    private bool dateOfBirthValidation(DateTime dateOfBirth, bool isValid)
    {
        if (dateOfBirth > DateTime.Today)
        {
            this.showError(this.dateOfBirthErrorLabel, "Date of birth cannot be in the future.");
            isValid = false;
        }
        else if (dateOfBirth == DateTime.Today)
        {
            this.showError(this.dateOfBirthErrorLabel, "Please select a valid date of birth.");
            isValid = false;
        }

        return isValid;
    }

    private bool lastNameValidation(bool isValid)
    {
        if (string.IsNullOrWhiteSpace(this.lastNameTextBox.Text))
        {
            this.showError(this.lastNameErrorLabel, "Last name is required.");
            isValid = false;
        }
        else if (!Regex.IsMatch(this.lastNameTextBox.Text.Trim(), @"^[a-zA-Z ]+$"))
        {
            this.showError(this.lastNameErrorLabel, "Last name can only contain letters.");
            isValid = false;
        }
        else if (this.lastNameTextBox.Text.Trim().Length > MaxNameAndCityLength)
        {
            this.showError(this.lastNameErrorLabel, "Last name cannot exceed 50 characters.");
            isValid = false;
        }

        return isValid;
    }

    private bool firstNameValidation(bool isValid)
    {
        if (string.IsNullOrWhiteSpace(this.firstNameTextBox.Text))
        {
            this.showError(this.firstNameErrorLabel, "First name is required.");
            isValid = false;
        }
        else if (!Regex.IsMatch(this.firstNameTextBox.Text.Trim(), @"^[a-zA-Z ]+$"))
        {
            this.showError(this.firstNameErrorLabel, "First name can only contain letters.");
            isValid = false;
        }
        else if (this.firstNameTextBox.Text.Trim().Length > MaxNameAndCityLength)
        {
            this.showError(this.firstNameErrorLabel, "First name cannot exceed 50 characters.");
            isValid = false;
        }

        return isValid;
    }

    private void clearValidationErrors()
    {
        this.firstNameErrorLabel.Visible = false;
        this.lastNameErrorLabel.Visible = false;
        this.genderErrorLabel.Visible = false;
        this.dateOfBirthErrorLabel.Visible = false;
        this.streetAddressErrorLabel.Visible = false;
        this.cityErrorLabel.Visible = false;
        this.stateErrorLabel.Visible = false;
        this.zipCodeErrorLabel.Visible = false;
        this.phoneNumberErrorLabel.Visible = false;
        this.usernameErrorLabel.Visible = false;
        this.passwordErrorLabel.Visible = false;
    }

    private void nurseDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
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

    private void backButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void showError(Label errorLabel, string message)
    {
        errorLabel.Text = message;
        errorLabel.Visible = true;
    }

    private void showMessage(string message, string title, MessageBoxIcon icon)
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
    }

    #endregion
}