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
            SuspendLayout();
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(0, 0);
            loggedInUserControl1.Margin = new Padding(3, 2, 3, 2);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(175, 101);
            loggedInUserControl1.TabIndex = 0;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(175, 43);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(70, 15);
            firstNameLabel.TabIndex = 1;
            firstNameLabel.Text = "First Name :";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(175, 73);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(69, 15);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Last Name :";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(175, 103);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(51, 15);
            genderLabel.TabIndex = 3;
            genderLabel.Text = "Gender :";
            // 
            // dateOfBirthLabel
            // 
            dateOfBirthLabel.AutoSize = true;
            dateOfBirthLabel.Location = new Point(175, 133);
            dateOfBirthLabel.Name = "dateOfBirthLabel";
            dateOfBirthLabel.Size = new Size(79, 15);
            dateOfBirthLabel.TabIndex = 4;
            dateOfBirthLabel.Text = "Date of Birth :";
            // 
            // streetLabel
            // 
            streetLabel.AutoSize = true;
            streetLabel.Location = new Point(175, 163);
            streetLabel.Name = "streetLabel";
            streetLabel.Size = new Size(88, 15);
            streetLabel.TabIndex = 5;
            streetLabel.Text = "Street Address :";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new Point(175, 193);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(34, 15);
            cityLabel.TabIndex = 6;
            cityLabel.Text = "City :";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new Point(175, 223);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(39, 15);
            stateLabel.TabIndex = 7;
            stateLabel.Text = "State :";
            // 
            // zipLabel
            // 
            zipLabel.AutoSize = true;
            zipLabel.Location = new Point(175, 253);
            zipLabel.Name = "zipLabel";
            zipLabel.Size = new Size(61, 15);
            zipLabel.TabIndex = 8;
            zipLabel.Text = "Zip Code :";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(175, 283);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(47, 15);
            phoneLabel.TabIndex = 9;
            phoneLabel.Text = "Phone :";
            // 
            // activeLabel
            // 
            activeLabel.AutoSize = true;
            activeLabel.Location = new Point(175, 313);
            activeLabel.Name = "activeLabel";
            activeLabel.Size = new Size(46, 15);
            activeLabel.TabIndex = 10;
            activeLabel.Text = "Active :";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(275, 40);
            firstNameTextBox.MaxLength = 50;
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(160, 23);
            firstNameTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(275, 70);
            lastNameTextBox.MaxLength = 50;
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(160, 23);
            lastNameTextBox.TabIndex = 2;
            // 
            // genderComboBox
            // 
            genderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            genderComboBox.Items.AddRange(new object[] { "Female", "Male", "Other" });
            genderComboBox.Location = new Point(275, 100);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(160, 23);
            genderComboBox.TabIndex = 3;
            // 
            // dateOfBirthPicker
            // 
            dateOfBirthPicker.Format = DateTimePickerFormat.Short;
            dateOfBirthPicker.Location = new Point(275, 130);
            dateOfBirthPicker.Name = "dateOfBirthPicker";
            dateOfBirthPicker.Size = new Size(160, 23);
            dateOfBirthPicker.TabIndex = 4;
            // 
            // streetTextBox
            // 
            streetTextBox.Location = new Point(275, 160);
            streetTextBox.MaxLength = 100;
            streetTextBox.Name = "streetTextBox";
            streetTextBox.Size = new Size(160, 23);
            streetTextBox.TabIndex = 5;
            // 
            // cityTextBox
            // 
            cityTextBox.Location = new Point(275, 190);
            cityTextBox.MaxLength = 50;
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new Size(160, 23);
            cityTextBox.TabIndex = 6;
            // 
            // stateComboBox
            // 
            stateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            stateComboBox.Items.AddRange(new object[] { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" });
            stateComboBox.Location = new Point(275, 220);
            stateComboBox.Name = "stateComboBox";
            stateComboBox.Size = new Size(160, 23);
            stateComboBox.TabIndex = 7;
            // 
            // zipTextBox
            // 
            zipTextBox.Location = new Point(275, 250);
            zipTextBox.MaxLength = 9;
            zipTextBox.Name = "zipTextBox";
            zipTextBox.Size = new Size(160, 23);
            zipTextBox.TabIndex = 8;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(275, 280);
            phoneTextBox.MaxLength = 12;
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(160, 23);
            phoneTextBox.TabIndex = 9;
            phoneTextBox.PlaceholderText = "xxx-xxx-xxxx";
            // 
            // isActiveCheckbox
            // 
            isActiveCheckbox.AutoSize = true;
            isActiveCheckbox.Location = new Point(275, 312);
            isActiveCheckbox.Name = "isActiveCheckbox";
            isActiveCheckbox.Size = new Size(15, 14);
            isActiveCheckbox.TabIndex = 10;
            isActiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(175, 345);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(75, 23);
            registerButton.TabIndex = 11;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(275, 345);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(75, 23);
            clearButton.TabIndex = 12;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(-1, 426);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 23);
            backButton.TabIndex = 13;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(175, 380);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 15);
            errorLabel.TabIndex = 13;
            errorLabel.Visible = false;
            // 
            // PatientRegistrationForm
            // 
            AcceptButton = registerButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(560, 450);
            Controls.Add(loggedInUserControl1);
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
            Name = "PatientRegistrationForm";
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
    }
}