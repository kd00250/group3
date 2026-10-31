namespace HealthcareSystem.View
{
    partial class OrderTestForm
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
            testSelectGrid = new DataGridView();
            testsLabel = new Label();
            testLabel = new Label();
            highLabel = new Label();
            confirmOrderButton = new Button();
            testNameBox = new TextBox();
            highBox = new TextBox();
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
            usernameErrorLabel = new Label();
            passwordErrorLabel = new Label();
            selectedTestGrid = new DataGridView();
            lowBox = new TextBox();
            lowLabel = new Label();
            unitLabel = new Label();
            unitBox = new TextBox();
            selectedLable = new Label();
            ((System.ComponentModel.ISupportInitialize)testSelectGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectedTestGrid).BeginInit();
            SuspendLayout();
            // 
            // testSelectGrid
            // 
            testSelectGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            testSelectGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            testSelectGrid.Location = new Point(12, 175);
            testSelectGrid.Name = "testSelectGrid";
            testSelectGrid.RowHeadersWidth = 51;
            testSelectGrid.Size = new Size(342, 314);
            testSelectGrid.TabIndex = 0;
            testSelectGrid.CellClick += testSelectGrid_CellClick;
            // 
            // testsLabel
            // 
            testsLabel.AutoSize = true;
            testsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            testsLabel.Location = new Point(12, 144);
            testsLabel.Name = "testsLabel";
            testsLabel.Size = new Size(153, 28);
            testsLabel.TabIndex = 1;
            testsLabel.Text = "Available Tests";
            // 
            // testLabel
            // 
            testLabel.AutoSize = true;
            testLabel.Location = new Point(30, 553);
            testLabel.Name = "testLabel";
            testLabel.Size = new Size(79, 20);
            testLabel.TabIndex = 2;
            testLabel.Text = "Test Name";
            // 
            // highLabel
            // 
            highLabel.Anchor = AnchorStyles.Top;
            highLabel.AutoSize = true;
            highLabel.Location = new Point(273, 553);
            highLabel.Name = "highLabel";
            highLabel.Size = new Size(81, 20);
            highLabel.TabIndex = 3;
            highLabel.Text = "High Value";
            // 
            // confirmOrderButton
            // 
            confirmOrderButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            confirmOrderButton.Location = new Point(685, 596);
            confirmOrderButton.Name = "confirmOrderButton";
            confirmOrderButton.Size = new Size(125, 40);
            confirmOrderButton.TabIndex = 14;
            confirmOrderButton.Text = "Confirm";
            confirmOrderButton.UseVisualStyleBackColor = true;
            confirmOrderButton.Click += confirmButton_Click;
            // 
            // testNameBox
            // 
            testNameBox.Location = new Point(115, 550);
            testNameBox.Name = "testNameBox";
            testNameBox.PlaceholderText = "Please select test";
            testNameBox.Size = new Size(145, 27);
            testNameBox.TabIndex = 16;
            // 
            // highBox
            // 
            highBox.Anchor = AnchorStyles.Top;
            highBox.Location = new Point(360, 550);
            highBox.Name = "highBox";
            highBox.Size = new Size(103, 27);
            highBox.TabIndex = 17;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(12, 510);
            label12.Name = "label12";
            label12.Size = new Size(169, 28);
            label12.TabIndex = 25;
            label12.Text = "Test Information";
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(0, 0);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(314, 141);
            loggedInUserControl1.TabIndex = 26;
            // 
            // firstNameErrorLabel
            // 
            firstNameErrorLabel.AutoSize = true;
            firstNameErrorLabel.ForeColor = Color.Red;
            firstNameErrorLabel.Location = new Point(161, 580);
            firstNameErrorLabel.Name = "firstNameErrorLabel";
            firstNameErrorLabel.Size = new Size(0, 20);
            firstNameErrorLabel.TabIndex = 27;
            // 
            // dateOfBirthErrorLabel
            // 
            dateOfBirthErrorLabel.AutoSize = true;
            dateOfBirthErrorLabel.ForeColor = Color.Red;
            dateOfBirthErrorLabel.Location = new Point(355, 553);
            dateOfBirthErrorLabel.Name = "dateOfBirthErrorLabel";
            dateOfBirthErrorLabel.Size = new Size(0, 20);
            dateOfBirthErrorLabel.TabIndex = 28;
            // 
            // streetAddressErrorLabel
            // 
            streetAddressErrorLabel.AutoSize = true;
            streetAddressErrorLabel.ForeColor = Color.Red;
            streetAddressErrorLabel.Location = new Point(161, 707);
            streetAddressErrorLabel.Name = "streetAddressErrorLabel";
            streetAddressErrorLabel.Size = new Size(0, 20);
            streetAddressErrorLabel.TabIndex = 29;
            // 
            // stateErrorLabel
            // 
            stateErrorLabel.AutoSize = true;
            stateErrorLabel.ForeColor = Color.Red;
            stateErrorLabel.Location = new Point(161, 772);
            stateErrorLabel.Name = "stateErrorLabel";
            stateErrorLabel.Size = new Size(0, 20);
            stateErrorLabel.TabIndex = 30;
            // 
            // phoneNumberErrorLabel
            // 
            phoneNumberErrorLabel.AutoSize = true;
            phoneNumberErrorLabel.ForeColor = Color.Red;
            phoneNumberErrorLabel.Location = new Point(161, 827);
            phoneNumberErrorLabel.Name = "phoneNumberErrorLabel";
            phoneNumberErrorLabel.Size = new Size(0, 20);
            phoneNumberErrorLabel.TabIndex = 31;
            // 
            // lastNameErrorLabel
            // 
            lastNameErrorLabel.Anchor = AnchorStyles.Top;
            lastNameErrorLabel.AutoSize = true;
            lastNameErrorLabel.ForeColor = Color.Red;
            lastNameErrorLabel.Location = new Point(501, 577);
            lastNameErrorLabel.Name = "lastNameErrorLabel";
            lastNameErrorLabel.Size = new Size(0, 20);
            lastNameErrorLabel.TabIndex = 32;
            // 
            // genderErrorLabel
            // 
            genderErrorLabel.Anchor = AnchorStyles.Top;
            genderErrorLabel.AutoSize = true;
            genderErrorLabel.ForeColor = Color.Red;
            genderErrorLabel.Location = new Point(550, 553);
            genderErrorLabel.Name = "genderErrorLabel";
            genderErrorLabel.Size = new Size(0, 20);
            genderErrorLabel.TabIndex = 33;
            // 
            // cityErrorLabel
            // 
            cityErrorLabel.Anchor = AnchorStyles.Top;
            cityErrorLabel.AutoSize = true;
            cityErrorLabel.ForeColor = Color.Red;
            cityErrorLabel.Location = new Point(356, 703);
            cityErrorLabel.Name = "cityErrorLabel";
            cityErrorLabel.Size = new Size(0, 20);
            cityErrorLabel.TabIndex = 34;
            // 
            // zipCodeErrorLabel
            // 
            zipCodeErrorLabel.Anchor = AnchorStyles.Top;
            zipCodeErrorLabel.AutoSize = true;
            zipCodeErrorLabel.ForeColor = Color.Red;
            zipCodeErrorLabel.Location = new Point(356, 764);
            zipCodeErrorLabel.Name = "zipCodeErrorLabel";
            zipCodeErrorLabel.Size = new Size(0, 20);
            zipCodeErrorLabel.TabIndex = 35;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backButton.Location = new Point(12, 597);
            backButton.Name = "backButton";
            backButton.Size = new Size(125, 40);
            backButton.TabIndex = 36;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // usernameErrorLabel
            // 
            usernameErrorLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            usernameErrorLabel.AutoSize = true;
            usernameErrorLabel.ForeColor = Color.Red;
            usernameErrorLabel.Location = new Point(698, 577);
            usernameErrorLabel.Name = "usernameErrorLabel";
            usernameErrorLabel.Size = new Size(0, 20);
            usernameErrorLabel.TabIndex = 42;
            // 
            // passwordErrorLabel
            // 
            passwordErrorLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            passwordErrorLabel.AutoSize = true;
            passwordErrorLabel.ForeColor = Color.Red;
            passwordErrorLabel.Location = new Point(747, 555);
            passwordErrorLabel.Name = "passwordErrorLabel";
            passwordErrorLabel.Size = new Size(0, 20);
            passwordErrorLabel.TabIndex = 43;
            // 
            // selectedTestGrid
            // 
            selectedTestGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            selectedTestGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            selectedTestGrid.Location = new Point(446, 175);
            selectedTestGrid.Name = "selectedTestGrid";
            selectedTestGrid.RowHeadersWidth = 51;
            selectedTestGrid.Size = new Size(364, 314);
            selectedTestGrid.TabIndex = 44;
            // 
            // lowBox
            // 
            lowBox.Anchor = AnchorStyles.Top;
            lowBox.Location = new Point(551, 550);
            lowBox.Name = "lowBox";
            lowBox.Size = new Size(103, 27);
            lowBox.TabIndex = 45;
            // 
            // lowLabel
            // 
            lowLabel.Anchor = AnchorStyles.Top;
            lowLabel.AutoSize = true;
            lowLabel.Location = new Point(469, 553);
            lowLabel.Name = "lowLabel";
            lowLabel.Size = new Size(76, 20);
            lowLabel.TabIndex = 46;
            lowLabel.Text = "Low Value";
            // 
            // unitLabel
            // 
            unitLabel.Anchor = AnchorStyles.Top;
            unitLabel.AutoSize = true;
            unitLabel.Location = new Point(665, 553);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new Size(36, 20);
            unitLabel.TabIndex = 47;
            unitLabel.Text = "Unit";
            // 
            // unitBox
            // 
            unitBox.Anchor = AnchorStyles.Top;
            unitBox.Location = new Point(707, 550);
            unitBox.Name = "unitBox";
            unitBox.Size = new Size(103, 27);
            unitBox.TabIndex = 48;
            // 
            // selectedLable
            // 
            selectedLable.AutoSize = true;
            selectedLable.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selectedLable.Location = new Point(446, 144);
            selectedLable.Name = "selectedLable";
            selectedLable.Size = new Size(145, 28);
            selectedLable.TabIndex = 49;
            selectedLable.Text = "Selected Tests";
            // 
            // OrderTestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 642);
            Controls.Add(selectedLable);
            Controls.Add(unitBox);
            Controls.Add(unitLabel);
            Controls.Add(lowLabel);
            Controls.Add(lowBox);
            Controls.Add(selectedTestGrid);
            Controls.Add(passwordErrorLabel);
            Controls.Add(usernameErrorLabel);
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
            Controls.Add(highBox);
            Controls.Add(testNameBox);
            Controls.Add(confirmOrderButton);
            Controls.Add(highLabel);
            Controls.Add(testLabel);
            Controls.Add(testsLabel);
            Controls.Add(testSelectGrid);
            Name = "OrderTestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NurseManagement";
            ((System.ComponentModel.ISupportInitialize)testSelectGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)selectedTestGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView testSelectGrid;
        private Label testsLabel;
        private Label testLabel;
        private Label highLabel;
        private Button confirmOrderButton;
        private TextBox testNameBox;
        private TextBox highBox;
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
        private Label usernameErrorLabel;
        private Label passwordErrorLabel;
        private DataGridView selectedTestGrid;
        private TextBox lowBox;
        private Label lowLabel;
        private Label unitLabel;
        private TextBox unitBox;
        private Label selectedLable;
    }
}