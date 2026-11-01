namespace HealthcareSystem.View
{
    partial class MakeAppointmentForm
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
            label1 = new Label();
            label2 = new Label();
            doctorComboBox = new ComboBox();
            appointmentDatePicker = new DateTimePicker();
            label3 = new Label();
            timeComboBox = new ComboBox();
            availabilityLabel = new Label();
            label4 = new Label();
            errorLabel = new Label();
            reasonTextBox = new TextBox();
            bookButton = new Button();
            backButton = new Button();
            SuspendLayout();
            // 
            // loggedInUserControl1
            // 
            loggedInUserControl1.Location = new Point(-2, -3);
            loggedInUserControl1.Name = "loggedInUserControl1";
            loggedInUserControl1.Size = new Size(280, 135);
            loggedInUserControl1.TabIndex = 0;
            // 
            // patientLabel
            // 
            patientLabel.AutoSize = true;
            patientLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            patientLabel.Location = new Point(225, 96);
            patientLabel.Name = "patientLabel";
            patientLabel.Size = new Size(0, 20);
            patientLabel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(225, 131);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 2;
            label1.Text = "Doctor : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(225, 176);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 3;
            label2.Text = "Date : ";
            // 
            // doctorComboBox
            // 
            doctorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            doctorComboBox.FormattingEnabled = true;
            doctorComboBox.Location = new Point(291, 127);
            doctorComboBox.Margin = new Padding(3, 4, 3, 4);
            doctorComboBox.Name = "doctorComboBox";
            doctorComboBox.Size = new Size(266, 28);
            doctorComboBox.TabIndex = 4;
            doctorComboBox.SelectedIndexChanged += doctorComboBox_SelectedIndexChange;
            // 
            // appointmentDatePicker
            // 
            appointmentDatePicker.Format = DateTimePickerFormat.Short;
            appointmentDatePicker.Location = new Point(291, 171);
            appointmentDatePicker.Margin = new Padding(3, 4, 3, 4);
            appointmentDatePicker.Name = "appointmentDatePicker";
            appointmentDatePicker.Size = new Size(266, 27);
            appointmentDatePicker.TabIndex = 5;
            appointmentDatePicker.ValueChanged += appointmentDatePicker_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(225, 219);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 6;
            label3.Text = "Time :";
            // 
            // timeComboBox
            // 
            timeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            timeComboBox.FormattingEnabled = true;
            timeComboBox.Location = new Point(291, 215);
            timeComboBox.Margin = new Padding(3, 4, 3, 4);
            timeComboBox.Name = "timeComboBox";
            timeComboBox.Size = new Size(266, 28);
            timeComboBox.TabIndex = 7;
            // 
            // availabilityLabel
            // 
            availabilityLabel.AutoSize = true;
            availabilityLabel.Location = new Point(291, 249);
            availabilityLabel.Name = "availabilityLabel";
            availabilityLabel.Size = new Size(0, 20);
            availabilityLabel.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(225, 289);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 9;
            label4.Text = "Reason :";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(225, 513);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 20);
            errorLabel.TabIndex = 10;
            // 
            // reasonTextBox
            // 
            reasonTextBox.Location = new Point(291, 289);
            reasonTextBox.Margin = new Padding(3, 4, 3, 4);
            reasonTextBox.MaxLength = 255;
            reasonTextBox.Multiline = true;
            reasonTextBox.Name = "reasonTextBox";
            reasonTextBox.Size = new Size(266, 160);
            reasonTextBox.TabIndex = 11;
            // 
            // bookButton
            // 
            bookButton.Location = new Point(225, 479);
            bookButton.Margin = new Padding(3, 4, 3, 4);
            bookButton.Name = "bookButton";
            bookButton.Size = new Size(157, 31);
            bookButton.TabIndex = 12;
            bookButton.Text = "Book Appointment";
            bookButton.UseVisualStyleBackColor = true;
            bookButton.Click += bookButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(-2, 569);
            backButton.Margin = new Padding(3, 4, 3, 4);
            backButton.Name = "backButton";
            backButton.Size = new Size(86, 31);
            backButton.TabIndex = 13;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // MakeAppointmentForm
            // 
            AcceptButton = bookButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = backButton;
            ClientSize = new Size(754, 600);
            Controls.Add(backButton);
            Controls.Add(bookButton);
            Controls.Add(reasonTextBox);
            Controls.Add(errorLabel);
            Controls.Add(label4);
            Controls.Add(availabilityLabel);
            Controls.Add(timeComboBox);
            Controls.Add(label3);
            Controls.Add(appointmentDatePicker);
            Controls.Add(doctorComboBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(patientLabel);
            Controls.Add(loggedInUserControl1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MakeAppointmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Healthcare System - Make Appointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LoggedInUserControl loggedInUserControl1;
        private Label patientLabel;
        private Label label1;
        private Label label2;
        private ComboBox doctorComboBox;
        private DateTimePicker appointmentDatePicker;
        private Label label3;
        private ComboBox timeComboBox;
        private Label availabilityLabel;
        private Label label4;
        private Label errorLabel;
        private TextBox reasonTextBox;
        private Button bookButton;
        private Button backButton;
    }
}