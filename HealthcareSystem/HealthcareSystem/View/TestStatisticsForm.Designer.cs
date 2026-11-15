namespace HealthcareSystem.View
{
    partial class TestStatisticsForm
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
            titleLabel = new Label();
            startDateLabel = new Label();
            endDateLabel = new Label();
            startDatePicker = new DateTimePicker();
            endDatePicker = new DateTimePicker();
            showStatisticsButton = new Button();
            dateRangeErrorLabel = new Label();
            statisticsDataGridView = new DataGridView();
            resultCountLabel = new Label();
            errorLabel = new Label();
            backButton = new Button();
            ((System.ComponentModel.ISupportInitialize)statisticsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(-2, 0);
            loggedInUserControl1.Margin = new Padding(3, 2, 3, 2);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(245, 101);
            loggedInUserControl1.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(30, 71);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(128, 15);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Most Performed Tests :";
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.Location = new Point(30, 104);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new Size(66, 15);
            startDateLabel.TabIndex = 2;
            startDateLabel.Text = "Start date : ";
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.Location = new Point(217, 104);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new Size(62, 15);
            endDateLabel.TabIndex = 3;
            endDateLabel.Text = "End date : ";
            // 
            // startDatePicker
            // 
            startDatePicker.Format = DateTimePickerFormat.Short;
            startDatePicker.Location = new Point(102, 100);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(96, 23);
            startDatePicker.TabIndex = 4;
            // 
            // endDatePicker
            // 
            endDatePicker.Format = DateTimePickerFormat.Short;
            endDatePicker.Location = new Point(285, 100);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(96, 23);
            endDatePicker.TabIndex = 5;
            // 
            // showStatisticsButton
            // 
            showStatisticsButton.Location = new Point(30, 147);
            showStatisticsButton.Name = "showStatisticsButton";
            showStatisticsButton.Size = new Size(96, 23);
            showStatisticsButton.TabIndex = 6;
            showStatisticsButton.Text = "Show Statistics";
            showStatisticsButton.UseVisualStyleBackColor = true;
            showStatisticsButton.Click += showStatisticsButton_Click;
            // 
            // dateRangeErrorLabel
            // 
            dateRangeErrorLabel.AutoSize = true;
            dateRangeErrorLabel.ForeColor = Color.Red;
            dateRangeErrorLabel.Location = new Point(30, 129);
            dateRangeErrorLabel.Name = "dateRangeErrorLabel";
            dateRangeErrorLabel.Size = new Size(0, 15);
            dateRangeErrorLabel.TabIndex = 7;
            dateRangeErrorLabel.Visible = false;
            // 
            // statisticsDataGridView
            // 
            statisticsDataGridView.AllowUserToAddRows = false;
            statisticsDataGridView.AllowUserToDeleteRows = false;
            statisticsDataGridView.AllowUserToResizeRows = false;
            statisticsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            statisticsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            statisticsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            statisticsDataGridView.Location = new Point(30, 179);
            statisticsDataGridView.MultiSelect = false;
            statisticsDataGridView.Name = "statisticsDataGridView";
            statisticsDataGridView.ReadOnly = true;
            statisticsDataGridView.RowHeadersVisible = false;
            statisticsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            statisticsDataGridView.Size = new Size(736, 247);
            statisticsDataGridView.TabIndex = 8;
            // 
            // resultCountLabel
            // 
            resultCountLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            resultCountLabel.AutoSize = true;
            resultCountLabel.Location = new Point(28, 429);
            resultCountLabel.Name = "resultCountLabel";
            resultCountLabel.Size = new Size(0, 15);
            resultCountLabel.TabIndex = 9;
            // 
            // errorLabel
            // 
            errorLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(28, 444);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 15);
            errorLabel.TabIndex = 10;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backButton.Location = new Point(30, 471);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 23);
            backButton.TabIndex = 11;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // TestStatisticsForm
            // 
            AcceptButton = showStatisticsButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(800, 494);
            Controls.Add(backButton);
            Controls.Add(errorLabel);
            Controls.Add(resultCountLabel);
            Controls.Add(statisticsDataGridView);
            Controls.Add(dateRangeErrorLabel);
            Controls.Add(showStatisticsButton);
            Controls.Add(endDatePicker);
            Controls.Add(startDatePicker);
            Controls.Add(endDateLabel);
            Controls.Add(startDateLabel);
            Controls.Add(titleLabel);
            Controls.Add(loggedInUserControl1);
            Name = "TestStatisticsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Healthcare System - Test Statistics";
            ((System.ComponentModel.ISupportInitialize)statisticsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LoggedInUserControl loggedInUserControl1;
        private Label titleLabel;
        private Label startDateLabel;
        private Label endDateLabel;
        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private Button showStatisticsButton;
        private Label dateRangeErrorLabel;
        private DataGridView statisticsDataGridView;
        private Label resultCountLabel;
        private Label errorLabel;
        private Button backButton;
    }
}