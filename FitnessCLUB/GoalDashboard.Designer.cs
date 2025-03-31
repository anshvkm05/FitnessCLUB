namespace FitnessCLUB.Resources
{
    partial class GoalDashboard
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
            this.lblGoalName = new System.Windows.Forms.Label();
            this.lblGoalDate = new System.Windows.Forms.Label();
            this.lblGoalTime = new System.Windows.Forms.Label();
            this.checkBoxComplete = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.SuspendLayout();
            // 
            // lblGoalName
            // 
            this.lblGoalName.AutoSize = true;
            this.lblGoalName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalName.Location = new System.Drawing.Point(3, 0);
            this.lblGoalName.Name = "lblGoalName";
            this.lblGoalName.Size = new System.Drawing.Size(110, 25);
            this.lblGoalName.TabIndex = 0;
            this.lblGoalName.Text = "Goal Name";
            // 
            // lblGoalDate
            // 
            this.lblGoalDate.AutoSize = true;
            this.lblGoalDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalDate.Location = new System.Drawing.Point(8, 26);
            this.lblGoalDate.Name = "lblGoalDate";
            this.lblGoalDate.Size = new System.Drawing.Size(46, 17);
            this.lblGoalDate.TabIndex = 1;
            this.lblGoalDate.Text = "13 FEB";
            // 
            // lblGoalTime
            // 
            this.lblGoalTime.AutoSize = true;
            this.lblGoalTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalTime.Location = new System.Drawing.Point(107, 25);
            this.lblGoalTime.Name = "lblGoalTime";
            this.lblGoalTime.Size = new System.Drawing.Size(37, 17);
            this.lblGoalTime.TabIndex = 2;
            this.lblGoalTime.Text = "13:00";
            // 
            // checkBoxComplete
            // 
            this.checkBoxComplete.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.checkBoxComplete.CheckedState.BorderRadius = 2;
            this.checkBoxComplete.CheckedState.BorderThickness = 0;
            this.checkBoxComplete.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(247)))), ((int)(((byte)(226)))));
            this.checkBoxComplete.Location = new System.Drawing.Point(393, 10);
            this.checkBoxComplete.Name = "checkBoxComplete";
            this.checkBoxComplete.Size = new System.Drawing.Size(20, 20);
            this.checkBoxComplete.TabIndex = 4;
            this.checkBoxComplete.Text = "checkBoxComplete";
            this.checkBoxComplete.UncheckedState.BorderColor = System.Drawing.Color.White;
            this.checkBoxComplete.UncheckedState.BorderRadius = 2;
            this.checkBoxComplete.UncheckedState.BorderThickness = 2;
            this.checkBoxComplete.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(32)))), ((int)(((byte)(53)))));
            this.checkBoxComplete.Click += new System.EventHandler(this.guna2CustomCheckBox1_Click);
            // 
            // GoalDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxComplete);
            this.Controls.Add(this.lblGoalTime);
            this.Controls.Add(this.lblGoalDate);
            this.Controls.Add(this.lblGoalName);
            this.Name = "GoalDashboard";
            this.Size = new System.Drawing.Size(420, 42);
            this.Load += new System.EventHandler(this.GoalDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGoalName;
        private System.Windows.Forms.Label lblGoalDate;
        private System.Windows.Forms.Label lblGoalTime;
        private Guna.UI2.WinForms.Guna2CustomCheckBox checkBoxComplete;
    }
}
