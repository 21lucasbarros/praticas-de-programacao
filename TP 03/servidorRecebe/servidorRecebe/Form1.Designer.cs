namespace servidorRecebe
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
            this.ltbRecebe = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ltbRecebe
            // 
            this.ltbRecebe.FormattingEnabled = true;
            this.ltbRecebe.Location = new System.Drawing.Point(62, 146);
            this.ltbRecebe.Name = "ltbRecebe";
            this.ltbRecebe.Size = new System.Drawing.Size(653, 264);
            this.ltbRecebe.TabIndex = 1;
            this.ltbRecebe.SelectedIndexChanged += new System.EventHandler(this.ltbRecebe_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(653, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ativar recebimento";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ltbRecebe);
            this.Name = "Form1";
            this.Text = "Receber";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ltbRecebe;
        private System.Windows.Forms.Button button1;
    }
}

