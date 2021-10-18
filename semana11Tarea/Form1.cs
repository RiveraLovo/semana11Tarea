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
            try
            {
                MySqlConnectionmyConnection = newMySqlConnection(cadena_conexion);
                stringmyInsertQuery = "INSERT INTO contactos(nombre,clave,nivel) Values(?nombre,?clave,?nivel)";
                MySqlCommandmyCommand = newMySqlCommand(myInsertQuery);

                myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 40).Value = txtusuario.Text;
                myCommand.Parameters.Add("?clave", MySqlDbType.VarChar, 45).Value = txtclave.Text;
                myCommand.Parameters.Add("?nivel", MySqlDbType.Int32, 4).Value = lstnivel.Text;
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();


                MessageBox.Show("Usuario agregado con éxito", "Ok", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                stringconsulta = "select * from contactos";

                MySqlConnectionconexion = newMySqlConnection(cadena_conexion);
                MySqlDataAdapterda = newMySqlDataAdapter(consulta, conexion);
                System.Data.DataSetds = newSystem.Data.DataSet();
                da.Fill(ds, "agenda");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "agenda";

            }
            catch (MySqlException)
            {
                MessageBox.Show("Ya existe el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bnuevo.Visible = true;
            bguardar.Visible = false;

            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            bnuevo.Focus();
            }
        }
    }
}