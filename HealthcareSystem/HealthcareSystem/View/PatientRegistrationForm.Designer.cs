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
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            genderComboBox = new ComboBox();
            dateOfBirthPicker = new DateTimePicker();
            streetTextBox = new TextBox();
            cityTextBox = new TextBox();
            stateTextBox = new TextBox();
            zipTextBox = new TextBox();
            phoneTextBox = new TextBox();
            isActiveCheckbox = new CheckBox();
            registerButton = new Button();
            clearButton = new Button();
            backButton = new Button();
            errorLabel = new Label();
            SuspendLayout();

            loggedInUserControl1.Location = new Point(-1, 1);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(245, 101);
            loggedInUserControl1.TabIndex = 0;

            // labels + inputs: label at x=175, input at x=275, 30px spacing
            AddRow("First Name :", firstNameTextBox, 40, 1);
            AddRow("Last Name :", lastNameTextBox, 70, 2);
            AddRow("Gender :", genderComboBox, 100, 3);
            AddRow("Date of Birth :", dateOfBirthPicker, 130, 4);
            AddRow("Street Address :", streetTextBox, 160, 5);
            AddRow("City :", cityTextBox, 190, 6);
            AddRow("State :", stateTextBox, 220, 7);
            AddRow("Zip Code :", zipTextBox, 250, 8);
            AddRow("Phone :", phoneTextBox, 280, 9);
            AddRow("Active :", isActiveCheckbox, 310, 10);
            genderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            genderComboBox.Items.AddRange(new object[] { "Female", "Male", "Other" });
            dateOfBirthPicker.Format = DateTimePickerFormat.Short;
            dateOfBirthPicker.MaxDate = DateTime.Today;
            firstNameTextBox.MaxLength = 50;
            lastNameTextBox.MaxLength = 50;
            streetTextBox.MaxLength = 100;
            cityTextBox.MaxLength = 50;
            stateTextBox.MaxLength = 50;
            zipTextBox.MaxLength = 10;
            phoneTextBox.MaxLength = 20;
            isActiveCheckbox.Enabled = true;
            isActiveCheckbox.Checked = false;

            registerButton.Location = new Point(175, 345);
            registerButton.Size = new Size(75, 23);
            registerButton.TabIndex = 10;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;

            clearButton.Location = new Point(275, 345);
            clearButton.Size = new Size(75, 23);
            clearButton.TabIndex = 11;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;

            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(175, 380);
            errorLabel.Name = "errorLabel";
            errorLabel.Visible = false;
            errorLabel.TabIndex = 12;

            backButton.Location = new Point(-1, 400);
            backButton.Size = new Size(75, 23);
            backButton.TabIndex = 13;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;

            AcceptButton = registerButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(560, 424);
            Controls.Add(loggedInUserControl1);
            Controls.Add(registerButton);
            Controls.Add(clearButton);
            Controls.Add(backButton);
            Controls.Add(errorLabel);
            Name = "PatientRegistrationForm";
            Text = "Healthcare System - Register Patient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private void AddRow(string labelText, Control input, int y, int tabIndex)
        {
            var label = new Label { AutoSize = true, Text = labelText, Location = new Point(175, y + 3) };
            input.Location = new Point(275, y);
            input.Size = new Size(160, 23);
            input.Name = input.GetType().Name + tabIndex;
            input.TabIndex = tabIndex;
            Controls.Add(label);
            Controls.Add(input);
        }

        private LoggedInUserControl loggedInUserControl1;
        private TextBox firstNameTextBox, lastNameTextBox, streetTextBox, cityTextBox, stateTextBox, zipTextBox, phoneTextBox;
        private ComboBox genderComboBox;
        private DateTimePicker dateOfBirthPicker;
        private Button registerButton, clearButton, backButton;
        private Label errorLabel;
        private CheckBox isActiveCheckbox;
    }
}