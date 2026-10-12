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
            nurseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            nurseDataGridView.Location = new Point(12, 175);
            nurseDataGridView.Name = "nurseDataGridView";
            nurseDataGridView.RowHeadersWidth = 51;
            nurseDataGridView.Size = new Size(1343, 359);
            nurseDataGridView.TabIndex = 0;
            nurseDataGridView.CellClick += nurseDataGridView_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 144);
            label1.Name = "label1";
            label1.Size = new Size(149, 28);
            label1.TabIndex = 1;
            label1.Text = "Nurse Records";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 593);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 2;
            label2.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(540, 593);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 3;
            label3.Text = "Last Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 676);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 4;
            label4.Text = "Date of Birth";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(540, 679);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 5;
            label5.Text = "Gender";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(73, 757);
            label6.Name = "label6";
            label6.Size = new Size(105, 20);
            label6.TabIndex = 6;
            label6.Text = "Street Address";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(540, 757);
            label7.Name = "label7";
            label7.Size = new Size(34, 20);
            label7.TabIndex = 7;
            label7.Text = "City";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(73, 833);
            label8.Name = "label8";
            label8.Size = new Size(43, 20);
            label8.TabIndex = 8;
            label8.Text = "State";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(540, 833);
            label9.Name = "label9";
            label9.Size = new Size(69, 20);
            label9.TabIndex = 9;
            label9.Text = "ZIP Code";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(74, 911);
            label10.Name = "label10";
            label10.Size = new Size(108, 20);
            label10.TabIndex = 10;
            label10.Text = "Phone Number";
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(870, 1055);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(125, 40);
            refreshButton.TabIndex = 11;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(711, 1055);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(125, 40);
            clearButton.TabIndex = 12;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // addNurseButton
            // 
            addNurseButton.Location = new Point(1041, 1056);
            addNurseButton.Name = "addNurseButton";
            addNurseButton.Size = new Size(125, 39);
            addNurseButton.TabIndex = 13;
            addNurseButton.Text = "Add Nurse";
            addNurseButton.UseVisualStyleBackColor = true;
            addNurseButton.Click += addNurseButton_Click;
            // 
            // updateNurseButton
            // 
            updateNurseButton.Location = new Point(1201, 1055);
            updateNurseButton.Name = "updateNurseButton";
            updateNurseButton.Size = new Size(125, 40);
            updateNurseButton.TabIndex = 14;
            updateNurseButton.Text = "Update Nurse";
            updateNurseButton.UseVisualStyleBackColor = true;
            updateNurseButton.Click += updateNurseButton_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 16F);
            label11.Location = new Point(540, 24);
            label11.Name = "label11";
            label11.Size = new Size(251, 37);
            label11.TabIndex = 15;
            label11.Text = "Nurse Management";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(74, 616);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.PlaceholderText = "Enter First Name";
            firstNameTextBox.Size = new Size(200, 27);
            firstNameTextBox.TabIndex = 16;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(540, 616);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.PlaceholderText = "Enter Last Name";
            lastNameTextBox.Size = new Size(200, 27);
            lastNameTextBox.TabIndex = 17;
            // 
            // streetAddressTextBox
            // 
            streetAddressTextBox.Location = new Point(73, 780);
            streetAddressTextBox.Name = "streetAddressTextBox";
            streetAddressTextBox.PlaceholderText = "ex: 14 Peach St";
            streetAddressTextBox.Size = new Size(200, 27);
            streetAddressTextBox.TabIndex = 18;
            // 
            // cityTextBox
            // 
            cityTextBox.Location = new Point(540, 780);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.PlaceholderText = "ex: Atlanta";
            cityTextBox.Size = new Size(200, 27);
            cityTextBox.TabIndex = 19;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(73, 934);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.PlaceholderText = "Enter Phone Number";
            phoneNumberTextBox.Size = new Size(200, 27);
            phoneNumberTextBox.TabIndex = 20;
            // 
            // zipCodeTextBox
            // 
            zipCodeTextBox.Location = new Point(540, 856);
            zipCodeTextBox.Name = "zipCodeTextBox";
            zipCodeTextBox.Size = new Size(200, 27);
            zipCodeTextBox.TabIndex = 21;
            // 
            // genderComboBox
            // 
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Location = new Point(540, 702);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(200, 28);
            genderComboBox.TabIndex = 22;
            // 
            // stateComboBox
            // 
            stateComboBox.FormattingEnabled = true;
            stateComboBox.Location = new Point(73, 856);
            stateComboBox.Name = "stateComboBox";
            stateComboBox.Size = new Size(200, 28);
            stateComboBox.TabIndex = 23;
            // 
            // dateOfBirthDatePicker
            // 
            dateOfBirthDatePicker.Location = new Point(73, 700);
            dateOfBirthDatePicker.Name = "dateOfBirthDatePicker";
            dateOfBirthDatePicker.Size = new Size(250, 27);
            dateOfBirthDatePicker.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(12, 550);
            label12.Name = "label12";
            label12.Size = new Size(187, 28);
            label12.TabIndex = 25;
            label12.Text = "Nurse Information";
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(0, 0);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(329, 141);
            loggedInUserControl1.TabIndex = 26;
            // 
            // firstNameErrorLabel
            // 
            firstNameErrorLabel.AutoSize = true;
            firstNameErrorLabel.ForeColor = Color.Red;
            firstNameErrorLabel.Location = new Point(74, 646);
            firstNameErrorLabel.Name = "firstNameErrorLabel";
            firstNameErrorLabel.Size = new Size(0, 20);
            firstNameErrorLabel.TabIndex = 27;
            // 
            // dateOfBirthErrorLabel
            // 
            dateOfBirthErrorLabel.AutoSize = true;
            dateOfBirthErrorLabel.ForeColor = Color.Red;
            dateOfBirthErrorLabel.Location = new Point(74, 730);
            dateOfBirthErrorLabel.Name = "dateOfBirthErrorLabel";
            dateOfBirthErrorLabel.Size = new Size(0, 20);
            dateOfBirthErrorLabel.TabIndex = 28;
            // 
            // streetAddressErrorLabel
            // 
            streetAddressErrorLabel.AutoSize = true;
            streetAddressErrorLabel.ForeColor = Color.Red;
            streetAddressErrorLabel.Location = new Point(75, 809);
            streetAddressErrorLabel.Name = "streetAddressErrorLabel";
            streetAddressErrorLabel.Size = new Size(0, 20);
            streetAddressErrorLabel.TabIndex = 29;
            // 
            // stateErrorLabel
            // 
            stateErrorLabel.AutoSize = true;
            stateErrorLabel.ForeColor = Color.Red;
            stateErrorLabel.Location = new Point(74, 884);
            stateErrorLabel.Name = "stateErrorLabel";
            stateErrorLabel.Size = new Size(0, 20);
            stateErrorLabel.TabIndex = 30;
            // 
            // phoneNumberErrorLabel
            // 
            phoneNumberErrorLabel.AutoSize = true;
            phoneNumberErrorLabel.ForeColor = Color.Red;
            phoneNumberErrorLabel.Location = new Point(75, 964);
            phoneNumberErrorLabel.Name = "phoneNumberErrorLabel";
            phoneNumberErrorLabel.Size = new Size(0, 20);
            phoneNumberErrorLabel.TabIndex = 31;
            // 
            // lastNameErrorLabel
            // 
            lastNameErrorLabel.AutoSize = true;
            lastNameErrorLabel.ForeColor = Color.Red;
            lastNameErrorLabel.Location = new Point(540, 646);
            lastNameErrorLabel.Name = "lastNameErrorLabel";
            lastNameErrorLabel.Size = new Size(0, 20);
            lastNameErrorLabel.TabIndex = 32;
            // 
            // genderErrorLabel
            // 
            genderErrorLabel.AutoSize = true;
            genderErrorLabel.ForeColor = Color.Red;
            genderErrorLabel.Location = new Point(540, 730);
            genderErrorLabel.Name = "genderErrorLabel";
            genderErrorLabel.Size = new Size(0, 20);
            genderErrorLabel.TabIndex = 33;
            // 
            // cityErrorLabel
            // 
            cityErrorLabel.AutoSize = true;
            cityErrorLabel.ForeColor = Color.Red;
            cityErrorLabel.Location = new Point(540, 809);
            cityErrorLabel.Name = "cityErrorLabel";
            cityErrorLabel.Size = new Size(0, 20);
            cityErrorLabel.TabIndex = 34;
            // 
            // zipCodeErrorLabel
            // 
            zipCodeErrorLabel.AutoSize = true;
            zipCodeErrorLabel.ForeColor = Color.Red;
            zipCodeErrorLabel.Location = new Point(540, 884);
            zipCodeErrorLabel.Name = "zipCodeErrorLabel";
            zipCodeErrorLabel.Size = new Size(0, 20);
            zipCodeErrorLabel.TabIndex = 35;
            // 
            // backButton
            // 
            backButton.Location = new Point(12, 1056);
            backButton.Name = "backButton";
            backButton.Size = new Size(125, 40);
            backButton.TabIndex = 36;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(854, 550);
            label13.Name = "label13";
            label13.Size = new Size(282, 28);
            label13.TabIndex = 37;
            label13.Text = "New Nurse Login Credintials";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(884, 593);
            label14.Name = "label14";
            label14.Size = new Size(75, 20);
            label14.TabIndex = 38;
            label14.Text = "Username";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(884, 679);
            label15.Name = "label15";
            label15.Size = new Size(70, 20);
            label15.TabIndex = 39;
            label15.Text = "Password";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(884, 616);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "Enter a username";
            usernameTextBox.Size = new Size(200, 27);
            usernameTextBox.TabIndex = 40;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(884, 703);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Enter a password";
            passwordTextBox.Size = new Size(200, 27);
            passwordTextBox.TabIndex = 41;
            // 
            // usernameErrorLabel
            // 
            usernameErrorLabel.AutoSize = true;
            usernameErrorLabel.ForeColor = Color.Red;
            usernameErrorLabel.Location = new Point(886, 646);
            usernameErrorLabel.Name = "usernameErrorLabel";
            usernameErrorLabel.Size = new Size(0, 20);
            usernameErrorLabel.TabIndex = 42;
            // 
            // passwordErrorLabel
            // 
            passwordErrorLabel.AutoSize = true;
            passwordErrorLabel.ForeColor = Color.Red;
            passwordErrorLabel.Location = new Point(885, 730);
            passwordErrorLabel.Name = "passwordErrorLabel";
            passwordErrorLabel.Size = new Size(0, 20);
            passwordErrorLabel.TabIndex = 43;
            // 
            // NurseManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1365, 1107);
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
            Name = "NurseManagementForm";
            Text = "NurseManagement";
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