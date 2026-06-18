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
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(326, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Qué desea hacer?";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCrearNuevoGrupo
            // 
            this.btnCrearNuevoGrupo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnCrearNuevoGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearNuevoGrupo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCrearNuevoGrupo.Location = new System.Drawing.Point(183, 148);
            this.btnCrearNuevoGrupo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrearNuevoGrupo.Name = "btnCrearNuevoGrupo";
            this.btnCrearNuevoGrupo.Size = new System.Drawing.Size(562, 120);
            this.btnCrearNuevoGrupo.TabIndex = 1;
            this.btnCrearNuevoGrupo.Text = "Crear nuevo grupo";
            this.btnCrearNuevoGrupo.UseVisualStyleBackColor = false;
            this.btnCrearNuevoGrupo.Click += new System.EventHandler(this.btnCrearNuevoGrupo_Click);
            // 
            // btnVerListaGrupos
            // 
            this.btnVerListaGrupos.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnVerListaGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold);
            this.btnVerListaGrupos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVerListaGrupos.Location = new System.Drawing.Point(183, 148);
            this.btnVerListaGrupos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerListaGrupos.Name = "btnVerListaGrupos";
            this.btnVerListaGrupos.Size = new System.Drawing.Size(562, 120);
            this.btnVerListaGrupos.TabIndex = 2;
            this.btnVerListaGrupos.Text = "Ver lista de grupos";
            this.btnVerListaGrupos.UseVisualStyleBackColor = false;
            this.btnVerListaGrupos.Click += new System.EventHandler(this.btnVerListaGrupos_Click);
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEliminarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold);
            this.btnEliminarGrupo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminarGrupo.Location = new System.Drawing.Point(183, 148);
            this.btnEliminarGrupo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(562, 120);
            this.btnEliminarGrupo.TabIndex = 3;
            this.btnEliminarGrupo.Text = "Eliminar grupo";
            this.btnEliminarGrupo.UseVisualStyleBackColor = false;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Location = new System.Drawing.Point(183, 148);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(562, 120);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Georgia", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 91);
            this.label2.TabIndex = 5;
            this.label2.Text = "MENU";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Calificaciones.Properties.Resources.Fondo;
            this.ClientSize = new System.Drawing.Size(913, 550);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminarGrupo);
            this.Controls.Add(this.btnVerListaGrupos);
            this.Controls.Add(this.btnCrearNuevoGrupo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label label2;
    }
}