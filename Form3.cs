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
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(String codigo)
        {
            InitializeComponent();
            txtCodigo.Text = codigo;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
