using Org.BouncyCastle.Asn1.Crmf;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HealthcareSystem.View
{
    partial class PatientRegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loggedInUserControl1 = new LoggedInUserControl();
            firstNameLabel = new Label();
            lastNameLabel = new Label();
            genderLabel = new Label();
            dateOfBirthLabel = new Label();
            streetLabel = new Label();
            cityLabel = new Label();
            stateLabel = new Label();
            zipLabel = new Label();
            phoneLabel = new Label();
            activeLabel = new Label();
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            genderComboBox = new ComboBox();
            dateOfBirthPicker = new DateTimePicker();
            streetTextBox = new TextBox();
            cityTextBox = new TextBox();
            stateComboBox = new ComboBox();
            zipTextBox = new TextBox();
            phoneTextBox = new TextBox();
            isActiveCheckbox = new CheckBox();
            registerButton = new Button();
            clearButton = new Button();
            backButton = new Button();
            errorLabel = new Label();
            firstNameErrorLabel = new Label();
            lastNameErrorLabel = new Label();
            genderErrorLabel = new Label();
            SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(200, 57);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(87, 20);
            firstNameLabel.TabIndex = 1;
            firstNameLabel.Text = "First Name :";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(200, 97);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(86, 20);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Last Name :";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(200, 137);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(64, 20);
            genderLabel.TabIndex = 3;
            genderLabel.Text = "Gender :";
            // 
            // dateOfBirthLabel
            // 
            dateOfBirthLabel.AutoSize = true;
            dateOfBirthLabel.Location = new Point(200, 177);
            dateOfBirthLabel.Name = "dateOfBirthLabel";
            dateOfBirthLabel.Size = new Size(101, 20);
            dateOfBirthLabel.TabIndex = 4;
            dateOfBirthLabel.Text = "Date of Birth :";
            // 
            // streetLabel
            // 
            streetLabel.AutoSize = true;
            streetLabel.Location = new Point(200, 217);
            streetLabel.Name = "streetLabel";
            streetLabel.Size = new Size(112, 20);
            streetLabel.TabIndex = 5;
            streetLabel.Text = "Street Address :";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new Point(200, 257);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(41, 20);
            cityLabel.TabIndex = 6;
            cityLabel.Text = "City :";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new Point(200, 297);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(50, 20);
            stateLabel.TabIndex = 7;
            stateLabel.Text = "State :";
            // 
            // zipLabel
            // 
            zipLabel.AutoSize = true;
            zipLabel.Location = new Point(200, 337);
            zipLabel.Name = "zipLabel";
            zipLabel.Size = new Size(77, 20);
            zipLabel.TabIndex = 8;
            zipLabel.Text = "Zip Code :";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(200, 377);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(57, 20);
            phoneLabel.TabIndex = 9;
            phoneLabel.Text = "Phone :";
            // 
            // activeLabel
            // 
            activeLabel.AutoSize = true;
            activeLabel.Location = new Point(200, 417);
            activeLabel.Name = "activeLabel";
            activeLabel.Size = new Size(57, 20);
            activeLabel.TabIndex = 10;
            activeLabel.Text = "Active :";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(314, 53);
            firstNameTextBox.Margin = new Padding(3, 4, 3, 4);
            firstNameTextBox.MaxLength = 50;
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(182, 27);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(314, 93);
            lastNameTextBox.Margin = new Padding(3, 4, 3, 4);
            lastNameTextBox.MaxLength = 50;
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(182, 27);
            lastNameTextBox.TabIndex = 2;
            // 
            // genderComboBox
            // 
            genderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            genderComboBox.Items.AddRange(new object[] { "Female", "Male", "Other" });
            genderComboBox.Location = new Point(314, 133);
            genderComboBox.Margin = new Padding(3, 4, 3, 4);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(182, 28);
            genderComboBox.TabIndex = 3;
            // 
            // dateOfBirthPicker
            // 
            dateOfBirthPicker.Format = DateTimePickerFormat.Short;
            dateOfBirthPicker.Location = new Point(314, 173);
            dateOfBirthPicker.Margin = new Padding(3, 4, 3, 4);
            dateOfBirthPicker.Name = "dateOfBirthPicker";
            dateOfBirthPicker.Size = new Size(182, 27);
            dateOfBirthPicker.TabIndex = 4;
            // 
            // streetTextBox
            // 
            streetTextBox.Location = new Point(314, 213);
            streetTextBox.Margin = new Padding(3, 4, 3, 4);
            streetTextBox.MaxLength = 100;
            streetTextBox.Name = "streetTextBox";
            streetTextBox.Size = new Size(182, 27);
            streetTextBox.TabIndex = 5;
            // 
            // cityTextBox
            // 
            cityTextBox.Location = new Point(314, 253);
            cityTextBox.Margin = new Padding(3, 4, 3, 4);
            cityTextBox.MaxLength = 50;
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new Size(182, 27);
            cityTextBox.TabIndex = 6;
            // 
            // stateComboBox
            // 
            stateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            stateComboBox.Items.AddRange(new object[] { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" });
            stateComboBox.Location = new Point(314, 293);
            stateComboBox.Margin = new Padding(3, 4, 3, 4);
            stateComboBox.Name = "stateComboBox";
            stateComboBox.Size = new Size(182, 28);
            stateComboBox.TabIndex = 7;
            // 
            // zipTextBox
            // 
            zipTextBox.Location = new Point(314, 333);
            zipTextBox.Margin = new Padding(3, 4, 3, 4);
            zipTextBox.MaxLength = 10;
            zipTextBox.Name = "zipTextBox";
            zipTextBox.Size = new Size(182, 27);
            zipTextBox.TabIndex = 8;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(314, 373);
            phoneTextBox.Margin = new Padding(3, 4, 3, 4);
            phoneTextBox.MaxLength = 12;
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.PlaceholderText = "xxx-xxx-xxxx";
            phoneTextBox.Size = new Size(182, 27);
            phoneTextBox.TabIndex = 9;
            // 
            // isActiveCheckbox
            // 
            isActiveCheckbox.AutoSize = true;
            isActiveCheckbox.Location = new Point(314, 416);
            isActiveCheckbox.Margin = new Padding(3, 4, 3, 4);
            isActiveCheckbox.Name = "isActiveCheckbox";
            isActiveCheckbox.Size = new Size(18, 17);
            isActiveCheckbox.TabIndex = 10;
            isActiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(200, 460);
            registerButton.Margin = new Padding(3, 4, 3, 4);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(86, 31);
            registerButton.TabIndex = 11;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(314, 460);
            clearButton.Margin = new Padding(3, 4, 3, 4);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(86, 31);
            clearButton.TabIndex = 12;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(-1, 568);
            backButton.Margin = new Padding(3, 4, 3, 4);
            backButton.Name = "backButton";
            backButton.Size = new Size(86, 31);
            backButton.TabIndex = 13;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(200, 507);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 20);
            errorLabel.TabIndex = 13;
            errorLabel.Visible = false;
            // 
            // firstNameErrorLabel
            // 
            firstNameErrorLabel.AutoSize = true;
            firstNameErrorLabel.ForeColor = Color.Red;
            firstNameErrorLabel.Location = new Point(506, 58);
            firstNameErrorLabel.Name = "firstNameErrorLabel";
            firstNameErrorLabel.Size = new Size(0, 20);
            firstNameErrorLabel.TabIndex = 14;
            // 
            // lastNameErrorLabel
            // 
            lastNameErrorLabel.AutoSize = true;
            lastNameErrorLabel.ForeColor = Color.Red;
            lastNameErrorLabel.Location = new Point(506, 97);
            lastNameErrorLabel.Name = "lastNameErrorLabel";
            lastNameErrorLabel.Size = new Size(0, 20);
            lastNameErrorLabel.TabIndex = 15;
            // 
            // genderErrorLabel
            // 
            genderErrorLabel.AutoSize = true;
            genderErrorLabel.ForeColor = Color.Red;
            genderErrorLabel.Location = new Point(511, 136);
            genderErrorLabel.Name = "genderErrorLabel";
            genderErrorLabel.Size = new Size(0, 20);
            genderErrorLabel.TabIndex = 16;
            // 
            // PatientRegistrationForm
            // 
            AcceptButton = registerButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(779, 600);
            Controls.Add(genderErrorLabel);
            Controls.Add(lastNameErrorLabel);
            Controls.Add(firstNameErrorLabel);
            Controls.Add(firstNameLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(genderLabel);
            Controls.Add(dateOfBirthLabel);
            Controls.Add(streetLabel);
            Controls.Add(cityLabel);
            Controls.Add(stateLabel);
            Controls.Add(zipLabel);
            Controls.Add(phoneLabel);
            Controls.Add(activeLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(genderComboBox);
            Controls.Add(dateOfBirthPicker);
            Controls.Add(streetTextBox);
            Controls.Add(cityTextBox);
            Controls.Add(stateComboBox);
            Controls.Add(zipTextBox);
            Controls.Add(phoneTextBox);
            Controls.Add(isActiveCheckbox);
            Controls.Add(registerButton);
            Controls.Add(clearButton);
            Controls.Add(errorLabel);
            Controls.Add(backButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PatientRegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Healthcare System - Register Patient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LoggedInUserControl loggedInUserControl1;
        private Label firstNameLabel;
        private Label lastNameLabel;
        private Label genderLabel;
        private Label dateOfBirthLabel;
        private Label streetLabel;
        private Label cityLabel;
        private Label stateLabel;
        private Label zipLabel;
        private Label phoneLabel;
        private Label activeLabel;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private ComboBox genderComboBox;
        private DateTimePicker dateOfBirthPicker;
        private TextBox streetTextBox;
        private TextBox cityTextBox;
        private ComboBox stateComboBox;
        private TextBox zipTextBox;
        private TextBox phoneTextBox;
        private CheckBox isActiveCheckbox;
        private Button registerButton;
        private Button clearButton;
        private Button backButton;
        private Label errorLabel;
        private Label firstNameErrorLabel;
        private Label lastNameErrorLabel;
        private Label genderErrorLabel;
    }
}