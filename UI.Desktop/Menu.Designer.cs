﻿
namespace UI.Desktop
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
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnAlumnos = new System.Windows.Forms.Button();
            this.btnEspecialidad = new System.Windows.Forms.Button();
            this.btnPlanes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(57, 37);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(128, 23);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.Location = new System.Drawing.Point(57, 80);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Size = new System.Drawing.Size(128, 23);
            this.btnAlumnos.TabIndex = 1;
            this.btnAlumnos.Text = "Personas";
            this.btnAlumnos.UseVisualStyleBackColor = true;
            this.btnAlumnos.Click += new System.EventHandler(this.btnAlumnos_Click);
            // 
            // btnEspecialidad
            // 
            this.btnEspecialidad.Location = new System.Drawing.Point(202, 37);
            this.btnEspecialidad.Name = "btnEspecialidad";
            this.btnEspecialidad.Size = new System.Drawing.Size(128, 23);
            this.btnEspecialidad.TabIndex = 2;
            this.btnEspecialidad.Text = "Especialidades";
            this.btnEspecialidad.UseVisualStyleBackColor = true;
            this.btnEspecialidad.Click += new System.EventHandler(this.btnEspecialidad_Click);
            // 
            // btnPlanes
            // 
            this.btnPlanes.Location = new System.Drawing.Point(202, 79);
            this.btnPlanes.Name = "btnPlanes";
            this.btnPlanes.Size = new System.Drawing.Size(128, 23);
            this.btnPlanes.TabIndex = 3;
            this.btnPlanes.Text = "Planes";
            this.btnPlanes.UseVisualStyleBackColor = true;
            this.btnPlanes.Click += new System.EventHandler(this.btnPlanesMaterias_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 143);
            this.Controls.Add(this.btnPlanes);
            this.Controls.Add(this.btnEspecialidad);
            this.Controls.Add(this.btnAlumnos);
            this.Controls.Add(this.btnUsuarios);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAlumnos;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnEspecialidad;
        private System.Windows.Forms.Button btnPlanes;
    }
}