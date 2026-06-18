namespace Proyecto_Calificaciones
{
    partial class EliminarGrupo1
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.btnVerListaGrupos = new System.Windows.Forms.Button();
            this.btnCrearNuevoGrupo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.SteelBlue;
            this.panelMenu.Controls.Add(this.btnSalir);
            this.panelMenu.Controls.Add(this.btnEliminarGrupo);
            this.panelMenu.Controls.Add(this.btnVerListaGrupos);
            this.panelMenu.Controls.Add(this.btnCrearNuevoGrupo);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(237, 433);
            this.panelMenu.TabIndex = 10;
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalir.Location = new System.Drawing.Point(80, 321);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(152, 71);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.FlatAppearance.BorderSize = 0;
            this.btnEliminarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEliminarGrupo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEliminarGrupo.Location = new System.Drawing.Point(80, 245);
            this.btnEliminarGrupo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(152, 71);
            this.btnEliminarGrupo.TabIndex = 9;
            this.btnEliminarGrupo.Text = "Eliminar grupo";
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnVerListaGrupos
            // 
            this.btnVerListaGrupos.FlatAppearance.BorderSize = 0;
            this.btnVerListaGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerListaGrupos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnVerListaGrupos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVerListaGrupos.Location = new System.Drawing.Point(80, 164);
            this.btnVerListaGrupos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerListaGrupos.Name = "btnVerListaGrupos";
            this.btnVerListaGrupos.Size = new System.Drawing.Size(152, 71);
            this.btnVerListaGrupos.TabIndex = 8;
            this.btnVerListaGrupos.Text = "Ver lista de grupos";
            this.btnVerListaGrupos.UseVisualStyleBackColor = true;
            this.btnVerListaGrupos.Click += new System.EventHandler(this.btnVerListaGrupos_Click);
            // 
            // btnCrearNuevoGrupo
            // 
            this.btnCrearNuevoGrupo.FlatAppearance.BorderSize = 0;
            this.btnCrearNuevoGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearNuevoGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnCrearNuevoGrupo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCrearNuevoGrupo.Location = new System.Drawing.Point(80, 89);
            this.btnCrearNuevoGrupo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrearNuevoGrupo.Name = "btnCrearNuevoGrupo";
            this.btnCrearNuevoGrupo.Size = new System.Drawing.Size(152, 71);
            this.btnCrearNuevoGrupo.TabIndex = 7;
            this.btnCrearNuevoGrupo.Text = "Crear Nuevo Grupo";
            this.btnCrearNuevoGrupo.UseVisualStyleBackColor = true;
            this.btnCrearNuevoGrupo.Click += new System.EventHandler(this.btnCrearNuevoGrupo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 64);
            this.panel1.TabIndex = 5;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(4, 7);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(37, 49);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.Text = "☰";
            this.btnMenu.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(484, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Seleccione el grupo a eliminar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(375, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(482, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "** muestra en botones los grupos disponibles de manera dinamica **";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(375, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(468, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "** al seleccionar el grupo muestra message box de confirmacion **";
            // 
            // EliminarGrupo1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.BackgroundImage = global::Proyecto_Calificaciones.Properties.Resources.Fondo;
            this.ClientSize = new System.Drawing.Size(913, 433);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EliminarGrupo1";
            this.Text = "EliminarGrupo1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EliminarGrupo1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.Button btnVerListaGrupos;
        private System.Windows.Forms.Button btnCrearNuevoGrupo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}