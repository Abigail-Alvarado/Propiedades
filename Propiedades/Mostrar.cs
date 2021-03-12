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
        List<prop> propietarios = new List<prop>();
        string archivoC = "Registrodueños.txt";

        List<ppropiedades> propiedades = new List<ppropiedades>();
        string archivo2 = "propiedades.txt";

        List<Total> mostrargrid = new List<Total>();
        string archivo3 = "mostrar.txt";

        List<final> total = new List<final>();
        string archivo4 = "Final.txt";

        public Mostrar()
        {
            InitializeComponent();
        }
        void leer_datos()
        {
            FileStream stream2 = new FileStream(archivoC, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                prop temppropietarios = new prop();
                temppropietarios.Dpi = reader2.ReadLine();
                temppropietarios.Nombre = reader2.ReadLine();
                temppropietarios.Apellido = reader2.ReadLine();
                propietarios.Add(temppropietarios);



            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader2.Close();

            FileStream stream = new FileStream(archivo2, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                ppropiedades temppropiedades = new ppropiedades();
                temppropiedades.Numerocasa = reader.ReadLine();
                temppropiedades.Dpi = reader.ReadLine();
                temppropiedades.Cuotamantenimiento = float.Parse(reader.ReadLine());
                propiedades.Add(temppropiedades);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();

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


            FileStream stream4 = new FileStream(archivo4, FileMode.Open, FileAccess.Read);
            StreamReader reader4 = new StreamReader(stream4);
            while (reader4.Peek() > -1)
            {
                final temptotal = new final();
                temptotal.Nombre_apellido1 = reader4.ReadLine();
                temptotal.Dpi = reader4.ReadLine();
                temptotal.Cantidadpropiedades = Convert.ToInt32(reader4.ReadLine());
                temptotal.Cuotafinal = float.Parse(reader4.ReadLine());
                total.Add(temptotal);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader4.Close();


        }

        void mostrar()
        {
            dataGridView1.Text = null;
            dataGridView1.DataSource = mostrargrid;
            dataGridView1.Refresh();
        }
        void cargar()
        {
            foreach (var p in propiedades)
            {
                final propietario_medio = new final();
                prop temppropietario = propietarios.Find(l => l.Dpi == p.Dpi);
                propietario_medio.Dpi = p.Dpi;
                propietario_medio.Nombre_apellido1 = temppropietario.Nombre + " " + temppropietario.Apellido;

                total.Add(propietario_medio);
            }
        }
        void verificar_propiedades() // retorna 0 si no se encuentra en la lista
        {
            for (int x = 0; x < propiedades.Count; x++)
            {

                for (int y = 0; y < total.Count; y++)
                {
                    if (propiedades[x].Dpi.Equals(total[y].Dpi))
                    {
                        //Propietario_mayor temppropietario_mayor = new Propietario_mayor();
                        total[y].Cantidadpropiedades = total[y].Cantidadpropiedades + 1;
                    }
                    else
                    {
                        final al = total.Find(c => c.Dpi.Equals(propiedades[x].Dpi));
                        final propietario_Mayortemp = new final();
                        propietario_Mayortemp.Nombre_apellido1 = al.Nombre_apellido1;
                        propietario_Mayortemp.Dpi = al.Dpi;
                        propietario_Mayortemp.Cantidadpropiedades = al.Cantidadpropiedades;
                        propietario_Mayortemp.Cuotafinal = al.Cuotafinal;
                    }
                }
            }

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
        void ordenar(int e)
        {

            if (e == 1)
            {
                mostrargrid = mostrargrid.OrderBy(cuota => cuota.Cuotamantenimiento).ToList();

            }
            if (e == 2)
            {
                mostrargrid = mostrargrid.OrderByDescending(cuota => cuota.Cuotamantenimiento).ToList();

            }
            mostrar();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ordenar(1);//ascendente
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ordenar(2);//descendente
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cargar();
            verificar_propiedades();
            final temppropietario = total.OrderByDescending(al => al.Cantidadpropiedades).First();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = propietarios;
            dataGridView1.Refresh();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            string temp_cuota = "";
            propiedades = propiedades.OrderByDescending(cuota => cuota.Cuotamantenimiento).ToList();
            for (int i = 0; i < 3; i++)
                temp_cuota = temp_cuota + "Q." + propiedades[i].Cuotamantenimiento + "\n";


            label1.Text = (temp_cuota);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            string temp_cuota = "";
            propiedades = propiedades.OrderBy(cuota => cuota.Cuotamantenimiento).ToList();
            for (int x = 0; x < 3; x++)
                temp_cuota = temp_cuota + "Q." + propiedades[x].Cuotamantenimiento + "\n";


            label1.Text = temp_cuota;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            total = total.OrderByDescending(cuota => cuota.Cuotafinal).ToList();
            // Se muestra en una label los datos del indice 0 de esta
            label1.Text = total[0].Nombre_apellido1 + " " + "Q." + (total[0].Cuotafinal);

        }
    }
}
