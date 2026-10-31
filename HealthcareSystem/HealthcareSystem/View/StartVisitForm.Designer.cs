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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 172);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(867, 226);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1, 149);
            label1.Name = "label1";
            label1.Size = new Size(213, 20);
            label1.TabIndex = 1;
            label1.Text = "Please select an appointment";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(369, 9);
            label2.Name = "label2";
            label2.Size = new Size(120, 31);
            label2.TabIndex = 2;
            label2.Text = "Start Visit";
            // 
            // startVisitButton
            // 
            startVisitButton.Location = new Point(774, 462);
            startVisitButton.Name = "startVisitButton";
            startVisitButton.Size = new Size(94, 29);
            startVisitButton.TabIndex = 3;
            startVisitButton.Text = "Start Visit";
            startVisitButton.UseVisualStyleBackColor = true;
            startVisitButton.Click += startVisitButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(1, 462);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 4;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(1, -1);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(271, 135);
            loggedInUserControl1.TabIndex = 5;
            // 
            // StartVisitForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 503);
            Controls.Add(loggedInUserControl1);
            Controls.Add(backButton);
            Controls.Add(startVisitButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "StartVisitForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StartVisitForm";
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
    }
}