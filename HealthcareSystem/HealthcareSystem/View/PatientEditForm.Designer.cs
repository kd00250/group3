namespace HealthcareSystem
{
    partial class PatientEditForm
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
            submitButton = new Button();
            backButton = new Button();
            firstNameLabel = new Label();
            firstBox = new TextBox();
            lastBox = new TextBox();
            lastNameLabel = new Label();
            genderLabel = new Label();
            dateOfBirthLabel = new Label();
            streetBox = new TextBox();
            streetAddressLabel = new Label();
            cityBox = new TextBox();
            cityLabel = new Label();
            stateLabel = new Label();
            zipBox = new TextBox();
            zipCodeLabel = new Label();
            phoneBox = new TextBox();
            phoneNumberLabel = new Label();
            dateOfBirthPicker = new DateTimePicker();
            genderCombo = new ComboBox();
            stateCombo = new ComboBox();
            loggedInUserControl1 = new HealthcareSystem.View.LoggedInUserControl();
            activeCheck = new CheckBox();
            activeLabel = new Label();
            SuspendLayout();
            // 
            // submitButton
            // 
            submitButton.Location = new Point(250, 429);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(94, 29);
            submitButton.TabIndex = 2;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(78, 429);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 3;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(85, 92);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(80, 20);
            firstNameLabel.TabIndex = 4;
            firstNameLabel.Text = "First name:";
            // 
            // firstBox
            // 
            firstBox.Location = new Point(197, 89);
            firstBox.Name = "firstBox";
            firstBox.Size = new Size(125, 27);
            firstBox.TabIndex = 5;
            // 
            // lastBox
            // 
            lastBox.Location = new Point(197, 122);
            lastBox.Name = "lastBox";
            lastBox.Size = new Size(125, 27);
            lastBox.TabIndex = 7;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(85, 125);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(79, 20);
            lastNameLabel.TabIndex = 6;
            lastNameLabel.Text = "Last name:";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(85, 158);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(60, 20);
            genderLabel.TabIndex = 8;
            genderLabel.Text = "Gender:";
            // 
            // dateOfBirthLabel
            // 
            dateOfBirthLabel.AutoSize = true;
            dateOfBirthLabel.Location = new Point(85, 191);
            dateOfBirthLabel.Name = "dateOfBirthLabel";
            dateOfBirthLabel.Size = new Size(97, 20);
            dateOfBirthLabel.TabIndex = 10;
            dateOfBirthLabel.Text = "Date of Birth:";
            // 
            // streetBox
            // 
            streetBox.Location = new Point(197, 221);
            streetBox.Name = "streetBox";
            streetBox.Size = new Size(125, 27);
            streetBox.TabIndex = 13;
            // 
            // streetAddressLabel
            // 
            streetAddressLabel.AutoSize = true;
            streetAddressLabel.Location = new Point(85, 224);
            streetAddressLabel.Name = "streetAddressLabel";
            streetAddressLabel.Size = new Size(106, 20);
            streetAddressLabel.TabIndex = 12;
            streetAddressLabel.Text = "Street address:";
            // 
            // cityBox
            // 
            cityBox.Location = new Point(197, 254);
            cityBox.Name = "cityBox";
            cityBox.Size = new Size(125, 27);
            cityBox.TabIndex = 15;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new Point(85, 257);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(37, 20);
            cityLabel.TabIndex = 14;
            cityLabel.Text = "City:";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new Point(85, 290);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(46, 20);
            stateLabel.TabIndex = 16;
            stateLabel.Text = "State:";
            // 
            // zipBox
            // 
            zipBox.Location = new Point(197, 320);
            zipBox.Name = "zipBox";
            zipBox.Size = new Size(125, 27);
            zipBox.TabIndex = 19;
            // 
            // zipCodeLabel
            // 
            zipCodeLabel.AutoSize = true;
            zipCodeLabel.Location = new Point(85, 323);
            zipCodeLabel.Name = "zipCodeLabel";
            zipCodeLabel.Size = new Size(71, 20);
            zipCodeLabel.TabIndex = 18;
            zipCodeLabel.Text = "Zip code:";
            // 
            // phoneBox
            // 
            phoneBox.Location = new Point(197, 353);
            phoneBox.Name = "phoneBox";
            phoneBox.Size = new Size(125, 27);
            phoneBox.TabIndex = 21;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(85, 356);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(108, 20);
            phoneNumberLabel.TabIndex = 20;
            phoneNumberLabel.Text = "Phone number:";
            // 
            // dateOfBirthPicker
            // 
            dateOfBirthPicker.Format = DateTimePickerFormat.Short;
            dateOfBirthPicker.Location = new Point(197, 191);
            dateOfBirthPicker.Margin = new Padding(3, 4, 3, 4);
            dateOfBirthPicker.MaxDate = new DateTime(2026, 10, 11, 0, 0, 0, 0);
            dateOfBirthPicker.Name = "dateOfBirthPicker";
            dateOfBirthPicker.ShowCheckBox = true;
            dateOfBirthPicker.Size = new Size(125, 27);
            dateOfBirthPicker.TabIndex = 23;
            dateOfBirthPicker.Value = new DateTime(2026, 10, 11, 0, 0, 0, 0);
            // 
            // genderCombo
            // 
            genderCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            genderCombo.FormattingEnabled = true;
            genderCombo.Items.AddRange(new object[] { "Male", "Female", "Other" });
            genderCombo.Location = new Point(197, 155);
            genderCombo.Name = "genderCombo";
            genderCombo.Size = new Size(125, 28);
            genderCombo.TabIndex = 24;
            // 
            // stateCombo
            // 
            stateCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            stateCombo.FormattingEnabled = true;
            stateCombo.Items.AddRange(new object[] { "None selected", "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" });
            stateCombo.Location = new Point(197, 287);
            stateCombo.Name = "stateCombo";
            stateCombo.Size = new Size(125, 28);
            stateCombo.TabIndex = 25;
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(0, -2);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(216, 91);
            loggedInUserControl1.TabIndex = 26;
            // 
            // activeCheck
            // 
            activeCheck.AutoSize = true;
            activeCheck.Location = new Point(250, 389);
            activeCheck.Name = "activeCheck";
            activeCheck.Size = new Size(18, 17);
            activeCheck.TabIndex = 27;
            activeCheck.UseVisualStyleBackColor = true;
            // 
            // activeLabel
            // 
            activeLabel.AutoSize = true;
            activeLabel.Location = new Point(85, 386);
            activeLabel.Name = "activeLabel";
            activeLabel.Size = new Size(116, 20);
            activeLabel.TabIndex = 28;
            activeLabel.Text = "Is patient active:";
            // 
            // PatientEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 470);
            Controls.Add(activeLabel);
            Controls.Add(activeCheck);
            Controls.Add(loggedInUserControl1);
            Controls.Add(stateCombo);
            Controls.Add(genderCombo);
            Controls.Add(dateOfBirthPicker);
            Controls.Add(phoneBox);
            Controls.Add(phoneNumberLabel);
            Controls.Add(zipBox);
            Controls.Add(zipCodeLabel);
            Controls.Add(stateLabel);
            Controls.Add(cityBox);
            Controls.Add(cityLabel);
            Controls.Add(streetBox);
            Controls.Add(streetAddressLabel);
            Controls.Add(dateOfBirthLabel);
            Controls.Add(genderLabel);
            Controls.Add(lastBox);
            Controls.Add(lastNameLabel);
            Controls.Add(firstBox);
            Controls.Add(firstNameLabel);
            Controls.Add(backButton);
            Controls.Add(submitButton);
            Name = "PatientEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PatientEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button submitButton;
        private Button backButton;
        private Label firstNameLabel;
        private TextBox firstBox;
        private TextBox lastBox;
        private Label lastNameLabel;
        private Label genderLabel;
        private Label dateOfBirthLabel;
        private TextBox streetBox;
        private Label streetAddressLabel;
        private TextBox cityBox;
        private Label cityLabel;
        private Label stateLabel;
        private TextBox zipBox;
        private Label zipCodeLabel;
        private TextBox phoneBox;
        private Label phoneNumberLabel;
        private DateTimePicker dateOfBirthPicker;
        private ComboBox genderCombo;
        private ComboBox stateCombo;
        private View.LoggedInUserControl loggedInUserControl1;
        private CheckBox activeCheck;
        private Label activeLabel;
    }
}