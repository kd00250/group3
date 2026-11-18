namespace HealthcareSystem.View
{
    partial class NurseManagementForm
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
            nurseDataGridView = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            refreshButton = new Button();
            clearButton = new Button();
            addNurseButton = new Button();
            updateNurseButton = new Button();
            label11 = new Label();
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            streetAddressTextBox = new TextBox();
            cityTextBox = new TextBox();
            phoneNumberTextBox = new TextBox();
            zipCodeTextBox = new TextBox();
            genderComboBox = new ComboBox();
            stateComboBox = new ComboBox();
            dateOfBirthDatePicker = new DateTimePicker();
            label12 = new Label();
            loggedInUserControl1 = new LoggedInUserControl();
            firstNameErrorLabel = new Label();
            dateOfBirthErrorLabel = new Label();
            streetAddressErrorLabel = new Label();
            stateErrorLabel = new Label();
            phoneNumberErrorLabel = new Label();
            lastNameErrorLabel = new Label();
            genderErrorLabel = new Label();
            cityErrorLabel = new Label();
            zipCodeErrorLabel = new Label();
            backButton = new Button();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            usernameErrorLabel = new Label();
            passwordErrorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)nurseDataGridView).BeginInit();
            SuspendLayout();
            // 
            // nurseDataGridView
            // 
            nurseDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nurseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            nurseDataGridView.Location = new Point(10, 131);
            nurseDataGridView.Margin = new Padding(3, 2, 3, 2);
            nurseDataGridView.Name = "nurseDataGridView";
            nurseDataGridView.RowHeadersWidth = 51;
            nurseDataGridView.Size = new Size(1175, 236);
            nurseDataGridView.TabIndex = 0;
            nurseDataGridView.CellClick += nurseDataGridView_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 108);
            label1.Name = "label1";
            label1.Size = new Size(119, 21);
            label1.TabIndex = 1;
            label1.Text = "Nurse Records";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 412);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 2;
            label2.Text = "First Name";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new Point(455, 412);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 3;
            label3.Text = "Last Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 459);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 4;
            label4.Text = "Date of Birth";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(474, 459);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 5;
            label5.Text = "Gender";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 510);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 6;
            label6.Text = "Street Address";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Location = new Point(494, 508);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 7;
            label7.Text = "City";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(96, 558);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 8;
            label8.Text = "State";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Location = new Point(464, 553);
            label9.Name = "label9";
            label9.Size = new Size(55, 15);
            label9.TabIndex = 9;
            label9.Text = "ZIP Code";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(39, 598);
            label10.Name = "label10";
            label10.Size = new Size(88, 15);
            label10.TabIndex = 10;
            label10.Text = "Phone Number";
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refreshButton.Location = new Point(744, 618);
            refreshButton.Margin = new Padding(3, 2, 3, 2);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(109, 30);
            refreshButton.TabIndex = 11;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clearButton.Location = new Point(607, 618);
            clearButton.Margin = new Padding(3, 2, 3, 2);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(109, 30);
            clearButton.TabIndex = 12;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // addNurseButton
            // 
            addNurseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addNurseButton.Location = new Point(885, 618);
            addNurseButton.Margin = new Padding(3, 2, 3, 2);
            addNurseButton.Name = "addNurseButton";
            addNurseButton.Size = new Size(109, 29);
            addNurseButton.TabIndex = 13;
            addNurseButton.Text = "Add Nurse";
            addNurseButton.UseVisualStyleBackColor = true;
            addNurseButton.Click += addNurseButton_Click;
            // 
            // updateNurseButton
            // 
            updateNurseButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            updateNurseButton.Location = new Point(1035, 617);
            updateNurseButton.Margin = new Padding(3, 2, 3, 2);
            updateNurseButton.Name = "updateNurseButton";
            updateNurseButton.Size = new Size(109, 30);
            updateNurseButton.TabIndex = 14;
            updateNurseButton.Text = "Update Nurse";
            updateNurseButton.UseVisualStyleBackColor = true;
            updateNurseButton.Click += updateNurseButton_Click;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 16F);
            label11.Location = new Point(472, 18);
            label11.Name = "label11";
            label11.Size = new Size(205, 30);
            label11.TabIndex = 15;
            label11.Text = "Nurse Management";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(139, 412);
            firstNameTextBox.Margin = new Padding(3, 2, 3, 2);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.PlaceholderText = "Enter First Name";
            firstNameTextBox.Size = new Size(176, 23);
            firstNameTextBox.TabIndex = 16;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Anchor = AnchorStyles.Top;
            lastNameTextBox.Location = new Point(529, 410);
            lastNameTextBox.Margin = new Padding(3, 2, 3, 2);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.PlaceholderText = "Enter Last Name";
            lastNameTextBox.Size = new Size(176, 23);
            lastNameTextBox.TabIndex = 17;
            // 
            // streetAddressTextBox
            // 
            streetAddressTextBox.Location = new Point(139, 508);
            streetAddressTextBox.Margin = new Padding(3, 2, 3, 2);
            streetAddressTextBox.Name = "streetAddressTextBox";
            streetAddressTextBox.PlaceholderText = "ex: 14 Peach St";
            streetAddressTextBox.Size = new Size(176, 23);
            streetAddressTextBox.TabIndex = 18;
            // 
            // cityTextBox
            // 
            cityTextBox.Anchor = AnchorStyles.Top;
            cityTextBox.Location = new Point(529, 505);
            cityTextBox.Margin = new Padding(3, 2, 3, 2);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.PlaceholderText = "ex: Atlanta";
            cityTextBox.Size = new Size(176, 23);
            cityTextBox.TabIndex = 19;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(139, 598);
            phoneNumberTextBox.Margin = new Padding(3, 2, 3, 2);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.PlaceholderText = "Enter Phone Number";
            phoneNumberTextBox.Size = new Size(176, 23);
            phoneNumberTextBox.TabIndex = 20;
            // 
            // zipCodeTextBox
            // 
            zipCodeTextBox.Anchor = AnchorStyles.Top;
            zipCodeTextBox.Location = new Point(529, 550);
            zipCodeTextBox.Margin = new Padding(3, 2, 3, 2);
            zipCodeTextBox.Name = "zipCodeTextBox";
            zipCodeTextBox.Size = new Size(176, 23);
            zipCodeTextBox.TabIndex = 21;
            // 
            // genderComboBox
            // 
            genderComboBox.Anchor = AnchorStyles.Top;
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Location = new Point(529, 457);
            genderComboBox.Margin = new Padding(3, 2, 3, 2);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(176, 23);
            genderComboBox.TabIndex = 22;
            // 
            // stateComboBox
            // 
            stateComboBox.FormattingEnabled = true;
            stateComboBox.Location = new Point(139, 556);
            stateComboBox.Margin = new Padding(3, 2, 3, 2);
            stateComboBox.Name = "stateComboBox";
            stateComboBox.Size = new Size(176, 23);
            stateComboBox.TabIndex = 23;
            // 
            // dateOfBirthDatePicker
            // 
            dateOfBirthDatePicker.Location = new Point(139, 459);
            dateOfBirthDatePicker.Margin = new Padding(3, 2, 3, 2);
            dateOfBirthDatePicker.Name = "dateOfBirthDatePicker";
            dateOfBirthDatePicker.Size = new Size(219, 23);
            dateOfBirthDatePicker.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(10, 382);
            label12.Name = "label12";
            label12.Size = new Size(151, 21);
            label12.TabIndex = 25;
            label12.Text = "Nurse Information";
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(0, 0);
            loggedInUserControl1.Margin = new Padding(3, 2, 3, 2);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(275, 106);
            loggedInUserControl1.TabIndex = 26;
            // 
            // firstNameErrorLabel
            // 
            firstNameErrorLabel.AutoSize = true;
            firstNameErrorLabel.ForeColor = Color.Red;
            firstNameErrorLabel.Location = new Point(141, 435);
            firstNameErrorLabel.Name = "firstNameErrorLabel";
            firstNameErrorLabel.Size = new Size(0, 15);
            firstNameErrorLabel.TabIndex = 27;
            // 
            // dateOfBirthErrorLabel
            // 
            dateOfBirthErrorLabel.AutoSize = true;
            dateOfBirthErrorLabel.ForeColor = Color.Red;
            dateOfBirthErrorLabel.Location = new Point(141, 482);
            dateOfBirthErrorLabel.Name = "dateOfBirthErrorLabel";
            dateOfBirthErrorLabel.Size = new Size(0, 15);
            dateOfBirthErrorLabel.TabIndex = 28;
            // 
            // streetAddressErrorLabel
            // 
            streetAddressErrorLabel.AutoSize = true;
            streetAddressErrorLabel.ForeColor = Color.Red;
            streetAddressErrorLabel.Location = new Point(141, 530);
            streetAddressErrorLabel.Name = "streetAddressErrorLabel";
            streetAddressErrorLabel.Size = new Size(0, 15);
            streetAddressErrorLabel.TabIndex = 29;
            // 
            // stateErrorLabel
            // 
            stateErrorLabel.AutoSize = true;
            stateErrorLabel.ForeColor = Color.Red;
            stateErrorLabel.Location = new Point(141, 579);
            stateErrorLabel.Name = "stateErrorLabel";
            stateErrorLabel.Size = new Size(0, 15);
            stateErrorLabel.TabIndex = 30;
            // 
            // phoneNumberErrorLabel
            // 
            phoneNumberErrorLabel.AutoSize = true;
            phoneNumberErrorLabel.ForeColor = Color.Red;
            phoneNumberErrorLabel.Location = new Point(141, 620);
            phoneNumberErrorLabel.Name = "phoneNumberErrorLabel";
            phoneNumberErrorLabel.Size = new Size(0, 15);
            phoneNumberErrorLabel.TabIndex = 31;
            // 
            // lastNameErrorLabel
            // 
            lastNameErrorLabel.Anchor = AnchorStyles.Top;
            lastNameErrorLabel.AutoSize = true;
            lastNameErrorLabel.ForeColor = Color.Red;
            lastNameErrorLabel.Location = new Point(529, 433);
            lastNameErrorLabel.Name = "lastNameErrorLabel";
            lastNameErrorLabel.Size = new Size(0, 15);
            lastNameErrorLabel.TabIndex = 32;
            // 
            // genderErrorLabel
            // 
            genderErrorLabel.Anchor = AnchorStyles.Top;
            genderErrorLabel.AutoSize = true;
            genderErrorLabel.ForeColor = Color.Red;
            genderErrorLabel.Location = new Point(529, 482);
            genderErrorLabel.Name = "genderErrorLabel";
            genderErrorLabel.Size = new Size(0, 15);
            genderErrorLabel.TabIndex = 33;
            // 
            // cityErrorLabel
            // 
            cityErrorLabel.Anchor = AnchorStyles.Top;
            cityErrorLabel.AutoSize = true;
            cityErrorLabel.ForeColor = Color.Red;
            cityErrorLabel.Location = new Point(529, 527);
            cityErrorLabel.Name = "cityErrorLabel";
            cityErrorLabel.Size = new Size(0, 15);
            cityErrorLabel.TabIndex = 34;
            // 
            // zipCodeErrorLabel
            // 
            zipCodeErrorLabel.Anchor = AnchorStyles.Top;
            zipCodeErrorLabel.AutoSize = true;
            zipCodeErrorLabel.ForeColor = Color.Red;
            zipCodeErrorLabel.Location = new Point(529, 573);
            zipCodeErrorLabel.Name = "zipCodeErrorLabel";
            zipCodeErrorLabel.Size = new Size(0, 15);
            zipCodeErrorLabel.TabIndex = 35;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backButton.Location = new Point(10, 618);
            backButton.Margin = new Padding(3, 2, 3, 2);
            backButton.Name = "backButton";
            backButton.Size = new Size(109, 30);
            backButton.TabIndex = 36;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(836, 382);
            label13.Name = "label13";
            label13.Size = new Size(227, 21);
            label13.TabIndex = 37;
            label13.Text = "New Nurse Login Credintials";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new Point(846, 415);
            label14.Name = "label14";
            label14.Size = new Size(60, 15);
            label14.TabIndex = 38;
            label14.Text = "Username";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Location = new Point(850, 463);
            label15.Name = "label15";
            label15.Size = new Size(57, 15);
            label15.TabIndex = 39;
            label15.Text = "Password";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            usernameTextBox.Location = new Point(920, 410);
            usernameTextBox.Margin = new Padding(3, 2, 3, 2);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "Enter a username";
            usernameTextBox.Size = new Size(176, 23);
            usernameTextBox.TabIndex = 40;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            passwordTextBox.Location = new Point(920, 460);
            passwordTextBox.Margin = new Padding(3, 2, 3, 2);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Enter a password";
            passwordTextBox.Size = new Size(176, 23);
            passwordTextBox.TabIndex = 41;
            // 
            // usernameErrorLabel
            // 
            usernameErrorLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            usernameErrorLabel.AutoSize = true;
            usernameErrorLabel.ForeColor = Color.Red;
            usernameErrorLabel.Location = new Point(920, 433);
            usernameErrorLabel.Name = "usernameErrorLabel";
            usernameErrorLabel.Size = new Size(0, 15);
            usernameErrorLabel.TabIndex = 42;
            // 
            // passwordErrorLabel
            // 
            passwordErrorLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            passwordErrorLabel.AutoSize = true;
            passwordErrorLabel.ForeColor = Color.Red;
            passwordErrorLabel.Location = new Point(920, 483);
            passwordErrorLabel.Name = "passwordErrorLabel";
            passwordErrorLabel.Size = new Size(0, 15);
            passwordErrorLabel.TabIndex = 43;
            // 
            // NurseManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 652);
            Controls.Add(passwordErrorLabel);
            Controls.Add(usernameErrorLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(backButton);
            Controls.Add(zipCodeErrorLabel);
            Controls.Add(cityErrorLabel);
            Controls.Add(genderErrorLabel);
            Controls.Add(lastNameErrorLabel);
            Controls.Add(phoneNumberErrorLabel);
            Controls.Add(stateErrorLabel);
            Controls.Add(streetAddressErrorLabel);
            Controls.Add(dateOfBirthErrorLabel);
            Controls.Add(firstNameErrorLabel);
            Controls.Add(loggedInUserControl1);
            Controls.Add(label12);
            Controls.Add(dateOfBirthDatePicker);
            Controls.Add(stateComboBox);
            Controls.Add(genderComboBox);
            Controls.Add(zipCodeTextBox);
            Controls.Add(phoneNumberTextBox);
            Controls.Add(cityTextBox);
            Controls.Add(streetAddressTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(label11);
            Controls.Add(updateNurseButton);
            Controls.Add(addNurseButton);
            Controls.Add(clearButton);
            Controls.Add(refreshButton);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nurseDataGridView);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NurseManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Healthcare System - Manage Nurses";
            ((System.ComponentModel.ISupportInitialize)nurseDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView nurseDataGridView;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button refreshButton;
        private Button clearButton;
        private Button addNurseButton;
        private Button updateNurseButton;
        private Label label11;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private TextBox streetAddressTextBox;
        private TextBox cityTextBox;
        private TextBox phoneNumberTextBox;
        private TextBox zipCodeTextBox;
        private ComboBox genderComboBox;
        private ComboBox stateComboBox;
        private DateTimePicker dateOfBirthDatePicker;
        private Label label12;
        private LoggedInUserControl loggedInUserControl1;
        private Label firstNameErrorLabel;
        private Label dateOfBirthErrorLabel;
        private Label streetAddressErrorLabel;
        private Label stateErrorLabel;
        private Label phoneNumberErrorLabel;
        private Label lastNameErrorLabel;
        private Label genderErrorLabel;
        private Label cityErrorLabel;
        private Label zipCodeErrorLabel;
        private Button backButton;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Label usernameErrorLabel;
        private Label passwordErrorLabel;
    }
}