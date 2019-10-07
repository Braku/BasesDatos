using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;

namespace Database
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection con;
        DataTable dt;
        public MainWindow()
        {
            InitializeComponent();
            con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\Alumnos.mdb";
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from 5B";
            OleDbDataAdapter da = new OleDbDataAdapter();
            dt = new DataTable();
            da.Fill(dt);
            gvDatos.ItemsSource = dt.AsDataView();
            if (dt.Rows.Count > 0)
            {
                lbcontent.Visibility = System.Windows.Visibility.Hidden;
                gvDatos.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                lbcontent.Visibility = System.Windows.Visibility.Visible;
                gvDatos.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void LimpiarTodo()
        {
            txtid.Text = "";
            txtname.Text = "";
            cbGen.SelectedIndex = 0;
            txttel.Text = "";
            txtdir.Text = "";
        }

        private void bnew_click(object sender, RoutedEventArgs e)
        {

        }

        private void bedit_click(object sender, RoutedEventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            if(txtid.Text != "")
            {
                if(cbGen.Text != "Selecciona Genero")
                {
                    cmd.CommandText = "Insert into 5B(Id, Nombre, Genero, Telefono, Direccion)" + 
                        "Values("+txtid.Text+", '"+txtname.Text+", '"+cbGen.Text+", "+txttel.Text+", '"+txtdir.Text+"')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Alumno agregadon con exito...");
                    LimpiarTodo();
                }
                else
                {
                    MessageBox.Show("Favor de seleccionar el genero...");
                }
            }
            else
            {
                cmd.CommandText = "update 5B set Nombre ='" +
                    txtname.Text + "',Genero='" + cbGen.Text + "',Telefono=" + txttel.Text + ",Direccion='" + txtdir.Text + "where Id=" + txtid.Text;
                cmd.ExecuteNonQuery();
                MostrarDatos();
                MessageBox.Show("Datod frl alu,no  actualizados");
                LimpiarTodo();
            }
        }

        private void bdel_click(object sender, RoutedEventArgs e)
        {

        }

        private void bcancel_click(object sender, RoutedEventArgs e)
        {

        }

        private void bsal_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
