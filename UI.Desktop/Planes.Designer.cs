
namespace UI.Desktop
{
    partial class Planes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Planes));
            this.tcPlanesMaterias = new System.Windows.Forms.ToolStripContainer();
            this.tlPlanesMaterias = new System.Windows.Forms.TableLayoutPanel();
            this.dvgPlanes = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idespecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcPlanesMaterias.ContentPanel.SuspendLayout();
            this.tcPlanesMaterias.TopToolStripPanel.SuspendLayout();
            this.tcPlanesMaterias.SuspendLayout();
            this.tlPlanesMaterias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPlanes)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPlanesMaterias
            // 
            // 
            // tcPlanesMaterias.ContentPanel
            // 
            this.tcPlanesMaterias.ContentPanel.Controls.Add(this.tlPlanesMaterias);
            this.tcPlanesMaterias.ContentPanel.Size = new System.Drawing.Size(800, 425);
            this.tcPlanesMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPlanesMaterias.Location = new System.Drawing.Point(0, 0);
            this.tcPlanesMaterias.Name = "tcPlanesMaterias";
            this.tcPlanesMaterias.Size = new System.Drawing.Size(800, 450);
            this.tcPlanesMaterias.TabIndex = 0;
            this.tcPlanesMaterias.Text = "toolStripContainer1";
            // 
            // tcPlanesMaterias.TopToolStripPanel
            // 
            this.tcPlanesMaterias.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tlPlanesMaterias
            // 
            this.tlPlanesMaterias.ColumnCount = 2;
            this.tlPlanesMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPlanesMaterias.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPlanesMaterias.Controls.Add(this.dvgPlanes, 0, 0);
            this.tlPlanesMaterias.Controls.Add(this.btnActualizar, 0, 1);
            this.tlPlanesMaterias.Controls.Add(this.btnSalir, 1, 1);
            this.tlPlanesMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPlanesMaterias.Location = new System.Drawing.Point(0, 0);
            this.tlPlanesMaterias.Name = "tlPlanesMaterias";
            this.tlPlanesMaterias.RowCount = 2;
            this.tlPlanesMaterias.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPlanesMaterias.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPlanesMaterias.Size = new System.Drawing.Size(800, 425);
            this.tlPlanesMaterias.TabIndex = 0;
            // 
            // dvgPlanes
            // 
            this.dvgPlanes.AllowUserToAddRows = false;
            this.dvgPlanes.AllowUserToDeleteRows = false;
            this.dvgPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPlanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this._Descripcion,
            this.idespecialidad});
            this.tlPlanesMaterias.SetColumnSpan(this.dvgPlanes, 2);
            this.dvgPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgPlanes.Location = new System.Drawing.Point(3, 3);
            this.dvgPlanes.Name = "dvgPlanes";
            this.dvgPlanes.ReadOnly = true;
            this.dvgPlanes.RowTemplate.Height = 25;
            this.dvgPlanes.Size = new System.Drawing.Size(794, 390);
            this.dvgPlanes.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(641, 399);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(722, 399);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(4, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(23, 22);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(23, 22);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(23, 22);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID Plan";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // _Descripcion
            // 
            this._Descripcion.DataPropertyName = "Descripcion";
            this._Descripcion.HeaderText = "Descripcion Plan";
            this._Descripcion.Name = "_Descripcion";
            this._Descripcion.ReadOnly = true;
            // 
            // idespecialidad
            // 
            this.idespecialidad.DataPropertyName = "IDEspecialidad";
            this.idespecialidad.HeaderText = "Descripcion Especialidad";
            this.idespecialidad.Name = "idespecialidad";
            this.idespecialidad.ReadOnly = true;
            // 
            // Planes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tcPlanesMaterias);
            this.Name = "Planes";
            this.Text = "PlanesMaterias";
            this.Load += new System.EventHandler(this.Planes_Load);
            this.tcPlanesMaterias.ContentPanel.ResumeLayout(false);
            this.tcPlanesMaterias.TopToolStripPanel.ResumeLayout(false);
            this.tcPlanesMaterias.TopToolStripPanel.PerformLayout();
            this.tcPlanesMaterias.ResumeLayout(false);
            this.tcPlanesMaterias.PerformLayout();
            this.tlPlanesMaterias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgPlanes)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcPlanesMaterias;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.TableLayoutPanel tlPlanesMaterias;
        private System.Windows.Forms.DataGridView dvgPlanes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idespecialidad;
    }
}