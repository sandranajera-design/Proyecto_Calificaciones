namespace Proyecto_Calificaciones
{
    partial class VerListaGrupos2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SeleccionarGrupo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 31);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(853, 508);
            this.dataGridView1.TabIndex = 0;
            // 
            // SeleccionarGrupo
            // 
            this.SeleccionarGrupo.BackColor = System.Drawing.Color.RoyalBlue;
            this.SeleccionarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.SeleccionarGrupo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SeleccionarGrupo.Location = new System.Drawing.Point(900, 184);
            this.SeleccionarGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SeleccionarGrupo.Name = "SeleccionarGrupo";
            this.SeleccionarGrupo.Size = new System.Drawing.Size(151, 57);
            this.SeleccionarGrupo.TabIndex = 1;
            this.SeleccionarGrupo.Text = "Seleccionar Grupo";
            this.SeleccionarGrupo.UseVisualStyleBackColor = false;
            this.SeleccionarGrupo.Click += new System.EventHandler(this.btnSeleccionarGrupo_Click);
            // 
            // VerListaGrupos2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Calificaciones.Properties.Resources.Fondo;
            this.ClientSize = new System.Drawing.Size(1063, 626);
            this.Controls.Add(this.SeleccionarGrupo);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "VerListaGrupos2";
            this.Text = "VerListaGrupos2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VerListaGrupos2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SeleccionarGrupo;
    }
}