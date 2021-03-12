using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Propiedades
{
    public partial class Mostrar : Form
    {
        List<Total> mostrargrid = new List<Total>();
        string archivo3 = "mostrar.txt";
        public Mostrar()
        {
            InitializeComponent();
        }
        void leer_datos()
        {
            FileStream stream3 = new FileStream(archivo3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                Total tempmostrar = new Total();
                tempmostrar.Nombre_apellido = reader3.ReadLine();
                tempmostrar.Numerocasa = reader3.ReadLine();
                tempmostrar.Cuotamantenimiento = float.Parse(reader3.ReadLine());

                mostrargrid.Add(tempmostrar);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader3.Close();
        }
        void mostrar()
        {
            dataGridView1.Text = null;
            dataGridView1.DataSource = mostrargrid;
            dataGridView1.Refresh();
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Menu vmenu = new Menu();
            vmenu.Show();
            this.SetVisibleCore(false);
        }

        private void Mostrar_Load(object sender, EventArgs e)
        {
            leer_datos();
            mostrar();
        }
    }
}
