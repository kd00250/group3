namespace HealthcareSystem.View
{
    partial class TestEditForm
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
            saveButton = new Button();
            testNameBox = new TextBox();
            highBox = new TextBox();
            informationLabel = new Label();
            backButton = new Button();
            lowBox = new TextBox();
            lowLabel = new Label();
            unitLabel = new Label();
            unitBox = new TextBox();
            patientInfoLabel = new Label();
            label3 = new Label();
            resultBox = new TextBox();
            resultLabel = new Label();
            datePerformedLabel = new Label();
            datePreformedPicker = new DateTimePicker();
            resultErrorLabel = new Label();
            abnormalCheckbox = new CheckBox();
            abnormalLabel = new Label();
            loggedInUserControl1 = new LoggedInUserControl();
            ((System.ComponentModel.ISupportInitialize)testSelectGrid).BeginInit();
            SuspendLayout();
            // 
            // testSelectGrid
            // 
            testSelectGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            testSelectGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            testSelectGrid.Location = new Point(10, 131);
            testSelectGrid.Margin = new Padding(3, 2, 3, 2);
            testSelectGrid.Name = "testSelectGrid";
            testSelectGrid.RowHeadersWidth = 51;
            testSelectGrid.Size = new Size(698, 236);
            testSelectGrid.TabIndex = 0;
            testSelectGrid.CellClick += testSelectGrid_CellClick;
            // 
            // testsLabel
            // 
            testsLabel.AutoSize = true;
            testsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            testsLabel.Location = new Point(10, 108);
            testsLabel.Name = "testsLabel";
            testsLabel.Size = new Size(198, 21);
            testsLabel.TabIndex = 1;
            testsLabel.Text = "Select a test to view/edit";
            // 
            // testLabel
            // 
            testLabel.AutoSize = true;
            testLabel.Location = new Point(26, 406);
            testLabel.Name = "testLabel";
            testLabel.Size = new Size(63, 15);
            testLabel.TabIndex = 2;
            testLabel.Text = "Test Name";
            // 
            // highLabel
            // 
            highLabel.Anchor = AnchorStyles.Top;
            highLabel.AutoSize = true;
            highLabel.Location = new Point(239, 406);
            highLabel.Name = "highLabel";
            highLabel.Size = new Size(64, 15);
            highLabel.TabIndex = 3;
            highLabel.Text = "High Value";
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.Location = new Point(599, 494);
            saveButton.Margin = new Padding(3, 2, 3, 2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(109, 30);
            saveButton.TabIndex = 14;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // testNameBox
            // 
            testNameBox.Location = new Point(101, 404);
            testNameBox.Margin = new Padding(3, 2, 3, 2);
            testNameBox.Name = "testNameBox";
            testNameBox.PlaceholderText = "Please select test";
            testNameBox.Size = new Size(127, 23);
            testNameBox.TabIndex = 16;
            // 
            // highBox
            // 
            highBox.Anchor = AnchorStyles.Top;
            highBox.Location = new Point(315, 404);
            highBox.Margin = new Padding(3, 2, 3, 2);
            highBox.Name = "highBox";
            highBox.Size = new Size(91, 23);
            highBox.TabIndex = 17;
            // 
            // informationLabel
            // 
            informationLabel.AutoSize = true;
            informationLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            informationLabel.Location = new Point(10, 374);
            informationLabel.Name = "informationLabel";
            informationLabel.Size = new Size(136, 21);
            informationLabel.TabIndex = 25;
            informationLabel.Text = "Test Information";
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backButton.Location = new Point(10, 494);
            backButton.Margin = new Padding(3, 2, 3, 2);
            backButton.Name = "backButton";
            backButton.Size = new Size(109, 30);
            backButton.TabIndex = 36;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // lowBox
            // 
            lowBox.Anchor = AnchorStyles.Top;
            lowBox.Location = new Point(482, 404);
            lowBox.Margin = new Padding(3, 2, 3, 2);
            lowBox.Name = "lowBox";
            lowBox.Size = new Size(91, 23);
            lowBox.TabIndex = 45;
            // 
            // lowLabel
            // 
            lowLabel.Anchor = AnchorStyles.Top;
            lowLabel.AutoSize = true;
            lowLabel.Location = new Point(410, 406);
            lowLabel.Name = "lowLabel";
            lowLabel.Size = new Size(60, 15);
            lowLabel.TabIndex = 46;
            lowLabel.Text = "Low Value";
            // 
            // unitLabel
            // 
            unitLabel.Anchor = AnchorStyles.Top;
            unitLabel.AutoSize = true;
            unitLabel.Location = new Point(582, 406);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new Size(29, 15);
            unitLabel.TabIndex = 47;
            unitLabel.Text = "Unit";
            // 
            // unitBox
            // 
            unitBox.Anchor = AnchorStyles.Top;
            unitBox.Location = new Point(619, 404);
            unitBox.Margin = new Padding(3, 2, 3, 2);
            unitBox.Name = "unitBox";
            unitBox.Size = new Size(91, 23);
            unitBox.TabIndex = 48;
            // 
            // patientInfoLabel
            // 
            patientInfoLabel.AutoSize = true;
            patientInfoLabel.Location = new Point(405, 0);
            patientInfoLabel.Name = "patientInfoLabel";
            patientInfoLabel.Size = new Size(0, 15);
            patientInfoLabel.TabIndex = 52;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 433);
            label3.Name = "label3";
            label3.Size = new Size(136, 21);
            label3.TabIndex = 57;
            label3.Text = "Test Information";
            // 
            // resultBox
            // 
            resultBox.Anchor = AnchorStyles.Top;
            resultBox.Location = new Point(315, 462);
            resultBox.Margin = new Padding(3, 2, 3, 2);
            resultBox.Name = "resultBox";
            resultBox.Size = new Size(258, 23);
            resultBox.TabIndex = 56;
            resultBox.TextChanged += resultBox_TextChanged;
            // 
            // resultLabel
            // 
            resultLabel.Anchor = AnchorStyles.Top;
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(267, 465);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(39, 15);
            resultLabel.TabIndex = 54;
            resultLabel.Text = "Result";
            // 
            // datePerformedLabel
            // 
            datePerformedLabel.AutoSize = true;
            datePerformedLabel.Location = new Point(10, 465);
            datePerformedLabel.Name = "datePerformedLabel";
            datePerformedLabel.Size = new Size(90, 15);
            datePerformedLabel.TabIndex = 53;
            datePerformedLabel.Text = "Date Performed";
            // 
            // datePreformedPicker
            // 
            datePreformedPicker.Checked = false;
            datePreformedPicker.Format = DateTimePickerFormat.Short;
            datePreformedPicker.Location = new Point(111, 461);
            datePreformedPicker.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            datePreformedPicker.Name = "datePreformedPicker";
            datePreformedPicker.ShowCheckBox = true;
            datePreformedPicker.Size = new Size(123, 23);
            datePreformedPicker.TabIndex = 62;
            datePreformedPicker.Value = new DateTime(2026, 10, 10, 0, 0, 0, 0);
            // 
            // resultErrorLabel
            // 
            resultErrorLabel.AutoSize = true;
            resultErrorLabel.ForeColor = Color.Red;
            resultErrorLabel.Location = new Point(267, 494);
            resultErrorLabel.Name = "resultErrorLabel";
            resultErrorLabel.Size = new Size(0, 15);
            resultErrorLabel.TabIndex = 65;
            // 
            // abnormalCheckbox
            // 
            abnormalCheckbox.AutoSize = true;
            abnormalCheckbox.Location = new Point(680, 468);
            abnormalCheckbox.Margin = new Padding(3, 2, 3, 2);
            abnormalCheckbox.Name = "abnormalCheckbox";
            abnormalCheckbox.Size = new Size(15, 14);
            abnormalCheckbox.TabIndex = 66;
            abnormalCheckbox.UseVisualStyleBackColor = true;
            // 
            // abnormalLabel
            // 
            abnormalLabel.Anchor = AnchorStyles.Top;
            abnormalLabel.AutoSize = true;
            abnormalLabel.Location = new Point(591, 466);
            abnormalLabel.Name = "abnormalLabel";
            abnormalLabel.Size = new Size(76, 15);
            abnormalLabel.TabIndex = 67;
            abnormalLabel.Text = "Is Abnormal?";
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(0, 0);
            loggedInUserControl1.Margin = new Padding(3, 2, 3, 2);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(306, 127);
            loggedInUserControl1.TabIndex = 68;
            // 
            // TestEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 528);
            Controls.Add(loggedInUserControl1);
            Controls.Add(abnormalLabel);
            Controls.Add(abnormalCheckbox);
            Controls.Add(resultErrorLabel);
            Controls.Add(datePreformedPicker);
            Controls.Add(label3);
            Controls.Add(resultBox);
            Controls.Add(resultLabel);
            Controls.Add(datePerformedLabel);
            Controls.Add(patientInfoLabel);
            Controls.Add(unitBox);
            Controls.Add(unitLabel);
            Controls.Add(lowLabel);
            Controls.Add(lowBox);
            Controls.Add(backButton);
            Controls.Add(informationLabel);
            Controls.Add(highBox);
            Controls.Add(testNameBox);
            Controls.Add(saveButton);
            Controls.Add(highLabel);
            Controls.Add(testLabel);
            Controls.Add(testsLabel);
            Controls.Add(testSelectGrid);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TestEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Healthcare System - View/Edit Tests";
            Shown += TestEditForm_Shown;
            ((System.ComponentModel.ISupportInitialize)testSelectGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView testSelectGrid;
        private Label testsLabel;
        private Label testLabel;
        private Label highLabel;
        private Button saveButton;
        private TextBox testNameBox;
        private TextBox highBox;
        private Label informationLabel;
        private Button backButton;
        private TextBox lowBox;
        private Label lowLabel;
        private Label unitLabel;
        private TextBox unitBox;
        private Label patientInfoLabel;
        private Label label3;
        private TextBox resultBox;
        private Label resultLabel;
        private Label datePerformedLabel;
        private DateTimePicker datePreformedPicker;
        private Label resultErrorLabel;
        private CheckBox abnormalCheckbox;
        private Label abnormalLabel;
        private LoggedInUserControl loggedInUserControl1;
    }
}