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
        List<prop> dueño = new List<prop>();
        string archivoC = "Registrodueños.txt";
        public Mostrar()
        {
            InitializeComponent();
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
    }
}
