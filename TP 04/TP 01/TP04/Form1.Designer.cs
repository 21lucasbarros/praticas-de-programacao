namespace TP04
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ltbMostra = new System.Windows.Forms.ListBox();
            this.txtEnvia = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.ltbRecebe = new System.Windows.Forms.ListBox();
            this.btnAtivar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ltbMostra
            // 
            this.ltbMostra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbMostra.FormattingEnabled = true;
            this.ltbMostra.ItemHeight = 24;
            this.ltbMostra.Location = new System.Drawing.Point(30, 40);
            this.ltbMostra.Name = "ltbMostra";
            this.ltbMostra.Size = new System.Drawing.Size(344, 364);
            this.ltbMostra.TabIndex = 0;
            // 
            // txtEnvia
            // 
            this.txtEnvia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnvia.Location = new System.Drawing.Point(30, 442);
            this.txtEnvia.Name = "txtEnvia";
            this.txtEnvia.Size = new System.Drawing.Size(243, 29);
            this.txtEnvia.TabIndex = 1;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(303, 442);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(71, 29);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // ltbRecebe
            // 
            this.ltbRecebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbRecebe.FormattingEnabled = true;
            this.ltbRecebe.ItemHeight = 24;
            this.ltbRecebe.Location = new System.Drawing.Point(448, 40);
            this.ltbRecebe.Name = "ltbRecebe";
            this.ltbRecebe.Size = new System.Drawing.Size(344, 364);
            this.ltbRecebe.TabIndex = 3;
            // 
            // btnAtivar
            // 
            this.btnAtivar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtivar.Location = new System.Drawing.Point(531, 442);
            this.btnAtivar.Name = "btnAtivar";
            this.btnAtivar.Size = new System.Drawing.Size(177, 29);
            this.btnAtivar.TabIndex = 4;
            this.btnAtivar.Text = "Ativar recebimento";
            this.btnAtivar.UseVisualStyleBackColor = true;
            this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 584);
            this.Controls.Add(this.btnAtivar);
            this.Controls.Add(this.ltbRecebe);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtEnvia);
            this.Controls.Add(this.ltbMostra);
            this.Name = "Form1";
            this.Text = "Enviar e Receber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ltbMostra;
        private System.Windows.Forms.TextBox txtEnvia;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ListBox ltbRecebe;
        private System.Windows.Forms.Button btnAtivar;
    }
}

