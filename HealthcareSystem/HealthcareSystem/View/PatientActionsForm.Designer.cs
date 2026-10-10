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
            // editPatientButton
            // 
            editPatientButton.Location = new Point(321, 56);
            editPatientButton.Name = "editPatientButton";
            editPatientButton.Size = new Size(156, 59);
            editPatientButton.TabIndex = 1;
            editPatientButton.Text = "Edit Patient Information";
            editPatientButton.UseVisualStyleBackColor = true;
            editPatientButton.Click += editPatientButton_Click;
            // 
            // viewAppointmentsButton
            // 
            viewAppointmentsButton.Location = new Point(321, 147);
            viewAppointmentsButton.Name = "viewAppointmentsButton";
            viewAppointmentsButton.Size = new Size(156, 59);
            viewAppointmentsButton.TabIndex = 2;
            viewAppointmentsButton.Text = "View Appointments";
            viewAppointmentsButton.UseVisualStyleBackColor = true;
            viewAppointmentsButton.Click += viewAppointmentsButton_Click;
            // 
            // makeAppointmentButton
            // 
            makeAppointmentButton.Location = new Point(321, 240);
            makeAppointmentButton.Name = "makeAppointmentButton";
            makeAppointmentButton.Size = new Size(156, 59);
            makeAppointmentButton.TabIndex = 3;
            makeAppointmentButton.Text = "Make Appointment";
            makeAppointmentButton.UseVisualStyleBackColor = true;
            makeAppointmentButton.Click += makeAppointmentButton_Click;
            // 
            // viewVisitsButton
            // 
            viewVisitsButton.Location = new Point(321, 323);
            viewVisitsButton.Name = "viewVisitsButton";
            viewVisitsButton.Size = new Size(156, 59);
            viewVisitsButton.TabIndex = 4;
            viewVisitsButton.Text = "View Visits";
            viewVisitsButton.UseVisualStyleBackColor = true;
            viewVisitsButton.Click += viewVisitsButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(0, 424);
            backButton.Name = "backButton";
            backButton.Size = new Size(104, 27);
            backButton.TabIndex = 5;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // PatientActionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(800, 450);
            Controls.Add(backButton);
            Controls.Add(viewVisitsButton);
            Controls.Add(makeAppointmentButton);
            Controls.Add(viewAppointmentsButton);
            Controls.Add(editPatientButton);
            Controls.Add(loggedInUserControl1);
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
    }
}