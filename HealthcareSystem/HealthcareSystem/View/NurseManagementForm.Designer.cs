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
            label3.Location = new Point(741, 582);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 3;
            label3.Text = "Last Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(74, 668);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 4;
            label4.Text = "Date of Birth";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(741, 668);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 5;
            label5.Text = "Gender";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(74, 739);
            label6.Name = "label6";
            label6.Size = new Size(105, 20);
            label6.TabIndex = 6;
            label6.Text = "Street Address";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(741, 739);
            label7.Name = "label7";
            label7.Size = new Size(34, 20);
            label7.TabIndex = 7;
            label7.Text = "City";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(74, 808);
            label8.Name = "label8";
            label8.Size = new Size(43, 20);
            label8.TabIndex = 8;
            label8.Text = "State";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(741, 808);
            label9.Name = "label9";
            label9.Size = new Size(69, 20);
            label9.TabIndex = 9;
            label9.Text = "ZIP Code";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(74, 888);
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
            firstNameTextBox.Size = new Size(125, 27);
            firstNameTextBox.TabIndex = 16;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(741, 605);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.PlaceholderText = "Enter Last Name";
            lastNameTextBox.Size = new Size(125, 27);
            lastNameTextBox.TabIndex = 17;
            // 
            // streetAddressTextBox
            // 
            streetAddressTextBox.Location = new Point(74, 762);
            streetAddressTextBox.Name = "streetAddressTextBox";
            streetAddressTextBox.PlaceholderText = "ex: 14 Peach St";
            streetAddressTextBox.Size = new Size(125, 27);
            streetAddressTextBox.TabIndex = 18;
            // 
            // cityTextBox
            // 
            cityTextBox.Location = new Point(741, 762);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.PlaceholderText = "ex: Atlanta";
            cityTextBox.Size = new Size(125, 27);
            cityTextBox.TabIndex = 19;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(73, 911);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.PlaceholderText = "Enter Phone Number";
            phoneNumberTextBox.Size = new Size(151, 27);
            phoneNumberTextBox.TabIndex = 20;
            // 
            // zipCodeTextBox
            // 
            zipCodeTextBox.Location = new Point(741, 831);
            zipCodeTextBox.Name = "zipCodeTextBox";
            zipCodeTextBox.Size = new Size(125, 27);
            zipCodeTextBox.TabIndex = 21;
            // 
            // genderComboBox
            // 
            genderComboBox.FormattingEnabled = true;
            genderComboBox.Location = new Point(741, 691);
            genderComboBox.Name = "genderComboBox";
            genderComboBox.Size = new Size(151, 28);
            genderComboBox.TabIndex = 22;
            // 
            // stateComboBox
            // 
            stateComboBox.FormattingEnabled = true;
            stateComboBox.Location = new Point(73, 831);
            stateComboBox.Name = "stateComboBox";
            stateComboBox.Size = new Size(151, 28);
            stateComboBox.TabIndex = 23;
            // 
            // dateOfBirthDatePicker
            // 
            dateOfBirthDatePicker.Location = new Point(74, 691);
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
            // NurseManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1365, 1107);
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
    }
}