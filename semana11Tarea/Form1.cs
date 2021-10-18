using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace semana11Tarea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bnuevo_Click(object sender, EventArgs e)
        {
            txtusuario.Enabled = true; txtclave.Enabled = true; lstnivel.Enabled = true; txtusuario.Text = ""; txtclave.Text = ""; lstnivel.Text = "Seleccione nivel"; txtusuario.Focus(); bnuevo.Visible = false; bguardar.Visible = true;
        }

        private void bguardar_Click(object sender, EventArgs e)
        {

        }
    }
    
}
