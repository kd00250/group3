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
            informationLabel = new Label();
            backButton = new Button();
            selectedTestGrid = new DataGridView();
            lowBox = new TextBox();
            lowLabel = new Label();
            unitLabel = new Label();
            unitBox = new TextBox();
            selectedLable = new Label();
            addButton = new Button();
            removeButton = new Button();
            patientInfoLabel = new Label();
            loggedInUserControl2 = new LoggedInUserControl();
            ((System.ComponentModel.ISupportInitialize)testSelectGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectedTestGrid).BeginInit();
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
            testSelectGrid.Size = new Size(299, 236);
            testSelectGrid.TabIndex = 0;
            testSelectGrid.CellClick += testSelectGrid_CellClick;
            // 
            // testsLabel
            // 
            testsLabel.AutoSize = true;
            testsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            testsLabel.Location = new Point(10, 108);
            testsLabel.Name = "testsLabel";
            testsLabel.Size = new Size(123, 21);
            testsLabel.TabIndex = 1;
            testsLabel.Text = "Available Tests";
            // 
            // testLabel
            // 
            testLabel.AutoSize = true;
            testLabel.Location = new Point(26, 452);
            testLabel.Name = "testLabel";
            testLabel.Size = new Size(63, 15);
            testLabel.TabIndex = 2;
            testLabel.Text = "Test Name";
            // 
            // highLabel
            // 
            highLabel.Anchor = AnchorStyles.Top;
            highLabel.AutoSize = true;
            highLabel.Location = new Point(239, 452);
            highLabel.Name = "highLabel";
            highLabel.Size = new Size(64, 15);
            highLabel.TabIndex = 3;
            highLabel.Text = "High Value";
            // 
            // confirmOrderButton
            // 
            confirmOrderButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            confirmOrderButton.Location = new Point(599, 494);
            confirmOrderButton.Margin = new Padding(3, 2, 3, 2);
            confirmOrderButton.Name = "confirmOrderButton";
            confirmOrderButton.Size = new Size(109, 30);
            confirmOrderButton.TabIndex = 14;
            confirmOrderButton.Text = "Confirm";
            confirmOrderButton.UseVisualStyleBackColor = true;
            confirmOrderButton.Click += confirmButton_Click;
            // 
            // testNameBox
            // 
            testNameBox.Location = new Point(101, 449);
            testNameBox.Margin = new Padding(3, 2, 3, 2);
            testNameBox.Name = "testNameBox";
            testNameBox.PlaceholderText = "Please select test";
            testNameBox.Size = new Size(127, 23);
            testNameBox.TabIndex = 16;
            // 
            // highBox
            // 
            highBox.Anchor = AnchorStyles.Top;
            highBox.Location = new Point(315, 449);
            highBox.Margin = new Padding(3, 2, 3, 2);
            highBox.Name = "highBox";
            highBox.Size = new Size(91, 23);
            highBox.TabIndex = 17;
            // 
            // informationLabel
            // 
            informationLabel.AutoSize = true;
            informationLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            informationLabel.Location = new Point(10, 419);
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
            // selectedTestGrid
            // 
            selectedTestGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            selectedTestGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            selectedTestGrid.Location = new Point(390, 131);
            selectedTestGrid.Margin = new Padding(3, 2, 3, 2);
            selectedTestGrid.Name = "selectedTestGrid";
            selectedTestGrid.RowHeadersWidth = 51;
            selectedTestGrid.Size = new Size(318, 236);
            selectedTestGrid.TabIndex = 44;
            // 
            // lowBox
            // 
            lowBox.Anchor = AnchorStyles.Top;
            lowBox.Location = new Point(482, 449);
            lowBox.Margin = new Padding(3, 2, 3, 2);
            lowBox.Name = "lowBox";
            lowBox.Size = new Size(91, 23);
            lowBox.TabIndex = 45;
            // 
            // lowLabel
            // 
            lowLabel.Anchor = AnchorStyles.Top;
            lowLabel.AutoSize = true;
            lowLabel.Location = new Point(410, 452);
            lowLabel.Name = "lowLabel";
            lowLabel.Size = new Size(60, 15);
            lowLabel.TabIndex = 46;
            lowLabel.Text = "Low Value";
            // 
            // unitLabel
            // 
            unitLabel.Anchor = AnchorStyles.Top;
            unitLabel.AutoSize = true;
            unitLabel.Location = new Point(582, 452);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new Size(29, 15);
            unitLabel.TabIndex = 47;
            unitLabel.Text = "Unit";
            // 
            // unitBox
            // 
            unitBox.Anchor = AnchorStyles.Top;
            unitBox.Location = new Point(619, 449);
            unitBox.Margin = new Padding(3, 2, 3, 2);
            unitBox.Name = "unitBox";
            unitBox.Size = new Size(91, 23);
            unitBox.TabIndex = 48;
            // 
            // selectedLable
            // 
            selectedLable.AutoSize = true;
            selectedLable.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selectedLable.Location = new Point(390, 108);
            selectedLable.Name = "selectedLable";
            selectedLable.Size = new Size(116, 21);
            selectedLable.TabIndex = 49;
            selectedLable.Text = "Selected Tests";
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addButton.Location = new Point(10, 371);
            addButton.Margin = new Padding(3, 2, 3, 2);
            addButton.Name = "addButton";
            addButton.Size = new Size(109, 30);
            addButton.TabIndex = 50;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // removeButton
            // 
            removeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            removeButton.Location = new Point(390, 371);
            removeButton.Margin = new Padding(3, 2, 3, 2);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(109, 30);
            removeButton.TabIndex = 51;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // patientInfoLabel
            // 
            patientInfoLabel.AutoSize = true;
            patientInfoLabel.Location = new Point(405, 0);
            patientInfoLabel.Name = "patientInfoLabel";
            patientInfoLabel.Size = new Size(0, 15);
            patientInfoLabel.TabIndex = 52;
            // 
            // loggedInUserControl2
            // 
            loggedInUserControl2.Location = new Point(0, 0);
            loggedInUserControl2.Margin = new Padding(3, 2, 3, 2);
            loggedInUserControl2.Name = "loggedInUserControl2";
            loggedInUserControl2.Size = new Size(306, 106);
            loggedInUserControl2.TabIndex = 53;
            // 
            // OrderTestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(759, 528);
            Controls.Add(loggedInUserControl2);
            Controls.Add(patientInfoLabel);
            Controls.Add(removeButton);
            Controls.Add(addButton);
            Controls.Add(selectedLable);
            Controls.Add(unitBox);
            Controls.Add(unitLabel);
            Controls.Add(lowLabel);
            Controls.Add(lowBox);
            Controls.Add(selectedTestGrid);
            Controls.Add(backButton);
            Controls.Add(informationLabel);
            Controls.Add(highBox);
            Controls.Add(testNameBox);
            Controls.Add(confirmOrderButton);
            Controls.Add(highLabel);
            Controls.Add(testLabel);
            Controls.Add(testsLabel);
            Controls.Add(testSelectGrid);
            Margin = new Padding(3, 2, 3, 2);
            Name = "OrderTestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Healthcare System - Order Tests";
            Shown += onOrderTest_Shown;
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
        private Label informationLabel;
        private Button backButton;
        private DataGridView selectedTestGrid;
        private TextBox lowBox;
        private Label lowLabel;
        private Label unitLabel;
        private TextBox unitBox;
        private Label selectedLable;
        private Button addButton;
        private Button removeButton;
        private Label patientInfoLabel;
        private LoggedInUserControl loggedInUserControl2;
    }
}