namespace HealthcareSystem.View
{
    partial class LoggedInUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            currentUserLabel = new Label();
            SuspendLayout();
            // 
            // currentUserLabel
            // 
            currentUserLabel.AutoSize = true;
            currentUserLabel.Location = new Point(0, 0);
            currentUserLabel.Name = "currentUserLabel";
            currentUserLabel.Size = new Size(0, 20);
            currentUserLabel.TabIndex = 0;
            // 
            // LoggedInUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(currentUserLabel);
            Name = "LoggedInUserControl";
            Size = new Size(280, 135);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label currentUserLabel;
    }
}
