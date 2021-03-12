using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.IO;

namespace Propiedades
{
    public partial class datos : Form
    {

        List<prop> propietarios = new List<prop>();
        string archivoC = "Registrodueños.txt";

        List<ppropiedades> propiedades = new List<ppropiedades>();
        string archivo2 = "propiedades.txt";

        List<Total> mostrargrid = new List<Total>();
        string archivo3 = "mostrar.txt";
        public datos()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            comboBox1.Enabled = false;
            button3.Visible = true;
        }
        void guardar()
        {
            FileStream stream = new FileStream(archivoC, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < propietarios.Count; i++)
            {
                writer.WriteLine(propietarios[i].Dpi);
                writer.WriteLine(propietarios[i].Nombre);
                writer.WriteLine(propietarios[i].Apellido);
            }
            writer.Close();
        }
        void leer_datos()
        {
            FileStream stream = new FileStream(archivoC, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                prop temppropietarios = new prop();
                temppropietarios.Dpi = reader.ReadLine();
                temppropietarios.Nombre = reader.ReadLine();
                temppropietarios.Apellido = reader.ReadLine();
                propietarios.Add(temppropietarios);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        void limpiar()
        {
            textBox1.Text = null;
            comboBox1.Text = null;
            textBox3.Text = null;
        }
        void mostrar()
        {
            comboBox1.Text = null;
            comboBox1.DisplayMember = "Dpi";
            comboBox1.ValueMember = "Dpi";
            comboBox1.DataSource = propietarios;
            comboBox1.Refresh();
        }
        void desbloquear()
        {
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            comboBox1.Enabled = true;
            button3.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Total tempmostrar = new Total();
            ppropiedades temppriedades = new ppropiedades();
            temppriedades.Numerocasa = textBox1.Text;
            tempmostrar.Numerocasa = textBox1.Text;
            temppriedades.Dpi = comboBox1.Text;
            string tempnombre = "";
            string tempapellido = "";

            comboBox1.ValueMember = "Nombre";
            comboBox1.DataSource = propietarios;
            tempnombre = comboBox1.SelectedValue.ToString();
            comboBox1.ValueMember = "Apellido";
            comboBox1.DataSource = propietarios;
            tempapellido = comboBox1.SelectedValue.ToString();

            tempmostrar.Nombre_apellido = tempnombre + " " + tempapellido;

            temppriedades.Cuotamantenimiento = float.Parse(textBox3.Text);
            tempmostrar.Cuotamantenimiento = float.Parse(textBox3.Text);
            propiedades.Add(temppriedades);
            mostrargrid.Add(tempmostrar);
            guardar();
            limpiar();
            MessageBox.Show("Propiedad agregado correctamente");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu regresar = new Menu();
            regresar.Show();
            this.SetVisibleCore(false);
        }

        private void datos_Load(object sender, EventArgs e)
        {
            leer_datos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mostrar();
            desbloquear();
        }
    }
}
