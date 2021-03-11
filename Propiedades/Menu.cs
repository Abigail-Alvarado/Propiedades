using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Propiedades
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dueños vclientes = new Dueños();
            vclientes.Show();
            this.SetVisibleCore(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            propiedades vclientes = new propiedades();
            vclientes.Show();
            this.SetVisibleCore(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            datos vclientes = new datos();
            vclientes.Show();
            this.SetVisibleCore(false);

        }
    }
}
