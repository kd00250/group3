namespace HealthcareSystem
{
    partial class PatientEditForm
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
            attributeLabel = new Label();
            attributeCombo = new ComboBox();
            submitButton = new Button();
            backButton = new Button();
            newValueLabel = new Label();
            valueBox = new TextBox();
            SuspendLayout();
            // 
            // attributeLabel
            // 
            attributeLabel.AutoSize = true;
            attributeLabel.Location = new Point(39, 35);
            attributeLabel.Name = "attributeLabel";
            attributeLabel.Size = new Size(71, 20);
            attributeLabel.TabIndex = 0;
            attributeLabel.Text = "Attribute:";
            // 
            // attributeCombo
            // 
            attributeCombo.FormattingEnabled = true;
            attributeCombo.Items.AddRange(new object[] { "First name", "Last name", "Date of Birth", "Gender", "Street", "City", "State", "Zipcode", "Phone number" });
            attributeCombo.Location = new Point(116, 35);
            attributeCombo.Name = "attributeCombo";
            attributeCombo.Size = new Size(151, 28);
            attributeCombo.TabIndex = 1;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(173, 151);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(94, 29);
            submitButton.TabIndex = 2;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(39, 151);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 3;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // newValueLabel
            // 
            newValueLabel.AutoSize = true;
            newValueLabel.Location = new Point(28, 89);
            newValueLabel.Name = "newValueLabel";
            newValueLabel.Size = new Size(82, 20);
            newValueLabel.TabIndex = 4;
            newValueLabel.Text = "New Value:";
            // 
            // valueBox
            // 
            valueBox.Location = new Point(116, 89);
            valueBox.Name = "valueBox";
            valueBox.Size = new Size(151, 27);
            valueBox.TabIndex = 5;
            // 
            // PatientEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 192);
            Controls.Add(valueBox);
            Controls.Add(newValueLabel);
            Controls.Add(backButton);
            Controls.Add(submitButton);
            Controls.Add(attributeCombo);
            Controls.Add(attributeLabel);
            Name = "PatientEditForm";
            Text = "PatientEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label attributeLabel;
        private ComboBox attributeCombo;
        private Button submitButton;
        private Button backButton;
        private Label newValueLabel;
        private TextBox valueBox;
    }
}