namespace Bankomat
{
    partial class MenuForm
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
            this.balance_button = new System.Windows.Forms.Button();
            this.cash_button = new System.Windows.Forms.Button();
            this.transfer_button = new System.Windows.Forms.Button();
            this.change_pin_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // balance_button
            // 
            this.balance_button.Location = new System.Drawing.Point(113, 83);
            this.balance_button.Name = "balance_button";
            this.balance_button.Size = new System.Drawing.Size(122, 70);
            this.balance_button.TabIndex = 0;
            this.balance_button.Text = "Balance";
            this.balance_button.UseVisualStyleBackColor = true;
            this.balance_button.Click += new System.EventHandler(this.balance_button_Click);
            // 
            // cash_button
            // 
            this.cash_button.Location = new System.Drawing.Point(544, 83);
            this.cash_button.Name = "cash_button";
            this.cash_button.Size = new System.Drawing.Size(122, 70);
            this.cash_button.TabIndex = 1;
            this.cash_button.Text = "CASH WITHDRAWAL";
            this.cash_button.UseVisualStyleBackColor = true;
            this.cash_button.Click += new System.EventHandler(this.cash_button_Click);
            // 
            // transfer_button
            // 
            this.transfer_button.Location = new System.Drawing.Point(113, 291);
            this.transfer_button.Name = "transfer_button";
            this.transfer_button.Size = new System.Drawing.Size(122, 70);
            this.transfer_button.TabIndex = 2;
            this.transfer_button.Text = "Przelew";
            this.transfer_button.UseVisualStyleBackColor = true;
            this.transfer_button.Click += new System.EventHandler(this.transfer_button_Click);
            // 
            // change_pin_button
            // 
            this.change_pin_button.Location = new System.Drawing.Point(544, 291);
            this.change_pin_button.Name = "change_pin_button";
            this.change_pin_button.Size = new System.Drawing.Size(122, 70);
            this.change_pin_button.TabIndex = 3;
            this.change_pin_button.Text = "Change PIN";
            this.change_pin_button.UseVisualStyleBackColor = true;
            this.change_pin_button.Click += new System.EventHandler(this.change_pin_Click);
            // 
            // exit_button
            // 
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit_button.Location = new System.Drawing.Point(698, 387);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(94, 62);
            this.exit_button.TabIndex = 4;
            this.exit_button.TabStop = false;
            this.exit_button.Text = "Wyjmij Karte";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bankomat.Properties.Resources.bankomaty_ArticleWithImgDesc2_M;
            this.pictureBox1.Location = new System.Drawing.Point(241, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(297, 278);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.change_pin_button);
            this.Controls.Add(this.transfer_button);
            this.Controls.Add(this.cash_button);
            this.Controls.Add(this.balance_button);
            this.Name = "MenuForm";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button balance_button;
        private System.Windows.Forms.Button cash_button;
        private System.Windows.Forms.Button transfer_button;
        private System.Windows.Forms.Button change_pin_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}