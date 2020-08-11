using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdonaiSoft_Utilitario
{
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(String value)
        {
            InitializeComponent();
            txtCodigo.Text = value;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
