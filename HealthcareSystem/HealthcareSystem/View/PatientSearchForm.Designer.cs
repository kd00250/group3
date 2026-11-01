namespace HealthcareSystem.View
{
    partial class PatientSearchForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            dateOfBirthPicker = new DateTimePicker();
            searchButton = new Button();
            clearButton = new Button();
            resultsGridView = new DataGridView();
            errorLabel = new Label();
            resultCountLabel = new Label();
            selectButton = new Button();
            label4 = new Label();
            backButton = new Button();
            ((System.ComponentModel.ISupportInitialize)resultsGridView).BeginInit();
            SuspendLayout();
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(-1, 1);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(280, 135);
            loggedInUserControl1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(200, 45);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 1;
            label1.Text = "First Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 81);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 2;
            label2.Text = "Last Name :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(200, 116);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 3;
            label3.Text = "Date of Birth :";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(297, 40);
            firstNameTextBox.Margin = new Padding(3, 4, 3, 4);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(124, 27);
            firstNameTextBox.TabIndex = 4;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(297, 76);
            lastNameTextBox.Margin = new Padding(3, 4, 3, 4);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(124, 27);
            lastNameTextBox.TabIndex = 5;
            // 
            // dateOfBirthPicker
            // 
            dateOfBirthPicker.Checked = false;
            dateOfBirthPicker.Format = DateTimePickerFormat.Short;
            dateOfBirthPicker.Location = new Point(297, 111);
            dateOfBirthPicker.Margin = new Padding(3, 4, 3, 4);
            dateOfBirthPicker.MaxDate = new DateTime(2026, 10, 10, 0, 0, 0, 0);
            dateOfBirthPicker.Name = "dateOfBirthPicker";
            dateOfBirthPicker.ShowCheckBox = true;
            dateOfBirthPicker.Size = new Size(140, 27);
            dateOfBirthPicker.TabIndex = 6;
            dateOfBirthPicker.Value = new DateTime(2026, 10, 10, 0, 0, 0, 0);
            // 
            // searchButton
            // 
            searchButton.Location = new Point(200, 152);
            searchButton.Margin = new Padding(3, 4, 3, 4);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(86, 31);
            searchButton.TabIndex = 7;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(447, 152);
            clearButton.Margin = new Padding(3, 4, 3, 4);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(79, 31);
            clearButton.TabIndex = 8;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // resultsGridView
            // 
            resultsGridView.AllowUserToAddRows = false;
            resultsGridView.AllowUserToDeleteRows = false;
            resultsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsGridView.Location = new Point(200, 215);
            resultsGridView.Margin = new Padding(3, 4, 3, 4);
            resultsGridView.MultiSelect = false;
            resultsGridView.Name = "resultsGridView";
            resultsGridView.ReadOnly = true;
            resultsGridView.RowHeadersWidth = 51;
            resultsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            resultsGridView.Size = new Size(854, 352);
            resultsGridView.TabIndex = 9;
            resultsGridView.CellDoubleClick += resultsGridView_CellDoubleClick;
            resultsGridView.SelectionChanged += resultsGridView_SelectionChanged;
            // 
            // errorLabel
            // 
            errorLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(203, 569);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 20);
            errorLabel.TabIndex = 10;
            // 
            // resultCountLabel
            // 
            resultCountLabel.AutoSize = true;
            resultCountLabel.Location = new Point(205, 187);
            resultCountLabel.Name = "resultCountLabel";
            resultCountLabel.Size = new Size(0, 20);
            resultCountLabel.TabIndex = 11;
            // 
            // selectButton
            // 
            selectButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            selectButton.Enabled = false;
            selectButton.Location = new Point(968, 569);
            selectButton.Margin = new Padding(3, 4, 3, 4);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(86, 31);
            selectButton.TabIndex = 12;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += selectButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(200, 12);
            label4.Name = "label4";
            label4.Size = new Size(527, 20);
            label4.TabIndex = 13;
            label4.Text = "Select a patient to edit their information, manage appointments, or view visits.";
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backButton.Location = new Point(-1, 569);
            backButton.Margin = new Padding(3, 4, 3, 4);
            backButton.Name = "backButton";
            backButton.Size = new Size(86, 31);
            backButton.TabIndex = 14;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // PatientSearchForm
            // 
            AcceptButton = searchButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(1067, 601);
            Controls.Add(backButton);
            Controls.Add(label4);
            Controls.Add(selectButton);
            Controls.Add(resultCountLabel);
            Controls.Add(errorLabel);
            Controls.Add(resultsGridView);
            Controls.Add(clearButton);
            Controls.Add(searchButton);
            Controls.Add(dateOfBirthPicker);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(loggedInUserControl1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1083, 638);
            Name = "PatientSearchForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Healthcare System - Patient Search";
            ((System.ComponentModel.ISupportInitialize)resultsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LoggedInUserControl loggedInUserControl1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private DateTimePicker dateOfBirthPicker;
        private Button searchButton;
        private Button clearButton;
        private DataGridView resultsGridView;
        private Label errorLabel;
        private Label resultCountLabel;
        private Button selectButton;
        private Label label4;
        private Button backButton;
    }
}