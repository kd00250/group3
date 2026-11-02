namespace HealthcareSystem.View
{
    partial class ViewOrdersForm
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
            orderSelectGrid = new DataGridView();
            selectOrderButton = new Button();
            backButton = new Button();
            patientInfoLabel = new Label();
            ordersLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)orderSelectGrid).BeginInit();
            SuspendLayout();
            // 
            // orderSelectGrid
            // 
            orderSelectGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            orderSelectGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderSelectGrid.Location = new Point(12, 175);
            orderSelectGrid.Name = "orderSelectGrid";
            orderSelectGrid.RowHeadersWidth = 51;
            orderSelectGrid.Size = new Size(798, 391);
            orderSelectGrid.TabIndex = 0;
            // 
            // selectOrderButton
            // 
            selectOrderButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            selectOrderButton.Location = new Point(685, 658);
            selectOrderButton.Name = "selectOrderButton";
            selectOrderButton.Size = new Size(125, 40);
            selectOrderButton.TabIndex = 14;
            selectOrderButton.Text = "Select";
            selectOrderButton.UseVisualStyleBackColor = true;
            selectOrderButton.Click += selectButton_Click;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backButton.Location = new Point(12, 659);
            backButton.Name = "backButton";
            backButton.Size = new Size(125, 40);
            backButton.TabIndex = 36;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // patientInfoLabel
            // 
            patientInfoLabel.AutoSize = true;
            patientInfoLabel.Location = new Point(463, 0);
            patientInfoLabel.Name = "patientInfoLabel";
            patientInfoLabel.Size = new Size(0, 20);
            patientInfoLabel.TabIndex = 52;
            // 
            // ordersLabel
            // 
            ordersLabel.AutoSize = true;
            ordersLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ordersLabel.Location = new Point(12, 144);
            ordersLabel.Name = "ordersLabel";
            ordersLabel.Size = new Size(155, 28);
            ordersLabel.TabIndex = 1;
            ordersLabel.Text = "Select an order";
            // 
            // ViewOrdersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 704);
            Controls.Add(patientInfoLabel);
            Controls.Add(backButton);
            Controls.Add(selectOrderButton);
            Controls.Add(ordersLabel);
            Controls.Add(orderSelectGrid);
            Name = "ViewOrdersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab Orders";
            ((System.ComponentModel.ISupportInitialize)orderSelectGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView orderSelectGrid;
        private Button selectOrderButton;
        private LoggedInUserControl loggedInUserControl1;
        private Button backButton;
        private Label patientInfoLabel;
        private Label ordersLabel;
    }
}