namespace HealthcareSystem.View
{
    partial class VisitInformationForm
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
            visitLabel = new Label();
            heightLabel = new Label();
            weightLabel = new Label();
            systolicLabel = new Label();
            diastolicLabel = new Label();
            temperatureLabel = new Label();
            pulseLabel = new Label();
            symptomsLabel = new Label();
            heightTextBox = new TextBox();
            weightTextBox = new TextBox();
            systolicTextBox = new TextBox();
            diastolicTextBox = new TextBox();
            temperatureTextBox = new TextBox();
            pulseTextBox = new TextBox();
            symptomsTextBox = new TextBox();
            nurseLabel = new Label();
            checkedLabel = new Label();
            finalizedLabel = new Label();
            errorLabel = new Label();
            backButton = new Button();
            saveButton = new Button();
            orderTestsButton = new Button();
            viewEditTestsButton = new Button();
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
            patientLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            patientLabel.Location = new Point(297, 27);
            patientLabel.Name = "patientLabel";
            patientLabel.Size = new Size(0, 20);
            patientLabel.TabIndex = 1;
            // 
            // visitLabel
            // 
            visitLabel.AutoSize = true;
            visitLabel.Location = new Point(297, 60);
            visitLabel.Name = "visitLabel";
            visitLabel.Size = new Size(0, 20);
            visitLabel.TabIndex = 2;
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.Location = new Point(34, 177);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(83, 20);
            heightLabel.TabIndex = 3;
            heightLabel.Text = "Height (in):";
            // 
            // weightLabel
            // 
            weightLabel.AutoSize = true;
            weightLabel.Location = new Point(34, 220);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new Size(86, 20);
            weightLabel.TabIndex = 4;
            weightLabel.Text = "Weight (lb):";
            // 
            // systolicLabel
            // 
            systolicLabel.AutoSize = true;
            systolicLabel.Location = new Point(34, 263);
            systolicLabel.Name = "systolicLabel";
            systolicLabel.Size = new Size(143, 20);
            systolicLabel.TabIndex = 5;
            systolicLabel.Text = "Systolic BP (mmHg):";
            // 
            // diastolicLabel
            // 
            diastolicLabel.AutoSize = true;
            diastolicLabel.Location = new Point(34, 305);
            diastolicLabel.Name = "diastolicLabel";
            diastolicLabel.Size = new Size(151, 20);
            diastolicLabel.TabIndex = 6;
            diastolicLabel.Text = "Diastolic BP (mmHg):";
            // 
            // temperatureLabel
            // 
            temperatureLabel.AutoSize = true;
            temperatureLabel.Location = new Point(34, 348);
            temperatureLabel.Name = "temperatureLabel";
            temperatureLabel.Size = new Size(123, 20);
            temperatureLabel.TabIndex = 7;
            temperatureLabel.Text = "Temperature (°F):";
            // 
            // pulseLabel
            // 
            pulseLabel.AutoSize = true;
            pulseLabel.Location = new Point(34, 391);
            pulseLabel.Name = "pulseLabel";
            pulseLabel.Size = new Size(91, 20);
            pulseLabel.TabIndex = 8;
            pulseLabel.Text = "Pulse (bpm):";
            // 
            // symptomsLabel
            // 
            symptomsLabel.AutoSize = true;
            symptomsLabel.Location = new Point(377, 173);
            symptomsLabel.Name = "symptomsLabel";
            symptomsLabel.Size = new Size(82, 20);
            symptomsLabel.TabIndex = 9;
            symptomsLabel.Text = "Symptoms:";
            // 
            // heightTextBox
            // 
            heightTextBox.Location = new Point(217, 173);
            heightTextBox.Margin = new Padding(3, 4, 3, 4);
            heightTextBox.Name = "heightTextBox";
            heightTextBox.Size = new Size(114, 27);
            heightTextBox.TabIndex = 10;
            // 
            // weightTextBox
            // 
            weightTextBox.Location = new Point(217, 216);
            weightTextBox.Margin = new Padding(3, 4, 3, 4);
            weightTextBox.Name = "weightTextBox";
            weightTextBox.Size = new Size(114, 27);
            weightTextBox.TabIndex = 11;
            // 
            // systolicTextBox
            // 
            systolicTextBox.Location = new Point(217, 259);
            systolicTextBox.Margin = new Padding(3, 4, 3, 4);
            systolicTextBox.Name = "systolicTextBox";
            systolicTextBox.Size = new Size(114, 27);
            systolicTextBox.TabIndex = 12;
            // 
            // diastolicTextBox
            // 
            diastolicTextBox.Location = new Point(217, 301);
            diastolicTextBox.Margin = new Padding(3, 4, 3, 4);
            diastolicTextBox.Name = "diastolicTextBox";
            diastolicTextBox.Size = new Size(114, 27);
            diastolicTextBox.TabIndex = 13;
            // 
            // temperatureTextBox
            // 
            temperatureTextBox.Location = new Point(217, 344);
            temperatureTextBox.Margin = new Padding(3, 4, 3, 4);
            temperatureTextBox.Name = "temperatureTextBox";
            temperatureTextBox.Size = new Size(114, 27);
            temperatureTextBox.TabIndex = 14;
            // 
            // pulseTextBox
            // 
            pulseTextBox.Location = new Point(217, 387);
            pulseTextBox.Margin = new Padding(3, 4, 3, 4);
            pulseTextBox.Name = "pulseTextBox";
            pulseTextBox.Size = new Size(114, 27);
            pulseTextBox.TabIndex = 15;
            // 
            // symptomsTextBox
            // 
            symptomsTextBox.Location = new Point(377, 200);
            symptomsTextBox.Margin = new Padding(3, 4, 3, 4);
            symptomsTextBox.Multiline = true;
            symptomsTextBox.Name = "symptomsTextBox";
            symptomsTextBox.ScrollBars = ScrollBars.Vertical;
            symptomsTextBox.Size = new Size(503, 96);
            symptomsTextBox.TabIndex = 16;
            // 
            // nurseLabel
            // 
            nurseLabel.AutoSize = true;
            nurseLabel.Location = new Point(34, 460);
            nurseLabel.Name = "nurseLabel";
            nurseLabel.Size = new Size(0, 20);
            nurseLabel.TabIndex = 17;
            // 
            // checkedLabel
            // 
            checkedLabel.AutoSize = true;
            checkedLabel.Location = new Point(34, 493);
            checkedLabel.Name = "checkedLabel";
            checkedLabel.Size = new Size(0, 20);
            checkedLabel.TabIndex = 18;
            // 
            // finalizedLabel
            // 
            finalizedLabel.AutoSize = true;
            finalizedLabel.Location = new Point(34, 527);
            finalizedLabel.Name = "finalizedLabel";
            finalizedLabel.Size = new Size(0, 20);
            finalizedLabel.TabIndex = 19;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(34, 587);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 20);
            errorLabel.TabIndex = 20;
            errorLabel.Visible = false;
            // 
            // backButton
            // 
            backButton.Location = new Point(0, 664);
            backButton.Margin = new Padding(3, 4, 3, 4);
            backButton.Name = "backButton";
            backButton.Size = new Size(119, 36);
            backButton.TabIndex = 21;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(137, 664);
            saveButton.Margin = new Padding(3, 4, 3, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(119, 36);
            saveButton.TabIndex = 22;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // orderTestsButton
            // 
            orderTestsButton.Location = new Point(617, 664);
            orderTestsButton.Margin = new Padding(3, 4, 3, 4);
            orderTestsButton.Name = "orderTestsButton";
            orderTestsButton.Size = new Size(126, 36);
            orderTestsButton.TabIndex = 23;
            orderTestsButton.Text = "Order tests";
            orderTestsButton.UseVisualStyleBackColor = true;
            orderTestsButton.Click += orderTestsButton_Click;
            // 
            // viewEditTestsButton
            // 
            viewEditTestsButton.Location = new Point(754, 664);
            viewEditTestsButton.Margin = new Padding(3, 4, 3, 4);
            viewEditTestsButton.Name = "viewEditTestsButton";
            viewEditTestsButton.Size = new Size(126, 36);
            viewEditTestsButton.TabIndex = 24;
            viewEditTestsButton.Text = "View/edit tests";
            viewEditTestsButton.UseVisualStyleBackColor = true;
            viewEditTestsButton.Click += viewEditTestsButton_Click;
            // 
            // VisitInformationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(914, 707);
            Controls.Add(viewEditTestsButton);
            Controls.Add(orderTestsButton);
            Controls.Add(saveButton);
            Controls.Add(backButton);
            Controls.Add(errorLabel);
            Controls.Add(finalizedLabel);
            Controls.Add(checkedLabel);
            Controls.Add(nurseLabel);
            Controls.Add(symptomsTextBox);
            Controls.Add(pulseTextBox);
            Controls.Add(temperatureTextBox);
            Controls.Add(diastolicTextBox);
            Controls.Add(systolicTextBox);
            Controls.Add(weightTextBox);
            Controls.Add(heightTextBox);
            Controls.Add(symptomsLabel);
            Controls.Add(pulseLabel);
            Controls.Add(temperatureLabel);
            Controls.Add(diastolicLabel);
            Controls.Add(systolicLabel);
            Controls.Add(weightLabel);
            Controls.Add(heightLabel);
            Controls.Add(visitLabel);
            Controls.Add(patientLabel);
            Controls.Add(loggedInUserControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "VisitInformationForm";
            Text = "Healthcare System - Visit Information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LoggedInUserControl loggedInUserControl1;
        private Label patientLabel;
        private Label visitLabel;
        private Label heightLabel;
        private Label weightLabel;
        private Label systolicLabel;
        private Label diastolicLabel;
        private Label temperatureLabel;
        private Label pulseLabel;
        private Label symptomsLabel;
        private TextBox heightTextBox;
        private TextBox weightTextBox;
        private TextBox systolicTextBox;
        private TextBox diastolicTextBox;
        private TextBox temperatureTextBox;
        private TextBox pulseTextBox;
        private TextBox symptomsTextBox;
        private Label nurseLabel;
        private Label checkedLabel;
        private Label finalizedLabel;
        private Label errorLabel;
        private Button backButton;
        private Button saveButton;
        private Button orderTestsButton;
        private Button viewEditTestsButton;
    }
}
