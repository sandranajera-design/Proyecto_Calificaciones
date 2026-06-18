namespace Proyecto_Calificaciones
{
    partial class Menu
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
            this.btnCrearNuevoGrupo = new System.Windows.Forms.Button();
            this.btnVerListaGrupos = new System.Windows.Forms.Button();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Que desea hacer?";
            // 
            // btnCrearNuevoGrupo
            // 
            this.btnCrearNuevoGrupo.Location = new System.Drawing.Point(352, 79);
            this.btnCrearNuevoGrupo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCrearNuevoGrupo.Name = "btnCrearNuevoGrupo";
            this.btnCrearNuevoGrupo.Size = new System.Drawing.Size(145, 59);
            this.btnCrearNuevoGrupo.TabIndex = 1;
            this.btnCrearNuevoGrupo.Text = "Crear nuevo grupo";
            this.btnCrearNuevoGrupo.UseVisualStyleBackColor = true;
            this.btnCrearNuevoGrupo.Click += new System.EventHandler(this.btnCrearNuevoGrupo_Click);
            // 
            // btnVerListaGrupos
            // 
            this.btnVerListaGrupos.Location = new System.Drawing.Point(352, 153);
            this.btnVerListaGrupos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVerListaGrupos.Name = "btnVerListaGrupos";
            this.btnVerListaGrupos.Size = new System.Drawing.Size(145, 59);
            this.btnVerListaGrupos.TabIndex = 2;
            this.btnVerListaGrupos.Text = "Ver lista de grupos";
            this.btnVerListaGrupos.UseVisualStyleBackColor = true;
            this.btnVerListaGrupos.Click += new System.EventHandler(this.btnVerListaGrupos_Click);
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.Location = new System.Drawing.Point(352, 228);
            this.btnEliminarGrupo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(145, 59);
            this.btnEliminarGrupo.TabIndex = 3;
            this.btnEliminarGrupo.Text = "Eliminar grupo";
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(352, 306);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(145, 59);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 382);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminarGrupo);
            this.Controls.Add(this.btnVerListaGrupos);
            this.Controls.Add(this.btnCrearNuevoGrupo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Menu";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrearNuevoGrupo;
        private System.Windows.Forms.Button btnVerListaGrupos;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.Button btnSalir;
    }
}