using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdonaiSoft_Utilitario.Utilitario
{
    class table
    {
        String coluna = "";
        String tipo = "";


        public string mavarcoluna
        {
            get { return coluna; }
            set { coluna = value; }
        }

        public string mvartipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
