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
            label2 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            resultLabel = new Label();
            datePerformedLabel = new Label();
            datePreformedPicker = new DateTimePicker();
            abnormalCheck = new CheckBox();
            loggedInUserControl2 = new LoggedInUserControl();
            ((System.ComponentModel.ISupportInitialize)testSelectGrid).BeginInit();
            SuspendLayout();
            // 
            // testSelectGrid
            // 
            testSelectGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            testSelectGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            testSelectGrid.Location = new Point(12, 175);
            testSelectGrid.Name = "testSelectGrid";
            testSelectGrid.RowHeadersWidth = 51;
            testSelectGrid.Size = new Size(798, 314);
            testSelectGrid.TabIndex = 0;
            testSelectGrid.CellClick += testSelectGrid_CellClick;
            // 
            // testsLabel
            // 
            testsLabel.AutoSize = true;
            testsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            testsLabel.Location = new Point(12, 144);
            testsLabel.Name = "testsLabel";
            testsLabel.Size = new Size(250, 28);
            testsLabel.TabIndex = 1;
            testsLabel.Text = "Select a test to view/edit";
            // 
            // testLabel
            // 
            testLabel.AutoSize = true;
            testLabel.Location = new Point(30, 542);
            testLabel.Name = "testLabel";
            testLabel.Size = new Size(79, 20);
            testLabel.TabIndex = 2;
            testLabel.Text = "Test Name";
            // 
            // highLabel
            // 
            highLabel.Anchor = AnchorStyles.Top;
            highLabel.AutoSize = true;
            highLabel.Location = new Point(273, 542);
            highLabel.Name = "highLabel";
            highLabel.Size = new Size(81, 20);
            highLabel.TabIndex = 3;
            highLabel.Text = "High Value";
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.Location = new Point(685, 658);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(125, 40);
            saveButton.TabIndex = 14;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += confirmButton_Click;
            // 
            // testNameBox
            // 
            testNameBox.Location = new Point(115, 539);
            testNameBox.Name = "testNameBox";
            testNameBox.PlaceholderText = "Please select test";
            testNameBox.Size = new Size(145, 27);
            testNameBox.TabIndex = 16;
            // 
            // highBox
            // 
            highBox.Anchor = AnchorStyles.Top;
            highBox.Location = new Point(360, 539);
            highBox.Name = "highBox";
            highBox.Size = new Size(103, 27);
            highBox.TabIndex = 17;
            // 
            // informationLabel
            // 
            informationLabel.AutoSize = true;
            informationLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            informationLabel.Location = new Point(12, 499);
            informationLabel.Name = "informationLabel";
            informationLabel.Size = new Size(169, 28);
            informationLabel.TabIndex = 25;
            informationLabel.Text = "Test Information";
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backButton.Location = new Point(12, 659);
            backButton.Name = "backButton";
            backButton.Size = new Size(125, 40);
            backButton.TabIndex = 36;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // lowBox
            // 
            lowBox.Anchor = AnchorStyles.Top;
            lowBox.Location = new Point(551, 539);
            lowBox.Name = "lowBox";
            lowBox.Size = new Size(103, 27);
            lowBox.TabIndex = 45;
            // 
            // lowLabel
            // 
            lowLabel.Anchor = AnchorStyles.Top;
            lowLabel.AutoSize = true;
            lowLabel.Location = new Point(469, 542);
            lowLabel.Name = "lowLabel";
            lowLabel.Size = new Size(76, 20);
            lowLabel.TabIndex = 46;
            lowLabel.Text = "Low Value";
            // 
            // unitLabel
            // 
            unitLabel.Anchor = AnchorStyles.Top;
            unitLabel.AutoSize = true;
            unitLabel.Location = new Point(665, 542);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new Size(36, 20);
            unitLabel.TabIndex = 47;
            unitLabel.Text = "Unit";
            // 
            // unitBox
            // 
            unitBox.Anchor = AnchorStyles.Top;
            unitBox.Location = new Point(707, 539);
            unitBox.Name = "unitBox";
            unitBox.Size = new Size(103, 27);
            unitBox.TabIndex = 48;
            // 
            // patientInfoLabel
            // 
            patientInfoLabel.AutoSize = true;
            patientInfoLabel.Location = new Point(463, 0);
            patientInfoLabel.Name = "patientInfoLabel";
            patientInfoLabel.Size = new Size(0, 20);
            patientInfoLabel.TabIndex = 52;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(496, 620);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 59;
            label2.Text = "Is Abnormal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 577);
            label3.Name = "label3";
            label3.Size = new Size(169, 28);
            label3.TabIndex = 57;
            label3.Text = "Test Information";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top;
            textBox3.Location = new Point(360, 617);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(103, 27);
            textBox3.TabIndex = 56;
            // 
            // resultLabel
            // 
            resultLabel.Anchor = AnchorStyles.Top;
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(305, 620);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(49, 20);
            resultLabel.TabIndex = 54;
            resultLabel.Text = "Result";
            // 
            // datePerformedLabel
            // 
            datePerformedLabel.AutoSize = true;
            datePerformedLabel.Location = new Point(12, 620);
            datePerformedLabel.Name = "datePerformedLabel";
            datePerformedLabel.Size = new Size(114, 20);
            datePerformedLabel.TabIndex = 53;
            datePerformedLabel.Text = "Date Performed";
            // 
            // datePreformedPicker
            // 
            datePreformedPicker.Checked = false;
            datePreformedPicker.Format = DateTimePickerFormat.Short;
            datePreformedPicker.Location = new Point(127, 615);
            datePreformedPicker.Margin = new Padding(3, 4, 3, 4);
            datePreformedPicker.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            datePreformedPicker.Name = "datePreformedPicker";
            datePreformedPicker.ShowCheckBox = true;
            datePreformedPicker.Size = new Size(140, 27);
            datePreformedPicker.TabIndex = 62;
            datePreformedPicker.Value = new DateTime(2026, 10, 10, 0, 0, 0, 0);
            // 
            // abnormalCheck
            // 
            abnormalCheck.AutoSize = true;
            abnormalCheck.Location = new Point(591, 623);
            abnormalCheck.Name = "abnormalCheck";
            abnormalCheck.Size = new Size(18, 17);
            abnormalCheck.TabIndex = 63;
            abnormalCheck.UseVisualStyleBackColor = true;
            // 
            // loggedInUserControl2
            // 
            loggedInUserControl2.Location = new Point(0, 0);
            loggedInUserControl2.Name = "loggedInUserControl2";
            loggedInUserControl2.Size = new Size(350, 169);
            loggedInUserControl2.TabIndex = 64;
            // 
            // TestEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 704);
            Controls.Add(loggedInUserControl2);
            Controls.Add(abnormalCheck);
            Controls.Add(datePreformedPicker);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(textBox3);
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
            Name = "TestEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View/Edit Tests";
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
        private LoggedInUserControl loggedInUserControl1;
        private Button backButton;
        private TextBox lowBox;
        private Label lowLabel;
        private Label unitLabel;
        private TextBox unitBox;
        private Label patientInfoLabel;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Label resultLabel;
        private Label datePerformedLabel;
        private DateTimePicker datePreformedPicker;
        private CheckBox abnormalCheck;
        private LoggedInUserControl loggedInUserControl2;
    }
}