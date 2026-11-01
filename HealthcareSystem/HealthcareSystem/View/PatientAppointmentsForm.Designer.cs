namespace HealthcareSystem.View
{
    partial class PatientAppointmentsForm
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
            patientLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            upcomingGridView = new DataGridView();
            pastGridView = new DataGridView();
            selectButton = new Button();
            backButton = new Button();
            upcomingEmptyLabel = new Label();
            pastEmptyLabel = new Label();
            errorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)upcomingGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pastGridView).BeginInit();
            SuspendLayout();
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(0, 0);
            loggedInUserControl1.Margin = new Padding(3, 2, 3, 2);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(245, 101);
            loggedInUserControl1.TabIndex = 0;
            // 
            // patientLabel
            // 
            patientLabel.AutoSize = true;
            patientLabel.Location = new Point(509, 0);
            patientLabel.Name = "patientLabel";
            patientLabel.Size = new Size(85, 15);
            patientLabel.TabIndex = 1;
            patientLabel.Text = "PATIENTLABEL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 73);
            label1.Name = "label1";
            label1.Size = new Size(151, 15);
            label1.TabIndex = 2;
            label1.Text = "Upcoming Appointments : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(432, 73);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 3;
            label2.Text = "Past Appointments : ";
            // 
            // upcomingGridView
            // 
            upcomingGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            upcomingGridView.Location = new Point(12, 91);
            upcomingGridView.Name = "upcomingGridView";
            upcomingGridView.Size = new Size(400, 245);
            upcomingGridView.TabIndex = 4;
            // 
            // pastGridView
            // 
            pastGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            pastGridView.Location = new Point(432, 91);
            pastGridView.Name = "pastGridView";
            pastGridView.Size = new Size(400, 245);
            pastGridView.TabIndex = 5;
            // 
            // selectButton
            // 
            selectButton.Location = new Point(757, 376);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(75, 23);
            selectButton.TabIndex = 6;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            backButton.Location = new Point(12, 376);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 23);
            backButton.TabIndex = 7;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            // 
            // upcomingEmptyLabel
            // 
            upcomingEmptyLabel.AutoSize = true;
            upcomingEmptyLabel.Location = new Point(12, 339);
            upcomingEmptyLabel.Name = "upcomingEmptyLabel";
            upcomingEmptyLabel.Size = new Size(141, 15);
            upcomingEmptyLabel.TabIndex = 8;
            upcomingEmptyLabel.Text = "UPCOMINGEMPTYLABEL";
            // 
            // pastEmptyLabel
            // 
            pastEmptyLabel.AutoSize = true;
            pastEmptyLabel.Location = new Point(432, 339);
            pastEmptyLabel.Name = "pastEmptyLabel";
            pastEmptyLabel.Size = new Size(72, 15);
            pastEmptyLabel.TabIndex = 9;
            pastEmptyLabel.Text = "PASTEMPTY";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(12, 358);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(43, 15);
            errorLabel.TabIndex = 10;
            errorLabel.Text = "ERROR";
            // 
            // PatientAppointmentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(843, 400);
            Controls.Add(errorLabel);
            Controls.Add(pastEmptyLabel);
            Controls.Add(upcomingEmptyLabel);
            Controls.Add(backButton);
            Controls.Add(selectButton);
            Controls.Add(pastGridView);
            Controls.Add(upcomingGridView);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(patientLabel);
            Controls.Add(loggedInUserControl1);
            Name = "PatientAppointmentsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Healthcare System - Appointments";
            ((System.ComponentModel.ISupportInitialize)upcomingGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pastGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LoggedInUserControl loggedInUserControl1;
        private Label patientLabel;
        private Label label1;
        private Label label2;
        private DataGridView upcomingGridView;
        private DataGridView pastGridView;
        private Button selectButton;
        private Button backButton;
        private Label upcomingEmptyLabel;
        private Label pastEmptyLabel;
        private Label errorLabel;
    }
}