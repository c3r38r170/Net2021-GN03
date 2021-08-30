﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Program.menu.Hide();
            Usuarios uForm = new Usuarios();
            uForm.ShowDialog();    
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            Program.menu.Hide();
            Personas a = new Personas();
            a.ShowDialog();
        }
    }
}
