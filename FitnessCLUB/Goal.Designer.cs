namespace FitnessCLUB
{
    partial class Goal
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
            this.select_Excercise = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.Addgoalbtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblMetric1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMetric2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblMetric3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtGoalName1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTime = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMetric1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMetric2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMetric3 = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // select_Excercise
            // 
            this.select_Excercise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_Excercise.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_Excercise.FormattingEnabled = true;
            this.select_Excercise.Items.AddRange(new object[] {
            "Walking",
            "Swimming",
            "Running",
            "Cycling",
            "Skipping",
            "Zumba"});
            this.select_Excercise.Location = new System.Drawing.Point(133, 350);
            this.select_Excercise.Name = "select_Excercise";
            this.select_Excercise.Size = new System.Drawing.Size(321, 37);
            this.select_Excercise.TabIndex = 8;
            this.select_Excercise.Text = "Select Exercise";
            this.select_Excercise.SelectedIndexChanged += new System.EventHandler(this.select_Excercise_SelectedIndexChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Animated = true;
            this.dateTimePicker.BackColor = System.Drawing.Color.Transparent;
            this.dateTimePicker.Checked = true;
            this.dateTimePicker.FillColor = System.Drawing.Color.White;
            this.dateTimePicker.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateTimePicker.Location = new System.Drawing.Point(133, 488);
            this.dateTimePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(266, 44);
            this.dateTimePicker.TabIndex = 14;
            this.dateTimePicker.Value = new System.DateTime(2025, 3, 24, 19, 57, 19, 918);
            // 
            // Addgoalbtn
            // 
            this.Addgoalbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(32)))), ((int)(((byte)(53)))));
            this.Addgoalbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Addgoalbtn.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addgoalbtn.ForeColor = System.Drawing.Color.White;
            this.Addgoalbtn.Location = new System.Drawing.Point(493, 828);
            this.Addgoalbtn.Name = "Addgoalbtn";
            this.Addgoalbtn.Size = new System.Drawing.Size(170, 50);
            this.Addgoalbtn.TabIndex = 19;
            this.Addgoalbtn.Text = "Add Goal";
            this.Addgoalbtn.UseVisualStyleBackColor = false;
            this.Addgoalbtn.Click += new System.EventHandler(this.Addgoalbtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(32)))), ((int)(((byte)(53)))));
            this.pictureBox2.Image = global::FitnessCLUB.Properties.Resources.Cross2;
            this.pictureBox2.Location = new System.Drawing.Point(1024, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter_1);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // lblMetric1
            // 
            this.lblMetric1.BackColor = System.Drawing.Color.Transparent;
            this.lblMetric1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric1.ForeColor = System.Drawing.Color.White;
            this.lblMetric1.Location = new System.Drawing.Point(133, 643);
            this.lblMetric1.Name = "lblMetric1";
            this.lblMetric1.Size = new System.Drawing.Size(78, 32);
            this.lblMetric1.TabIndex = 42;
            this.lblMetric1.Text = "Metric1";
            // 
            // lblMetric2
            // 
            this.lblMetric2.BackColor = System.Drawing.Color.Transparent;
            this.lblMetric2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric2.ForeColor = System.Drawing.Color.White;
            this.lblMetric2.Location = new System.Drawing.Point(400, 643);
            this.lblMetric2.Name = "lblMetric2";
            this.lblMetric2.Size = new System.Drawing.Size(78, 32);
            this.lblMetric2.TabIndex = 43;
            this.lblMetric2.Text = "Metric2";
            // 
            // lblMetric3
            // 
            this.lblMetric3.BackColor = System.Drawing.Color.Transparent;
            this.lblMetric3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetric3.ForeColor = System.Drawing.Color.White;
            this.lblMetric3.Location = new System.Drawing.Point(665, 643);
            this.lblMetric3.Name = "lblMetric3";
            this.lblMetric3.Size = new System.Drawing.Size(78, 32);
            this.lblMetric3.TabIndex = 44;
            this.lblMetric3.Text = "Metric3";
            // 
            // txtGoalName1
            // 
            this.txtGoalName1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtGoalName1.BorderColor = System.Drawing.Color.White;
            this.txtGoalName1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGoalName1.DefaultText = "";
            this.txtGoalName1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGoalName1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGoalName1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGoalName1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGoalName1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGoalName1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.txtGoalName1.ForeColor = System.Drawing.Color.Black;
            this.txtGoalName1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGoalName1.Location = new System.Drawing.Point(133, 203);
            this.txtGoalName1.Margin = new System.Windows.Forms.Padding(4);
            this.txtGoalName1.Name = "txtGoalName1";
            this.txtGoalName1.PasswordChar = '\0';
            this.txtGoalName1.PlaceholderText = "Ex: Swimming 220m";
            this.txtGoalName1.SelectedText = "";
            this.txtGoalName1.Size = new System.Drawing.Size(652, 47);
            this.txtGoalName1.TabIndex = 45;
            // 
            // txtTime
            // 
            this.txtTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTime.BorderColor = System.Drawing.Color.White;
            this.txtTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTime.DefaultText = "";
            this.txtTime.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTime.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTime.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTime.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.txtTime.ForeColor = System.Drawing.Color.Black;
            this.txtTime.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTime.Location = new System.Drawing.Point(601, 487);
            this.txtTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtTime.Name = "txtTime";
            this.txtTime.PasswordChar = '\0';
            this.txtTime.PlaceholderText = "In 24 hrs, Ex: 13:00";
            this.txtTime.SelectedText = "";
            this.txtTime.Size = new System.Drawing.Size(267, 47);
            this.txtTime.TabIndex = 46;
            // 
            // txtMetric1
            // 
            this.txtMetric1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMetric1.BorderColor = System.Drawing.Color.White;
            this.txtMetric1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMetric1.DefaultText = "";
            this.txtMetric1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMetric1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMetric1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMetric1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMetric1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMetric1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.txtMetric1.ForeColor = System.Drawing.Color.Black;
            this.txtMetric1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMetric1.Location = new System.Drawing.Point(133, 679);
            this.txtMetric1.Margin = new System.Windows.Forms.Padding(4);
            this.txtMetric1.Name = "txtMetric1";
            this.txtMetric1.PasswordChar = '\0';
            this.txtMetric1.PlaceholderText = "Detail";
            this.txtMetric1.SelectedText = "";
            this.txtMetric1.Size = new System.Drawing.Size(210, 47);
            this.txtMetric1.TabIndex = 47;
            this.txtMetric1.MouseEnter += new System.EventHandler(this.txtMetric1_MouseEnter);
            this.txtMetric1.MouseLeave += new System.EventHandler(this.txtMetric1_MouseLeave);
            // 
            // txtMetric2
            // 
            this.txtMetric2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMetric2.BorderColor = System.Drawing.Color.White;
            this.txtMetric2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMetric2.DefaultText = "";
            this.txtMetric2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMetric2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMetric2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMetric2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMetric2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMetric2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.txtMetric2.ForeColor = System.Drawing.Color.Black;
            this.txtMetric2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMetric2.Location = new System.Drawing.Point(400, 679);
            this.txtMetric2.Margin = new System.Windows.Forms.Padding(4);
            this.txtMetric2.Name = "txtMetric2";
            this.txtMetric2.PasswordChar = '\0';
            this.txtMetric2.PlaceholderText = "Detail";
            this.txtMetric2.SelectedText = "";
            this.txtMetric2.Size = new System.Drawing.Size(210, 47);
            this.txtMetric2.TabIndex = 48;
            // 
            // txtMetric3
            // 
            this.txtMetric3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMetric3.BorderColor = System.Drawing.Color.White;
            this.txtMetric3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMetric3.DefaultText = "";
            this.txtMetric3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMetric3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMetric3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMetric3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMetric3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMetric3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.txtMetric3.ForeColor = System.Drawing.Color.Black;
            this.txtMetric3.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMetric3.Location = new System.Drawing.Point(665, 679);
            this.txtMetric3.Margin = new System.Windows.Forms.Padding(4);
            this.txtMetric3.Name = "txtMetric3";
            this.txtMetric3.PasswordChar = '\0';
            this.txtMetric3.PlaceholderText = "Detail";
            this.txtMetric3.SelectedText = "";
            this.txtMetric3.Size = new System.Drawing.Size(210, 47);
            this.txtMetric3.TabIndex = 49;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(133, 733);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 58);
            this.panel1.TabIndex = 52;
            this.panel1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "3. intense";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "2. moderate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "1. light";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type means the Intensity of Exercise";
            // 
            // Goal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FitnessCLUB.Properties.Resources.Goal1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtMetric3);
            this.Controls.Add(this.txtMetric2);
            this.Controls.Add(this.txtMetric1);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtGoalName1);
            this.Controls.Add(this.lblMetric3);
            this.Controls.Add(this.lblMetric2);
            this.Controls.Add(this.lblMetric1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Addgoalbtn);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.select_Excercise);
            this.DoubleBuffered = true;
            this.Name = "Goal";
            this.Size = new System.Drawing.Size(1070, 938);
            this.Load += new System.EventHandler(this.Goal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox select_Excercise;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button Addgoalbtn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMetric1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMetric2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMetric3;
        private Guna.UI2.WinForms.Guna2TextBox txtGoalName1;
        private Guna.UI2.WinForms.Guna2TextBox txtTime;
        private Guna.UI2.WinForms.Guna2TextBox txtMetric1;
        private Guna.UI2.WinForms.Guna2TextBox txtMetric2;
        private Guna.UI2.WinForms.Guna2TextBox txtMetric3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
