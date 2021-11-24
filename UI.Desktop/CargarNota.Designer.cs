
namespace UI.Desktop
{
    partial class CargarNota
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvListaAlumnos = new System.Windows.Forms.DataGridView();
            this.btnCargarNota = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.IdInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvListaAlumnos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCargarNota, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvListaAlumnos
            // 
            this.dgvListaAlumnos.AllowUserToAddRows = false;
            this.dgvListaAlumnos.AllowUserToDeleteRows = false;
            this.dgvListaAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdInscripcion,
            this.Nombre,
            this.Apellido,
            this.Legajo,
            this.Condicion,
            this.Nota});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvListaAlumnos, 2);
            this.dgvListaAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaAlumnos.Location = new System.Drawing.Point(3, 3);
            this.dgvListaAlumnos.Name = "dgvListaAlumnos";
            this.dgvListaAlumnos.RowTemplate.Height = 25;
            this.dgvListaAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaAlumnos.Size = new System.Drawing.Size(794, 415);
            this.dgvListaAlumnos.TabIndex = 0;
            // 
            // btnCargarNota
            // 
            this.btnCargarNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarNota.Location = new System.Drawing.Point(631, 424);
            this.btnCargarNota.Name = "btnCargarNota";
            this.btnCargarNota.Size = new System.Drawing.Size(85, 23);
            this.btnCargarNota.TabIndex = 1;
            this.btnCargarNota.Text = "Cargar Notas";
            this.btnCargarNota.UseVisualStyleBackColor = true;
            this.btnCargarNota.Click += new System.EventHandler(this.btnCargarNota_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 424);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // IdInscripcion
            // 
            this.IdInscripcion.DataPropertyName = "ID inscripcion";
            this.IdInscripcion.HeaderText = "ID inscripcion";
            this.IdInscripcion.Name = "IdInscripcion";
            this.IdInscripcion.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.DataPropertyName = "Apellido";
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Legajo
            // 
            this.Legajo.DataPropertyName = "Legajo";
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            this.Legajo.ReadOnly = true;
            // 
            // Condicion
            // 
            this.Condicion.DataPropertyName = "Condicion";
            this.Condicion.HeaderText = "Condicion";
            this.Condicion.Items.AddRange(new object[] {
            "Cursando",
            "Libre",
            "Regular",
            "Promovido"});
            this.Condicion.Name = "Condicion";
            // 
            // Nota
            // 
            this.Nota.DataPropertyName = "Nota";
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            // 
            // CargarNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CargarNota";
            this.Text = "CargarNota";
            this.Load += new System.EventHandler(this.CargarNota_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAlumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvListaAlumnos;
        private System.Windows.Forms.Button btnCargarNota;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdInscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewComboBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
    }
}