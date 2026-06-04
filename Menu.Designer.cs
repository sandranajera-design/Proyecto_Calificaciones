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
            this.label1.Location = new System.Drawing.Point(747, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Que desea hacer?";
            // 
            // btnCrearNuevoGrupo
            // 
            this.btnCrearNuevoGrupo.Location = new System.Drawing.Point(703, 152);
            this.btnCrearNuevoGrupo.Name = "btnCrearNuevoGrupo";
            this.btnCrearNuevoGrupo.Size = new System.Drawing.Size(290, 113);
            this.btnCrearNuevoGrupo.TabIndex = 1;
            this.btnCrearNuevoGrupo.Text = "Crear nuevo grupo";
            this.btnCrearNuevoGrupo.UseVisualStyleBackColor = true;
            // 
            // btnVerListaGrupos
            // 
            this.btnVerListaGrupos.Location = new System.Drawing.Point(703, 295);
            this.btnVerListaGrupos.Name = "btnVerListaGrupos";
            this.btnVerListaGrupos.Size = new System.Drawing.Size(290, 113);
            this.btnVerListaGrupos.TabIndex = 2;
            this.btnVerListaGrupos.Text = "Ver lista de grupos";
            this.btnVerListaGrupos.UseVisualStyleBackColor = true;
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.Location = new System.Drawing.Point(703, 439);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(290, 113);
            this.btnEliminarGrupo.TabIndex = 3;
            this.btnEliminarGrupo.Text = "Eliminar grupo";
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(703, 589);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(290, 113);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 734);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminarGrupo);
            this.Controls.Add(this.btnVerListaGrupos);
            this.Controls.Add(this.btnCrearNuevoGrupo);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
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