﻿using System;
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
     
            mostrar();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
