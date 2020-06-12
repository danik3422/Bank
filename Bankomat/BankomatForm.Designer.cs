namespace Bankomat
{
    partial class Bankomat
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
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfCard = new System.Windows.Forms.TextBox();
            this.btnstart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podaj numer Konta:";
            // 
            // numberOfCard
            // 
            this.numberOfCard.Location = new System.Drawing.Point(196, 168);
            this.numberOfCard.Name = "numberOfCard";
            this.numberOfCard.Size = new System.Drawing.Size(349, 20);
            this.numberOfCard.TabIndex = 1;
            this.numberOfCard.MaxLength = 26;
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(268, 217);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(208, 85);
            this.btnstart.TabIndex = 2;
            this.btnstart.Text = "Wlóż kartę";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // Bankomat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.numberOfCard);
            this.Controls.Add(this.label1);
            this.Name = "Bankomat";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numberOfCard;
        private System.Windows.Forms.Button btnstart;
    }
}

