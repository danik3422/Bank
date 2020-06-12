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
            this.back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // balance_button
            // 
            this.balance_button.Location = new System.Drawing.Point(424, 23);
            this.balance_button.Name = "balance_button";
            this.balance_button.Size = new System.Drawing.Size(110, 52);
            this.balance_button.TabIndex = 0;
            this.balance_button.Text = "Balance";
            this.balance_button.UseVisualStyleBackColor = true;
            this.balance_button.Click += new System.EventHandler(this.balance_button_Click);
            // 
            // cash_button
            // 
            this.cash_button.Location = new System.Drawing.Point(424, 94);
            this.cash_button.Name = "cash_button";
            this.cash_button.Size = new System.Drawing.Size(110, 62);
            this.cash_button.TabIndex = 1;
            this.cash_button.Text = "CASH WITHDRAWAL";
            this.cash_button.UseVisualStyleBackColor = true;
            this.cash_button.Click += new System.EventHandler(this.cash_button_Click);
            // 
            // transfer_button
            // 
            this.transfer_button.Location = new System.Drawing.Point(424, 180);
            this.transfer_button.Name = "transfer_button";
            this.transfer_button.Size = new System.Drawing.Size(110, 62);
            this.transfer_button.TabIndex = 2;
            this.transfer_button.Text = "Przelew";
            this.transfer_button.UseVisualStyleBackColor = true;
            this.transfer_button.Click += new System.EventHandler(this.transfer_button_Click);
            // 
            // change_pin_button
            // 
            this.change_pin_button.Location = new System.Drawing.Point(424, 268);
            this.change_pin_button.Name = "change_pin_button";
            this.change_pin_button.Size = new System.Drawing.Size(110, 62);
            this.change_pin_button.TabIndex = 3;
            this.change_pin_button.Text = "Change PIN";
            this.change_pin_button.UseVisualStyleBackColor = true;
            this.change_pin_button.Click += new System.EventHandler(this.change_pin_Click);
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(34, 366);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(110, 62);
            this.back_button.TabIndex = 4;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.change_pin_button);
            this.Controls.Add(this.transfer_button);
            this.Controls.Add(this.cash_button);
            this.Controls.Add(this.balance_button);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button balance_button;
        private System.Windows.Forms.Button cash_button;
        private System.Windows.Forms.Button transfer_button;
        private System.Windows.Forms.Button change_pin_button;
        private System.Windows.Forms.Button back_button;
    }
}