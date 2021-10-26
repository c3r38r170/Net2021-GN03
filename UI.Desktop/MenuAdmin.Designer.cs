
namespace UI.Desktop
{
    partial class MenuAdmin
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
            this.txtExpecialidad = new System.Windows.Forms.Button();
            this.txtPlanes = new System.Windows.Forms.Button();
            this.txtComisiones = new System.Windows.Forms.Button();
            this.txtMaterias = new System.Windows.Forms.Button();
            this.txtCursos = new System.Windows.Forms.Button();
            this.Personas = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtExpecialidad, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPlanes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtComisiones, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtMaterias, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCursos, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Personas, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(136, 402);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtExpecialidad
            // 
            this.txtExpecialidad.Location = new System.Drawing.Point(3, 3);
            this.txtExpecialidad.Name = "txtExpecialidad";
            this.txtExpecialidad.Size = new System.Drawing.Size(128, 23);
            this.txtExpecialidad.TabIndex = 0;
            this.txtExpecialidad.Text = "Especialidades";
            this.txtExpecialidad.UseVisualStyleBackColor = true;
            this.txtExpecialidad.Click += new System.EventHandler(this.txtExpecialidad_Click);
            // 
            // txtPlanes
            // 
            this.txtPlanes.Location = new System.Drawing.Point(3, 32);
            this.txtPlanes.Name = "txtPlanes";
            this.txtPlanes.Size = new System.Drawing.Size(128, 23);
            this.txtPlanes.TabIndex = 1;
            this.txtPlanes.Text = "Planes";
            this.txtPlanes.UseVisualStyleBackColor = true;
            this.txtPlanes.Click += new System.EventHandler(this.txtPlanes_Click);
            // 
            // txtComisiones
            // 
            this.txtComisiones.Location = new System.Drawing.Point(3, 61);
            this.txtComisiones.Name = "txtComisiones";
            this.txtComisiones.Size = new System.Drawing.Size(128, 23);
            this.txtComisiones.TabIndex = 2;
            this.txtComisiones.Text = "Comisiones";
            this.txtComisiones.UseVisualStyleBackColor = true;
            this.txtComisiones.Click += new System.EventHandler(this.txtComisiones_Click);
            // 
            // txtMaterias
            // 
            this.txtMaterias.Location = new System.Drawing.Point(3, 90);
            this.txtMaterias.Name = "txtMaterias";
            this.txtMaterias.Size = new System.Drawing.Size(128, 23);
            this.txtMaterias.TabIndex = 3;
            this.txtMaterias.Text = "Materias";
            this.txtMaterias.UseVisualStyleBackColor = true;
            this.txtMaterias.Click += new System.EventHandler(this.txtMaterias_Click);
            // 
            // txtCursos
            // 
            this.txtCursos.Location = new System.Drawing.Point(3, 119);
            this.txtCursos.Name = "txtCursos";
            this.txtCursos.Size = new System.Drawing.Size(128, 23);
            this.txtCursos.TabIndex = 4;
            this.txtCursos.Text = "Cursos";
            this.txtCursos.UseVisualStyleBackColor = true;
            this.txtCursos.Click += new System.EventHandler(this.txtCursos_Click);
            // 
            // Personas
            // 
            this.Personas.Location = new System.Drawing.Point(3, 148);
            this.Personas.Name = "Personas";
            this.Personas.Size = new System.Drawing.Size(128, 23);
            this.Personas.TabIndex = 5;
            this.Personas.Text = "Personas";
            this.Personas.UseVisualStyleBackColor = true;
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 402);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MenuAdmin";
            this.Text = "MenuAdmin";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button txtExpecialidad;
        private System.Windows.Forms.Button txtPlanes;
        private System.Windows.Forms.Button txtComisiones;
        private System.Windows.Forms.Button txtMaterias;
        private System.Windows.Forms.Button txtCursos;
        private System.Windows.Forms.Button Personas;
    }
}