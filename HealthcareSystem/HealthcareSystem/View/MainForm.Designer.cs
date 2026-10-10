namespace HealthcareSystem.View
{
    partial class MainForm
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
            logoutButton = new Button();
            label1 = new Label();
            manageUsersButton = new Button();
            loggedInUserControl1 = new LoggedInUserControl();
            findPatientButton = new Button();
            SuspendLayout();
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(204, 302);
            logoutButton.Margin = new Padding(3, 2, 3, 2);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(152, 34);
            logoutButton.TabIndex = 0;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(193, 17);
            label1.Name = "label1";
            label1.Size = new Size(178, 25);
            label1.TabIndex = 1;
            label1.Text = "HealthCare System";
            // 
            // manageUsersButton
            // 
            manageUsersButton.Font = new Font("Segoe UI Semibold", 9F);
            manageUsersButton.Location = new Point(204, 79);
            manageUsersButton.Margin = new Padding(3, 2, 3, 2);
            manageUsersButton.Name = "manageUsersButton";
            manageUsersButton.Size = new Size(152, 34);
            manageUsersButton.TabIndex = 2;
            manageUsersButton.Text = "Manage Users";
            manageUsersButton.UseVisualStyleBackColor = true;
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(-1, -2);
            loggedInUserControl1.Margin = new Padding(3, 2, 3, 2);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(189, 68);
            loggedInUserControl1.TabIndex = 3;
            // 
            // findPatientButton
            // 
            findPatientButton.Font = new Font("Segoe UI Semibold", 9F);
            findPatientButton.Location = new Point(204, 127);
            findPatientButton.Margin = new Padding(3, 2, 3, 2);
            findPatientButton.Name = "findPatientButton";
            findPatientButton.Size = new Size(152, 34);
            findPatientButton.TabIndex = 4;
            findPatientButton.Text = "Find Existing Patient";
            findPatientButton.UseVisualStyleBackColor = true;
            findPatientButton.Click += findPatientButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 360);
            Controls.Add(findPatientButton);
            Controls.Add(loggedInUserControl1);
            Controls.Add(manageUsersButton);
            Controls.Add(label1);
            Controls.Add(logoutButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button logoutButton;
        private Label label1;
        private Button manageUsersButton;
        private LoggedInUserControl loggedInUserControl1;
        private Button findPatientButton;
    }
}