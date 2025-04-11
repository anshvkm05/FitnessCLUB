namespace FitnessCLUB
{
    partial class ActivityDashboard
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
            this.lblCalories = new System.Windows.Forms.Label();
            this.lblGoalTime = new System.Windows.Forms.Label();
            this.lblGoalDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGoalName
            // 
            this.lblGoalName.AutoSize = true;
            this.lblGoalName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalName.Location = new System.Drawing.Point(3, -1);
            this.lblGoalName.Name = "lblGoalName";
            this.lblGoalName.Size = new System.Drawing.Size(130, 25);
            this.lblGoalName.TabIndex = 1;
            this.lblGoalName.Text = "ActivityName";
            // 
            // lblCalories
            // 
            this.lblCalories.AutoSize = true;
            this.lblCalories.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalories.Location = new System.Drawing.Point(229, 21);
            this.lblCalories.Name = "lblCalories";
            this.lblCalories.Size = new System.Drawing.Size(24, 17);
            this.lblCalories.TabIndex = 8;
            this.lblCalories.Text = "cal";
            // 
            // lblGoalTime
            // 
            this.lblGoalTime.AutoSize = true;
            this.lblGoalTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalTime.Location = new System.Drawing.Point(112, 22);
            this.lblGoalTime.Name = "lblGoalTime";
            this.lblGoalTime.Size = new System.Drawing.Size(37, 17);
            this.lblGoalTime.TabIndex = 7;
            this.lblGoalTime.Text = "13:00";
            // 
            // lblGoalDate
            // 
            this.lblGoalDate.AutoSize = true;
            this.lblGoalDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalDate.Location = new System.Drawing.Point(5, 22);
            this.lblGoalDate.Name = "lblGoalDate";
            this.lblGoalDate.Size = new System.Drawing.Size(46, 17);
            this.lblGoalDate.TabIndex = 6;
            this.lblGoalDate.Text = "13 FEB";
            // 
            // ActivityDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblCalories);
            this.Controls.Add(this.lblGoalTime);
            this.Controls.Add(this.lblGoalDate);
            this.Controls.Add(this.lblGoalName);
            this.Name = "ActivityDashboard";
            this.Size = new System.Drawing.Size(412, 40);
            this.Load += new System.EventHandler(this.ActivityDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGoalName;
        private System.Windows.Forms.Label lblCalories;
        private System.Windows.Forms.Label lblGoalTime;
        private System.Windows.Forms.Label lblGoalDate;
    }
}
