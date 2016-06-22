namespace SensorDataGraphing
{
    partial class Form1
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
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadSensorDataBtn = new System.Windows.Forms.Button();
            this.sensorCheckBox = new System.Windows.Forms.CheckedListBox();
            this.resetTableBtn = new System.Windows.Forms.Button();
            this.amountBtn = new System.Windows.Forms.Button();
            this.dataInputProgress = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.graphCheckedBtn = new System.Windows.Forms.Button();
            this.sensorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sensorSavedLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).BeginInit();
            this.SuspendLayout();
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startDateTimePicker.Location = new System.Drawing.Point(3, 595);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.tableLayoutPanel3.SetRowSpan(this.startDateTimePicker, 5);
            this.startDateTimePicker.Size = new System.Drawing.Size(217, 20);
            this.startDateTimePicker.TabIndex = 1;
            this.startDateTimePicker.CloseUp += new System.EventHandler(this.startDateTimePicker_CloseUp);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endDateTimePicker.Location = new System.Drawing.Point(226, 595);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.tableLayoutPanel3.SetRowSpan(this.endDateTimePicker, 5);
            this.endDateTimePicker.Size = new System.Drawing.Size(217, 20);
            this.endDateTimePicker.TabIndex = 2;
            this.endDateTimePicker.CloseUp += new System.EventHandler(this.endDateTimePicker_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 579);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(226, 579);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadSensorDataBtn
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.loadSensorDataBtn, 2);
            this.loadSensorDataBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadSensorDataBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loadSensorDataBtn.Location = new System.Drawing.Point(995, 712);
            this.loadSensorDataBtn.Name = "loadSensorDataBtn";
            this.tableLayoutPanel3.SetRowSpan(this.loadSensorDataBtn, 2);
            this.loadSensorDataBtn.Size = new System.Drawing.Size(246, 76);
            this.loadSensorDataBtn.TabIndex = 5;
            this.loadSensorDataBtn.Text = "Load Sensor Data";
            this.loadSensorDataBtn.UseVisualStyleBackColor = true;
            this.loadSensorDataBtn.Click += new System.EventHandler(this.loadSensorDataBtn_Click);
            // 
            // sensorCheckBox
            // 
            this.sensorCheckBox.CheckOnClick = true;
            this.sensorCheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.sensorCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sensorCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sensorCheckBox.FormattingEnabled = true;
            this.sensorCheckBox.Items.AddRange(new object[] {
            "Propane",
            "Carbon Monoxide (CO)",
            "Smoke",
            "Liquid Petroleum Gas (LPG)",
            "Methane (CH4)",
            "Hydrogen Gas (H2)",
            "Alcohol",
            "Temperature",
            "Humidity"});
            this.sensorCheckBox.Location = new System.Drawing.Point(449, 595);
            this.sensorCheckBox.Name = "sensorCheckBox";
            this.tableLayoutPanel3.SetRowSpan(this.sensorCheckBox, 4);
            this.sensorCheckBox.Size = new System.Drawing.Size(180, 150);
            this.sensorCheckBox.TabIndex = 6;
            // 
            // resetTableBtn
            // 
            this.resetTableBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetTableBtn.Location = new System.Drawing.Point(1119, 634);
            this.resetTableBtn.Name = "resetTableBtn";
            this.resetTableBtn.Size = new System.Drawing.Size(122, 33);
            this.resetTableBtn.TabIndex = 7;
            this.resetTableBtn.Text = "Reset Data";
            this.resetTableBtn.UseVisualStyleBackColor = true;
            this.resetTableBtn.Click += new System.EventHandler(this.resetTableBtn_Click);
            // 
            // amountBtn
            // 
            this.amountBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.amountBtn.Location = new System.Drawing.Point(995, 634);
            this.amountBtn.Name = "amountBtn";
            this.amountBtn.Size = new System.Drawing.Size(118, 33);
            this.amountBtn.TabIndex = 8;
            this.amountBtn.Text = "Amount";
            this.amountBtn.UseVisualStyleBackColor = true;
            this.amountBtn.Click += new System.EventHandler(this.amountBtn_Click);
            // 
            // dataInputProgress
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.dataInputProgress, 2);
            this.dataInputProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataInputProgress.Location = new System.Drawing.Point(995, 673);
            this.dataInputProgress.Name = "dataInputProgress";
            this.dataInputProgress.Size = new System.Drawing.Size(246, 33);
            this.dataInputProgress.TabIndex = 9;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Controls.Add(this.startDateTimePicker, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.sensorCheckBox, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.endDateTimePicker, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.loadSensorDataBtn, 4, 5);
            this.tableLayoutPanel3.Controls.Add(this.dataInputProgress, 4, 4);
            this.tableLayoutPanel3.Controls.Add(this.graphCheckedBtn, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.sensorChart, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.sensorSavedLabel, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.amountBtn, 4, 3);
            this.tableLayoutPanel3.Controls.Add(this.resetTableBtn, 5, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1244, 791);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // graphCheckedBtn
            // 
            this.graphCheckedBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphCheckedBtn.Location = new System.Drawing.Point(449, 751);
            this.graphCheckedBtn.Name = "graphCheckedBtn";
            this.graphCheckedBtn.Size = new System.Drawing.Size(180, 37);
            this.graphCheckedBtn.TabIndex = 11;
            this.graphCheckedBtn.Text = "Graph";
            this.graphCheckedBtn.UseVisualStyleBackColor = true;
            this.graphCheckedBtn.Click += new System.EventHandler(this.graphCheckedBtn_Click);
            // 
            // sensorChart
            // 
            this.sensorChart.BackColor = System.Drawing.Color.LightGray;
            this.sensorChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.tableLayoutPanel3.SetColumnSpan(this.sensorChart, 6);
            this.sensorChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sensorChart.Location = new System.Drawing.Point(0, 0);
            this.sensorChart.Margin = new System.Windows.Forms.Padding(0);
            this.sensorChart.Name = "sensorChart";
            this.sensorChart.Size = new System.Drawing.Size(1244, 569);
            this.sensorChart.TabIndex = 0;
            this.sensorChart.Text = "chart1";
            // 
            // sensorSavedLabel
            // 
            this.sensorSavedLabel.AutoSize = true;
            this.sensorSavedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sensorSavedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sensorSavedLabel.Location = new System.Drawing.Point(635, 670);
            this.sensorSavedLabel.Name = "sensorSavedLabel";
            this.tableLayoutPanel3.SetRowSpan(this.sensorSavedLabel, 2);
            this.sensorSavedLabel.Size = new System.Drawing.Size(354, 78);
            this.sensorSavedLabel.TabIndex = 13;
            this.sensorSavedLabel.Text = "Click \'Load Sensor Data\' if no data has been loaded previously. Otherwise, click " +
    "\'Reset Data\' then \'Load Sensor Data\'.";
            this.sensorSavedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 791);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "Form1";
            this.Text = "Sensor Graphing Utlility";
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadSensorDataBtn;
        private System.Windows.Forms.CheckedListBox sensorCheckBox;
        private System.Windows.Forms.Button resetTableBtn;
        private System.Windows.Forms.Button amountBtn;
        private System.Windows.Forms.ProgressBar dataInputProgress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart sensorChart;
        private System.Windows.Forms.Button graphCheckedBtn;
        private System.Windows.Forms.Label sensorSavedLabel;
    }
}

