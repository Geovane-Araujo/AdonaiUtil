using AdonaiSoft_Utilitario.Utilitario;
using Npgsql;
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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conO = new NpgsqlConnection("Host=" + LocalDestino.Text + ";Username=postgres;Password=1816;Database=adonai_9999");
            conO.Open();

            String sql = "select IDPessoa from Pessoa_igreja";
            NpgsqlCommand commandO = new NpgsqlCommand(sql, conO);
            NpgsqlDataReader rs = commandO.ExecuteReader();
            try
            {
                if (rs.HasRows)
                {
                    while (rs.Read())
                    {

                        NpgsqlConnection conD = new NpgsqlConnection("Host=" + LocalDestino.Text + ";Username=postgres;Password=1816;Database=adonai_" + Convert.ToString(rs.GetInt32(rs.GetOrdinal("IDPessoa"))));
                        conD.Open();

                        NpgsqlCommand commandD = new NpgsqlCommand(comandosql.Text, conD);

                        commandD.ExecuteNonQuery();

                        conD.Close();
                        conD.Dispose();
                        commandD.Dispose();

                    }
                }

                MessageBox.Show("Concluido com sucesso", "concluido", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "falha", MessageBoxButtons.OK);
            }
            finally
            {
                conO.Close();
                rs.Close();
                conO.Dispose();
                commandO.Dispose();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conO = new NpgsqlConnection("Host=" + LocalDestino.Text + ";Username=postgres;Password=1816;Database=" + baseOriginal.Text);
            conO.Open();

            try
            {
                NpgsqlCommand commandO = new NpgsqlCommand(comandosql.Text, conO);
                commandO.ExecuteReader();

                commandO.Dispose();
                MessageBox.Show("Comando executado com sucesso", "Concluido", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "falha", MessageBoxButtons.OK);
            }
            finally
            {
                conO.Close();

            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if(cmbBanco.Text == "PostgreSql")
            {
                try
                {
                    NpgsqlConnection con = new NpgsqlConnection("Host="+ txtLocalBanco.Text+";Username="+txtUser.Text+";Password="+txtPassword.Text+";Database="+txtDataBase.Text);
                    con.Open();

                    String sql = "SELECT COUNT(column_name) as p FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '" + txtTabela.Text + "'";
                    NpgsqlCommand command = new NpgsqlCommand(sql, con);

                    NpgsqlDataReader rs = command.ExecuteReader();

                    int count = 0;

                    if (rs.HasRows)
                    {
                       
                        while (rs.Read())
                        {

                            count = rs.GetInt32(rs.GetOrdinal("p"));
                        }
                    }
                    rs.Close();


                    String[] coluna = new string[count];
                    String[] tipo = new string[count];
                    sql = "SELECT column_name as coluna, data_type as tipo FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '" + txtTabela.Text + "'";
                    NpgsqlCommand commandD = new NpgsqlCommand(sql,con);


                    rs = commandD.ExecuteReader();

                    if (rs.HasRows)
                    {
                        int i = 0;
                        while (rs.Read())
                        {

                            coluna[i] = rs.GetString(rs.GetOrdinal("coluna"));
                            tipo[i] = rs.GetString(rs.GetOrdinal("tipo"));
                            i = i + 1;
                            
                        }
                        if(cheModel.Checked)
                        {
                            String model = Util.Model(coluna, tipo, txtPakage.Text, txtClasse.Text);
                            Form2 txtmodel = new Form2(model);
                            txtmodel.Show();
                        }
                        if (cheResource.Checked)
                        {
                            String model = Util.Resource(coluna, tipo, txtPakage.Text, txtClasse.Text);
                            Form3 txtmodel = new Form3(model);
                            txtmodel.Show();
                        }
                        if (cheController.Checked)
                        {
                            String model = Util.Controller(coluna, tipo, txtPakage.Text, txtClasse.Text, txtTabela.Text);
                            Form4 txtmodel = new Form4(model);
                            txtmodel.Show();
                        }

                    }

            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Falha", MessageBoxButtons.OK);
                }
            }
            else if(cmbBanco.Text == "SQL Server")
            {
                MessageBox.Show("Ainda não configurado", "Atenção", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ainda não configurado", "Atenção", MessageBoxButtons.OK);
            }
            
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
