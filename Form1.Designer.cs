namespace Fetch_TPH_From_DateTime
{
    partial class FetchTPHFromDateTime
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
            this.DateTimeButton = new System.Windows.Forms.Button();
            this.ChooseOutputTextFile = new System.Windows.Forms.Button();
            this.DateTimeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.OutputFileTextBox = new System.Windows.Forms.TextBox();
            this.TemperatureComboBox = new System.Windows.Forms.ComboBox();
            this.PressureComboBox = new System.Windows.Forms.ComboBox();
            this.HumidityComboBox = new System.Windows.Forms.ComboBox();
            this.WriteData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DateTimeButton
            // 
            this.DateTimeButton.Location = new System.Drawing.Point(12, 20);
            this.DateTimeButton.Name = "DateTimeButton";
            this.DateTimeButton.Size = new System.Drawing.Size(193, 28);
            this.DateTimeButton.TabIndex = 0;
            this.DateTimeButton.Text = "Choose Datetime Text File";
            this.DateTimeButton.UseVisualStyleBackColor = true;
            this.DateTimeButton.Click += new System.EventHandler(this.DateTimeButton_Click);
            // 
            // ChooseOutputTextFile
            // 
            this.ChooseOutputTextFile.Location = new System.Drawing.Point(233, 20);
            this.ChooseOutputTextFile.Name = "ChooseOutputTextFile";
            this.ChooseOutputTextFile.Size = new System.Drawing.Size(214, 28);
            this.ChooseOutputTextFile.TabIndex = 1;
            this.ChooseOutputTextFile.Text = "Choose Location for Output File";
            this.ChooseOutputTextFile.UseVisualStyleBackColor = true;
            this.ChooseOutputTextFile.Click += new System.EventHandler(this.ChooseOutputTextFile_Click);
            // 
            // DateTimeRichTextBox
            // 
            this.DateTimeRichTextBox.Location = new System.Drawing.Point(13, 54);
            this.DateTimeRichTextBox.Name = "DateTimeRichTextBox";
            this.DateTimeRichTextBox.Size = new System.Drawing.Size(192, 196);
            this.DateTimeRichTextBox.TabIndex = 2;
            this.DateTimeRichTextBox.Text = "";
            // 
            // OutputFileTextBox
            // 
            this.OutputFileTextBox.Location = new System.Drawing.Point(233, 54);
            this.OutputFileTextBox.Name = "OutputFileTextBox";
            this.OutputFileTextBox.Size = new System.Drawing.Size(214, 20);
            this.OutputFileTextBox.TabIndex = 3;
            this.OutputFileTextBox.Text = "C:\\Users\\Public\\Documents\\";
            // 
            // TemperatureComboBox
            // 
            this.TemperatureComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.TemperatureComboBox.FormattingEnabled = true;
            this.TemperatureComboBox.Items.AddRange(new object[] {
            "None",
            "Hilger Lab",
            "Laser Lab",
            "Long Room ",
            "Leitz Room",
            "Tunnel"});
            this.TemperatureComboBox.Location = new System.Drawing.Point(233, 107);
            this.TemperatureComboBox.Name = "TemperatureComboBox";
            this.TemperatureComboBox.Size = new System.Drawing.Size(214, 21);
            this.TemperatureComboBox.TabIndex = 4;
            this.TemperatureComboBox.Text = "Choose Temperature Data Location";
            this.TemperatureComboBox.SelectedIndexChanged += new System.EventHandler(this.TemperatureComboBox_SelectedIndexChanged);
            // 
            // PressureComboBox
            // 
            this.PressureComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.PressureComboBox.FormattingEnabled = true;
            this.PressureComboBox.Items.AddRange(new object[] {
            "None",
            "Robertson Ground",
            "Tunnel"});
            this.PressureComboBox.Location = new System.Drawing.Point(233, 145);
            this.PressureComboBox.Name = "PressureComboBox";
            this.PressureComboBox.Size = new System.Drawing.Size(214, 21);
            this.PressureComboBox.TabIndex = 5;
            this.PressureComboBox.Text = "Choose Pressure Barometer Location";
            this.PressureComboBox.SelectedIndexChanged += new System.EventHandler(this.PressureComboBox_SelectedIndexChanged);
            // 
            // HumidityComboBox
            // 
            this.HumidityComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.HumidityComboBox.FormattingEnabled = true;
            this.HumidityComboBox.Items.AddRange(new object[] {
            "None",
            "Hilger Lab",
            "Laser Lab",
            "Long Room ",
            "Leitz Room",
            "Tunnel"});
            this.HumidityComboBox.Location = new System.Drawing.Point(233, 186);
            this.HumidityComboBox.Name = "HumidityComboBox";
            this.HumidityComboBox.Size = new System.Drawing.Size(214, 21);
            this.HumidityComboBox.TabIndex = 6;
            this.HumidityComboBox.Text = "Choose Humidity Data Location";
            this.HumidityComboBox.SelectedIndexChanged += new System.EventHandler(this.HumidityComboBox_SelectedIndexChanged);
            // 
            // WriteData
            // 
            this.WriteData.Location = new System.Drawing.Point(233, 227);
            this.WriteData.Name = "WriteData";
            this.WriteData.Size = new System.Drawing.Size(214, 23);
            this.WriteData.TabIndex = 7;
            this.WriteData.Text = "Write Data";
            this.WriteData.UseVisualStyleBackColor = true;
            this.WriteData.Click += new System.EventHandler(this.WriteData_Click);
            // 
            // FetchTPHFromDateTime
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 262);
            this.Controls.Add(this.WriteData);
            this.Controls.Add(this.HumidityComboBox);
            this.Controls.Add(this.PressureComboBox);
            this.Controls.Add(this.TemperatureComboBox);
            this.Controls.Add(this.OutputFileTextBox);
            this.Controls.Add(this.DateTimeRichTextBox);
            this.Controls.Add(this.ChooseOutputTextFile);
            this.Controls.Add(this.DateTimeButton);
            this.Name = "FetchTPHFromDateTime";
            this.Text = "Fetch TPH From Date Time";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DateTimeButton;
        private System.Windows.Forms.Button ChooseOutputTextFile;
        private System.Windows.Forms.RichTextBox DateTimeRichTextBox;
        private System.Windows.Forms.TextBox OutputFileTextBox;
        private System.Windows.Forms.ComboBox TemperatureComboBox;
        private System.Windows.Forms.ComboBox PressureComboBox;
        private System.Windows.Forms.ComboBox HumidityComboBox;
        private System.Windows.Forms.Button WriteData;
    }
}

