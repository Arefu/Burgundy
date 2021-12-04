namespace Burgundy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Load_TT = new System.Windows.Forms.Button();
            this.Load_Effort = new System.Windows.Forms.Button();
            this.Process = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ignoreClasses = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Load_TT
            // 
            this.Load_TT.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load_TT.Location = new System.Drawing.Point(12, 12);
            this.Load_TT.Name = "Load_TT";
            this.Load_TT.Size = new System.Drawing.Size(110, 25);
            this.Load_TT.TabIndex = 0;
            this.Load_TT.Text = "Load TT";
            this.Load_TT.UseVisualStyleBackColor = true;
            this.Load_TT.Click += new System.EventHandler(this.Load_TT_Click);
            // 
            // Load_Effort
            // 
            this.Load_Effort.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load_Effort.Location = new System.Drawing.Point(12, 43);
            this.Load_Effort.Name = "Load_Effort";
            this.Load_Effort.Size = new System.Drawing.Size(110, 25);
            this.Load_Effort.TabIndex = 1;
            this.Load_Effort.Text = "Load Efforts";
            this.Load_Effort.UseVisualStyleBackColor = true;
            this.Load_Effort.Click += new System.EventHandler(this.Load_Effort_Click);
            // 
            // Process
            // 
            this.Process.Location = new System.Drawing.Point(12, 76);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(110, 23);
            this.Process.TabIndex = 2;
            this.Process.Text = "Process";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ignore These Classes";
            // 
            // ignoreClasses
            // 
            this.ignoreClasses.Location = new System.Drawing.Point(16, 123);
            this.ignoreClasses.Name = "ignoreClasses";
            this.ignoreClasses.Size = new System.Drawing.Size(106, 20);
            this.ignoreClasses.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(134, 161);
            this.Controls.Add(this.ignoreClasses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Process);
            this.Controls.Add(this.Load_Effort);
            this.Controls.Add(this.Load_TT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Load_TT;
        private System.Windows.Forms.Button Load_Effort;
        private System.Windows.Forms.Button Process;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ignoreClasses;
    }
}

