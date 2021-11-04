
namespace UI.Desktop
{
    partial class MenuAlumno
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
            this.btnInscribirseA = new System.Windows.Forms.Button();
            this.btnInscriptoEn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnInscribirseA, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInscriptoEn, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.88889F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 391F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(138, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnInscribirseA
            // 
            this.btnInscribirseA.Location = new System.Drawing.Point(3, 3);
            this.btnInscribirseA.Name = "btnInscribirseA";
            this.btnInscribirseA.Size = new System.Drawing.Size(128, 22);
            this.btnInscribirseA.TabIndex = 0;
            this.btnInscribirseA.Text = "Inscribirse A";
            this.btnInscribirseA.UseVisualStyleBackColor = true;
            this.btnInscribirseA.Click += new System.EventHandler(this.btnInscribirseA_Click);
            // 
            // btnInscriptoEn
            // 
            this.btnInscriptoEn.Location = new System.Drawing.Point(3, 31);
            this.btnInscriptoEn.Name = "btnInscriptoEn";
            this.btnInscriptoEn.Size = new System.Drawing.Size(128, 23);
            this.btnInscriptoEn.TabIndex = 1;
            this.btnInscriptoEn.Text = "Inscripto En";
            this.btnInscriptoEn.UseVisualStyleBackColor = true;
            this.btnInscriptoEn.Click += new System.EventHandler(this.btnInscriptoEn_Click);
            // 
            // MenuAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MenuAlumno";
            this.Text = "Inscripto En";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnInscribirseA;
        private System.Windows.Forms.Button btnInscriptoEn;
    }
}