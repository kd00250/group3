namespace HealthcareSystem.View
{
    partial class StartVisitForm
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            startVisitButton = new Button();
            backButton = new Button();
            loggedInUserControl1 = new LoggedInUserControl();
            patientLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 129);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(759, 170);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1, 112);
            label1.Name = "label1";
            label1.Size = new Size(169, 15);
            label1.TabIndex = 1;
            label1.Text = "Please select an appointment";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(323, 7);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 2;
            label2.Text = "Start Visit";
            // 
            // startVisitButton
            // 
            startVisitButton.Location = new Point(677, 346);
            startVisitButton.Margin = new Padding(3, 2, 3, 2);
            startVisitButton.Name = "startVisitButton";
            startVisitButton.Size = new Size(82, 22);
            startVisitButton.TabIndex = 3;
            startVisitButton.Text = "Start Visit";
            startVisitButton.UseVisualStyleBackColor = true;
            startVisitButton.Click += startVisitButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(1, 346);
            backButton.Margin = new Padding(3, 2, 3, 2);
            backButton.Name = "backButton";
            backButton.Size = new Size(82, 22);
            backButton.TabIndex = 4;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(1, -1);
            loggedInUserControl1.Margin = new Padding(3, 2, 3, 2);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(237, 101);
            loggedInUserControl1.TabIndex = 5;
            // 
            // patientLabel
            // 
            patientLabel.AutoSize = true;
            patientLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            patientLabel.Location = new Point(223, 42);
            patientLabel.Name = "patientLabel";
            patientLabel.Size = new Size(0, 15);
            patientLabel.TabIndex = 6;
            // 
            // StartVisitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 377);
            Controls.Add(patientLabel);
            Controls.Add(loggedInUserControl1);
            Controls.Add(backButton);
            Controls.Add(startVisitButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "StartVisitForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Healthcare System - Start Visit";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Button startVisitButton;
        private Button backButton;
        private LoggedInUserControl loggedInUserControl1;
        private Label patientLabel;
    }
}