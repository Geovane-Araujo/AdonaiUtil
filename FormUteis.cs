using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdonaiSoft_Utilitario
{
    public partial class FormUteis : AdonaiSoft_Utilitario.Form4
    {
        public FormUteis()
        {
            InitializeComponent();
        }
        public FormUteis(String codigo)
        {
            InitializeComponent();
            txtCodigo.Text = codigo;
        }
        private void FormUteis_Load(object sender, EventArgs e)
        {

        }
    }
}
