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
            SuspendLayout();
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(233, 402);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(174, 45);
            logoutButton.TabIndex = 0;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(221, 23);
            label1.Name = "label1";
            label1.Size = new Size(215, 31);
            label1.TabIndex = 1;
            label1.Text = "HealthCare System";
            // 
            // manageUsersButton
            // 
            manageUsersButton.Font = new Font("Segoe UI Semibold", 9F);
            manageUsersButton.Location = new Point(233, 105);
            manageUsersButton.Name = "manageUsersButton";
            manageUsersButton.Size = new Size(174, 46);
            manageUsersButton.TabIndex = 2;
            manageUsersButton.Text = "Manage Users";
            manageUsersButton.UseVisualStyleBackColor = true;
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(-1, -2);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(216, 90);
            loggedInUserControl1.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 480);
            Controls.Add(loggedInUserControl1);
            Controls.Add(manageUsersButton);
            Controls.Add(label1);
            Controls.Add(logoutButton);
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
    }
}