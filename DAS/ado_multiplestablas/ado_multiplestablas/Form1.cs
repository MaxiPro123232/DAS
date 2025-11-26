using System;
using System.Windows.Forms;
using ado_multiplestablas;
namespace ado_multiplestablas;
using Microsoft.Data.SqlClient;
public partial class Form1 : Form
{
    private RepositorioPasajes repo;
    public Form1()
    {
        InitializeComponent();
        repo = new RepositorioPasajes();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        MessageBox.Show("Form1_Load OK");
        dgvDatos.AutoGenerateColumns = true;
        dgvDatos.Columns.Clear();

        CargarAviones();
    }
    private void CargarAviones()
    {
        var lista = repo.ListarAviones(); // debe devolver List<Avion> con propiedades públicas
        var bs = new BindingSource { DataSource = lista };

        dgvDatos.AutoGenerateColumns = true;
        dgvDatos.Columns.Clear();
        dgvDatos.DataSource = bs;
        dgvDatos.Refresh();

    }

    private void btnListarAviones_Click_1(object sender, EventArgs e)
    {
        CargarAviones();
    }

    private void btnAgregarAvion_Click_1(object sender, EventArgs e)
    {
        try
        {
            var nuevo = new Avion
            {
                Matricula = txtMatricula.Text.Trim(),
                Modelo = txtModelo.Text.Trim(),
                Capacidad = int.Parse(txtCapacidad.Text.Trim())
            };

            string msg = repo.AgregarAvion(nuevo);
            MessageBox.Show(msg);

            // Refrescar grilla
            CargarAviones();

            // Limpiar
            txtMatricula.Clear();
            txtModelo.Clear();
            txtCapacidad.Clear();
            txtMatricula.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se pudo agregar: " + ex.Message);
        }
    }


    private void Form1_Load_1(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }
    private void btnProbarConexion_Click_1(object sender, EventArgs e)
    {
        string cadena = "Data Source=MAXOPC\\SQLEXPRESS;Initial Catalog=PasajesAviones;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

        try
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                MessageBox.Show("Conexión establecida con la base: " + conn.Database);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(" Error al conectar: " + ex.Message);
        }
    }

    private void btnListarAviones_Click(object sender, EventArgs e)
    {
        CargarAviones();
    }

    private void btnListarPasajeros_Click(object sender, EventArgs e)
    {
        dgvDatos.DataSource = null;
        dgvDatos.DataSource = repo.ListarPasajeros();
    }
    private void btnListarPasajes_Click_1(object sender, EventArgs e)
    {
        dgvDatos.DataSource = null;
        dgvDatos.DataSource = repo.ListarPasajes();
    }
}
