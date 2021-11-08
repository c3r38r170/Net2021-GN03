
namespace UI.Desktop
{
    partial class PersonaDesktop
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtLegajo = new System.Windows.Forms.TextBox();
			this.txtApellido = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtFecha = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDireccion = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtTelefono = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cBoxIDPlan = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.cBoxTipoPersona = new System.Windows.Forms.ComboBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtLegajo, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtApellido, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label11, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtFecha, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtDireccion, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.label5, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.txtTelefono, 3, 4);
			this.tableLayoutPanel1.Controls.Add(this.label12, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.cBoxIDPlan, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.label13, 2, 6);
			this.tableLayoutPanel1.Controls.Add(this.cBoxTipoPersona, 3, 6);
			this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 8);
			this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 8);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 9;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(633, 206);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(18, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "ID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Nombre";
			// 
			// txtID
			// 
			this.txtID.Enabled = false;
			this.txtID.Location = new System.Drawing.Point(112, 3);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(211, 23);
			this.txtID.TabIndex = 4;
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(112, 32);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(211, 23);
			this.txtNombre.TabIndex = 5;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(3, 87);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(36, 15);
			this.label9.TabIndex = 12;
			this.label9.Text = "Email";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(112, 90);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(211, 23);
			this.txtEmail.TabIndex = 18;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(329, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 15);
			this.label6.TabIndex = 9;
			this.label6.Text = "Legajo";
			// 
			// txtLegajo
			// 
			this.txtLegajo.Location = new System.Drawing.Point(410, 3);
			this.txtLegajo.Name = "txtLegajo";
			this.txtLegajo.Size = new System.Drawing.Size(138, 23);
			this.txtLegajo.TabIndex = 15;
			// 
			// txtApellido
			// 
			this.txtApellido.Location = new System.Drawing.Point(410, 32);
			this.txtApellido.Name = "txtApellido";
			this.txtApellido.Size = new System.Drawing.Size(211, 23);
			this.txtApellido.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(329, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Apellido";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(3, 58);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(103, 15);
			this.label11.TabIndex = 26;
			this.label11.Text = "Fecha Nacimiento";
			// 
			// txtFecha
			// 
			this.txtFecha.Location = new System.Drawing.Point(112, 61);
			this.txtFecha.Name = "txtFecha";
			this.txtFecha.Size = new System.Drawing.Size(211, 23);
			this.txtFecha.TabIndex = 25;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(329, 58);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 15);
			this.label4.TabIndex = 3;
			this.label4.Text = "Direccion";
			// 
			// txtDireccion
			// 
			this.txtDireccion.Location = new System.Drawing.Point(410, 61);
			this.txtDireccion.Name = "txtDireccion";
			this.txtDireccion.Size = new System.Drawing.Size(211, 23);
			this.txtDireccion.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(329, 87);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 15);
			this.label5.TabIndex = 8;
			this.label5.Text = "Telefono";
			// 
			// txtTelefono
			// 
			this.txtTelefono.Location = new System.Drawing.Point(410, 90);
			this.txtTelefono.Name = "txtTelefono";
			this.txtTelefono.Size = new System.Drawing.Size(138, 23);
			this.txtTelefono.TabIndex = 14;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(3, 116);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(30, 15);
			this.label12.TabIndex = 27;
			this.label12.Text = "Plan";
			// 
			// cBoxIDPlan
			// 
			this.cBoxIDPlan.FormattingEnabled = true;
			this.cBoxIDPlan.Location = new System.Drawing.Point(112, 119);
			this.cBoxIDPlan.Name = "cBoxIDPlan";
			this.cBoxIDPlan.Size = new System.Drawing.Size(211, 23);
			this.cBoxIDPlan.TabIndex = 24;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(329, 116);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(31, 15);
			this.label13.TabIndex = 28;
			this.label13.Text = "Tipo";
			// 
			// cBoxTipoPersona
			// 
			this.cBoxTipoPersona.FormattingEnabled = true;
			this.cBoxTipoPersona.Location = new System.Drawing.Point(410, 119);
			this.cBoxTipoPersona.Name = "cBoxTipoPersona";
			this.cBoxTipoPersona.Size = new System.Drawing.Size(211, 23);
			this.cBoxTipoPersona.TabIndex = 23;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAceptar.Location = new System.Drawing.Point(329, 180);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 23);
			this.btnAceptar.TabIndex = 20;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelar.Location = new System.Drawing.Point(555, 180);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 21;
			this.btnCancelar.Text = "Salir";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// PersonaDesktop
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(633, 206);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "PersonaDesktop";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PersonaDesktop";
			this.Load += new System.EventHandler(this.PersonaDesktop_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.ComboBox cBoxTipoPersona;
        private System.Windows.Forms.ComboBox cBoxIDPlan;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}