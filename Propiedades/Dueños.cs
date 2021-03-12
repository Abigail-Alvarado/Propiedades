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
    public partial class Dueños : Form
    {
        List<prop> dueño = new List<prop>();
        string archivoC = "Registrodueños.txt";

        public Dueños()
        {
            InitializeComponent();
        }
        public void guardar()
        {
            FileStream stream = new FileStream(archivoC, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < dueño.Count; i++)
            {
                writer.WriteLine(dueño[i].Dpi);
                writer.WriteLine(dueño[i].Nombre);
                writer.WriteLine(dueño[i].Apellido);
            }
            writer.Close();
        }
        void leer_datos()
        {
            FileStream stream = new FileStream(archivoC, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                prop tempcliente = new prop();
                tempcliente.Dpi = reader.ReadLine();
                tempcliente.Nombre = reader.ReadLine();
                tempcliente.Apellido = reader.ReadLine();
                dueño.Add(tempcliente);

            }
            reader.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Menu vmenu = new Menu();
            vmenu.Show();
            this.SetVisibleCore(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //declaramos un objeto cliente de la clase clientes
                prop tempcliente = new prop();
                tempcliente.Dpi = textBox1.Text;
                tempcliente.Nombre = textBox2.Text;
                tempcliente.Apellido = textBox3.Text;
                //para asignarle los datos leidos del archivo
                dueño.Add(tempcliente);
                //luego guardar el tempcliente en la lista de clienters
                guardar();

                limpiar();
                MessageBox.Show("Cliente agregado correctamente");
            }
            catch (Exception)
            {
                // Condición para emitir si falta en llenar un campo
                MessageBox.Show("No se han llenado todos los datos", "Mi Mesaje Predeterminado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            void limpiar()
            {
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
            }
        }

        private void Dueños_Load(object sender, EventArgs e)
        {
            leer_datos();
        }
    }
}
