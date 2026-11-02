using Org.BouncyCastle.Asn1.Crmf;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HealthcareSystem.View
{
    partial class ViewVisitsForm
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
            visitsGridView = new DataGridView();
            visitCountLabel = new Label();
            errorLabel = new Label();
            backButton = new Button();
            selectButton = new Button();
            ((System.ComponentModel.ISupportInitialize)visitsGridView).BeginInit();
            SuspendLayout();
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(0, 0);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(280, 135);
            loggedInUserControl1.TabIndex = 0;
            // 
            // patientLabel
            // 
            patientLabel.AutoSize = true;
            patientLabel.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            patientLabel.Location = new Point(343, 27);
            patientLabel.Name = "patientLabel";
            patientLabel.Size = new Size(0, 20);
            patientLabel.TabIndex = 1;
            // 
            // visitsGridView
            // 
            visitsGridView.AllowUserToAddRows = false;
            visitsGridView.AllowUserToDeleteRows = false;
            visitsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            visitsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            visitsGridView.Location = new Point(34, 173);
            visitsGridView.Margin = new Padding(3, 4, 3, 4);
            visitsGridView.MultiSelect = false;
            visitsGridView.Name = "visitsGridView";
            visitsGridView.ReadOnly = true;
            visitsGridView.RowHeadersVisible = false;
            visitsGridView.RowHeadersWidth = 51;
            visitsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            visitsGridView.Size = new Size(846, 320);
            visitsGridView.TabIndex = 2;
            visitsGridView.CellDoubleClick += visitsGridView_CellDoubleClick;
            visitsGridView.SelectionChanged += visitsGridView_SelectionChanged;
            // 
            // visitCountLabel
            // 
            visitCountLabel.AutoSize = true;
            visitCountLabel.Location = new Point(34, 147);
            visitCountLabel.Name = "visitCountLabel";
            visitCountLabel.Size = new Size(0, 20);
            visitCountLabel.TabIndex = 3;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(34, 507);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 20);
            errorLabel.TabIndex = 4;
            errorLabel.Visible = false;
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
            // selectButton
            // 
            selectButton.Enabled = false;
            selectButton.Location = new Point(789, 533);
            selectButton.Margin = new Padding(3, 4, 3, 4);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(91, 36);
            selectButton.TabIndex = 6;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += selectButton_Click;
            // 
            // ViewVisitsForm
            // 
            AcceptButton = selectButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(914, 600);
            Controls.Add(selectButton);
            Controls.Add(backButton);
            Controls.Add(errorLabel);
            Controls.Add(visitCountLabel);
            Controls.Add(visitsGridView);
            Controls.Add(patientLabel);
            Controls.Add(loggedInUserControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ViewVisitsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Healthcare System - View/Edit Visits";
            ((System.ComponentModel.ISupportInitialize)visitsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LoggedInUserControl loggedInUserControl1;
        private Label patientLabel;
        private DataGridView visitsGridView;
        private Label visitCountLabel;
        private Label errorLabel;
        private Button backButton;
        private Button selectButton;
    }
}
