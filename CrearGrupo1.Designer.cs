namespace Proyecto_Calificaciones
{
    partial class CrearGrupo1
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
            this.txtNombreGrupo = new System.Windows.Forms.TextBox();
            this.txtCantidadApartados = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminarGrupo = new System.Windows.Forms.Button();
            this.btnVerListaGrupos = new System.Windows.Forms.Button();
            this.btnCrearNuevoGrupo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.panelSistema = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSistema.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el nombre del grupo";
            // 
            // txtNombreGrupo
            // 
            this.txtNombreGrupo.Location = new System.Drawing.Point(190, 58);
            this.txtNombreGrupo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombreGrupo.Name = "txtNombreGrupo";
            this.txtNombreGrupo.Size = new System.Drawing.Size(140, 20);
            this.txtNombreGrupo.TabIndex = 1;
            // 
            // txtCantidadApartados
            // 
            this.txtCantidadApartados.Location = new System.Drawing.Point(194, 145);
            this.txtCantidadApartados.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCantidadApartados.Name = "txtCantidadApartados";
            this.txtCantidadApartados.Size = new System.Drawing.Size(152, 20);
            this.txtCantidadApartados.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese la cantidad de apartados";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(194, 223);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(116, 44);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnSalir);
            this.panelMenu.Controls.Add(this.btnEliminarGrupo);
            this.panelMenu.Controls.Add(this.btnVerListaGrupos);
            this.panelMenu.Controls.Add(this.btnCrearNuevoGrupo);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(178, 352);
            this.panelMenu.TabIndex = 5;
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(60, 261);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(114, 58);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminarGrupo
            // 
            this.btnEliminarGrupo.FlatAppearance.BorderSize = 0;
            this.btnEliminarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarGrupo.Location = new System.Drawing.Point(60, 199);
            this.btnEliminarGrupo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminarGrupo.Name = "btnEliminarGrupo";
            this.btnEliminarGrupo.Size = new System.Drawing.Size(114, 58);
            this.btnEliminarGrupo.TabIndex = 9;
            this.btnEliminarGrupo.Text = "Eliminar grupo";
            this.btnEliminarGrupo.UseVisualStyleBackColor = true;
            this.btnEliminarGrupo.Click += new System.EventHandler(this.btnEliminarGrupo_Click);
            // 
            // btnVerListaGrupos
            // 
            this.btnVerListaGrupos.FlatAppearance.BorderSize = 0;
            this.btnVerListaGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerListaGrupos.Location = new System.Drawing.Point(60, 133);
            this.btnVerListaGrupos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVerListaGrupos.Name = "btnVerListaGrupos";
            this.btnVerListaGrupos.Size = new System.Drawing.Size(114, 58);
            this.btnVerListaGrupos.TabIndex = 8;
            this.btnVerListaGrupos.Text = "Ver lista de grupos";
            this.btnVerListaGrupos.UseVisualStyleBackColor = true;
            this.btnVerListaGrupos.Click += new System.EventHandler(this.btnVerListaGrupos_Click);
            // 
            // btnCrearNuevoGrupo
            // 
            this.btnCrearNuevoGrupo.FlatAppearance.BorderSize = 0;
            this.btnCrearNuevoGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearNuevoGrupo.Location = new System.Drawing.Point(60, 72);
            this.btnCrearNuevoGrupo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCrearNuevoGrupo.Name = "btnCrearNuevoGrupo";
            this.btnCrearNuevoGrupo.Size = new System.Drawing.Size(114, 58);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 52);
            this.panel1.TabIndex = 5;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Location = new System.Drawing.Point(3, 6);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(28, 40);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.Text = "☰";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panelSistema
            // 
            this.panelSistema.Controls.Add(this.label2);
            this.panelSistema.Controls.Add(this.label1);
            this.panelSistema.Controls.Add(this.btnSiguiente);
            this.panelSistema.Controls.Add(this.txtNombreGrupo);
            this.panelSistema.Controls.Add(this.txtCantidadApartados);
            this.panelSistema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSistema.Location = new System.Drawing.Point(178, 0);
            this.panelSistema.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelSistema.Name = "panelSistema";
            this.panelSistema.Size = new System.Drawing.Size(507, 352);
            this.panelSistema.TabIndex = 7;
            this.panelSistema.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSistema_Paint);
            // 
            // CrearGrupo1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 352);
            this.Controls.Add(this.panelSistema);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "CrearGrupo1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrearGrupo1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelSistema.ResumeLayout(false);
            this.panelSistema.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreGrupo;
        private System.Windows.Forms.TextBox txtCantidadApartados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnCrearNuevoGrupo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelSistema;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminarGrupo;
        private System.Windows.Forms.Button btnVerListaGrupos;
    }
}