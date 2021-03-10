
namespace RCPylonRaceManagerWithSQLServer.Forms
{
    partial class EntryForm
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
            this.ShowSeason = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ShowSeason
            // 
            this.ShowSeason.Location = new System.Drawing.Point(308, 113);
            this.ShowSeason.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowSeason.Name = "ShowSeason";
            this.ShowSeason.Size = new System.Drawing.Size(82, 22);
            this.ShowSeason.TabIndex = 0;
            this.ShowSeason.Text = "Show Season";
            this.ShowSeason.UseVisualStyleBackColor = true;
            this.ShowSeason.Click += new System.EventHandler(this.ShowSeason_Click);
            // 
            // Quit
            // 
            this.Quit.Location = new System.Drawing.Point(308, 233);
            this.Quit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(82, 22);
            this.Quit.TabIndex = 1;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.ShowSeason);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EntryForm";
            this.Text = "EntryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShowSeason;
        private System.Windows.Forms.Button Quit;
    }
}