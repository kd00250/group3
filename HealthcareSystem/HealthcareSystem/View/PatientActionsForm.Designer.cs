namespace HealthcareSystem.View
{
    partial class PatientActionsForm
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
            editPatientButton = new Button();
            viewAppointmentsButton = new Button();
            makeAppointmentButton = new Button();
            viewVisitsButton = new Button();
            backButton = new Button();
            startNewVisitButton = new Button();
            SuspendLayout();
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(0, 0);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(280, 135);
            loggedInUserControl1.TabIndex = 0;
            // 
            // editPatientButton
            // 
            editPatientButton.Location = new Point(367, 45);
            editPatientButton.Margin = new Padding(3, 4, 3, 4);
            editPatientButton.Name = "editPatientButton";
            editPatientButton.Size = new Size(178, 79);
            editPatientButton.TabIndex = 1;
            editPatientButton.Text = "Edit Patient Information";
            editPatientButton.UseVisualStyleBackColor = true;
            editPatientButton.Click += editPatientButton_Click;
            // 
            // viewAppointmentsButton
            // 
            viewAppointmentsButton.Location = new Point(367, 156);
            viewAppointmentsButton.Margin = new Padding(3, 4, 3, 4);
            viewAppointmentsButton.Name = "viewAppointmentsButton";
            viewAppointmentsButton.Size = new Size(178, 79);
            viewAppointmentsButton.TabIndex = 2;
            viewAppointmentsButton.Text = "View Appointments";
            viewAppointmentsButton.UseVisualStyleBackColor = true;
            viewAppointmentsButton.Click += viewAppointmentsButton_Click;
            // 
            // makeAppointmentButton
            // 
            makeAppointmentButton.Location = new Point(367, 261);
            makeAppointmentButton.Margin = new Padding(3, 4, 3, 4);
            makeAppointmentButton.Name = "makeAppointmentButton";
            makeAppointmentButton.Size = new Size(178, 79);
            makeAppointmentButton.TabIndex = 3;
            makeAppointmentButton.Text = "Make Appointment";
            makeAppointmentButton.UseVisualStyleBackColor = true;
            makeAppointmentButton.Click += makeAppointmentButton_Click;
            // 
            // viewVisitsButton
            // 
            viewVisitsButton.Location = new Point(367, 372);
            viewVisitsButton.Margin = new Padding(3, 4, 3, 4);
            viewVisitsButton.Name = "viewVisitsButton";
            viewVisitsButton.Size = new Size(178, 79);
            viewVisitsButton.TabIndex = 4;
            viewVisitsButton.Text = "View/Edit Visits";
            viewVisitsButton.UseVisualStyleBackColor = true;
            viewVisitsButton.Click += viewVisitsButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(0, 565);
            backButton.Margin = new Padding(3, 4, 3, 4);
            backButton.Name = "backButton";
            backButton.Size = new Size(119, 36);
            backButton.TabIndex = 5;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // startNewVisitButton
            // 
            startNewVisitButton.Location = new Point(363, 474);
            startNewVisitButton.Name = "startNewVisitButton";
            startNewVisitButton.Size = new Size(182, 79);
            startNewVisitButton.TabIndex = 6;
            startNewVisitButton.Text = "Start New Visit";
            startNewVisitButton.UseVisualStyleBackColor = true;
            startNewVisitButton.Click += startNewVisitButton_Click;
            // 
            // PatientActionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(914, 600);
            Controls.Add(startNewVisitButton);
            Controls.Add(backButton);
            Controls.Add(viewVisitsButton);
            Controls.Add(makeAppointmentButton);
            Controls.Add(viewAppointmentsButton);
            Controls.Add(editPatientButton);
            Controls.Add(loggedInUserControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PatientActionsForm";
            Text = "HealthCare System - Patient Actions";
            ResumeLayout(false);
        }

        #endregion

        private LoggedInUserControl loggedInUserControl1;
        private Button editPatientButton;
        private Button viewAppointmentsButton;
        private Button makeAppointmentButton;
        private Button viewVisitsButton;
        private Button backButton;
        private Button startNewVisitButton;
    }
}