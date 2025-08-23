namespace ClienteRecebe
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
            this.ltbMostra = new System.Windows.Forms.ListBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtEnvia = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ltbMostra
            // 
            this.ltbMostra.FormattingEnabled = true;
            this.ltbMostra.Location = new System.Drawing.Point(56, 78);
            this.ltbMostra.Name = "ltbMostra";
            this.ltbMostra.Size = new System.Drawing.Size(682, 238);
            this.ltbMostra.TabIndex = 8;
            this.ltbMostra.SelectedIndexChanged += new System.EventHandler(this.ltbMostra_SelectedIndexChanged);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(663, 339);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtEnvia
            // 
            this.txtEnvia.Location = new System.Drawing.Point(56, 339);
            this.txtEnvia.Name = "txtEnvia";
            this.txtEnvia.Size = new System.Drawing.Size(483, 20);
            this.txtEnvia.TabIndex = 6;
            this.txtEnvia.TextChanged += new System.EventHandler(this.txtEnvia_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ltbMostra);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtEnvia);
            this.Name = "Form1";
            this.Text = "Enviar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ltbMostra;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtEnvia;
    }
}

