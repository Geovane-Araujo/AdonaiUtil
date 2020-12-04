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
            NpgsqlConnection conO = new NpgsqlConnection("Host=" + cmbLocalDestino.Text + ";Username=postgres;Password=1816;Database=adonai_9999");
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

                        NpgsqlConnection conD = new NpgsqlConnection("Host=" + cmbLocalDestino.Text + ";Username=postgres;Password=1816;Database=adonai_" + Convert.ToString(rs.GetInt32(rs.GetOrdinal("IDPessoa"))));
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
            NpgsqlConnection conO = new NpgsqlConnection("Host=" + cmbLocalDestino.Text + ";Username=postgres;Password=1816;Database=" + baseOriginal.Text);
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
                    NpgsqlConnection cona = new NpgsqlConnection("Host=" + txtLocalBanco.Text + ";Username=" + txtUser.Text + ";Password=" + txtPassword.Text + ";Database=" + txtDataBase.Text);
                    cona.Open();

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
                    sql = "SELECT column_name as coluna, data_type as tipo FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '" + txtTabela.Text + "' ORDER BY ORDINAL_POSITION";
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
                            String model = Util.Resource(coluna, tipo, txtPakage.Text, txtClasse.Text, txtendpoint.Text,cheToken.Checked);
                            Form3 txtmodel = new Form3(model);
                            txtmodel.Show();
                        }
                        if (cheController.Checked)
                        {
                            String sqla = "SELECT COUNT(kcu.column_name) as p "+
                                " FROM  information_schema.table_constraints AS tc "+
                                    "JOIN information_schema.key_column_usage AS kcu ON tc.constraint_name = kcu.constraint_name AND tc.table_schema = kcu.table_schema " +
                                    "JOIN information_schema.constraint_column_usage AS ccu ON ccu.constraint_name = tc.constraint_name AND ccu.table_schema = tc.table_schema" +
                                " WHERE tc.constraint_type = 'FOREIGN KEY' AND tc.table_name = '"+ txtTabela.Text+ "' " +
                                " group by kcu.column_name,ccu.table_name,ccu.column_name";

                            NpgsqlCommand commandE = new NpgsqlCommand(sqla, cona);
                            NpgsqlDataReader rsE = commandE.ExecuteReader();

                            count = 0;
                            if (rsE.HasRows)
                            {

                                while (rsE.Read())
                                {

                                    count++;
                                }
                            }
                            rsE.Close();
                            cona.Close();

                            cona.Open();

                            sqla = "SELECT kcu.column_name, ccu.table_name AS tabelaref, ccu.column_name AS columnref, tc.table_name," +
                                " ('INNER JOIN ' || ccu.table_name || ' ON ' || tc.table_name || '.' || kcu.column_name || ' = ' || ccu.table_name || '.' || ccu.column_name )as fk " +
                                " FROM  information_schema.table_constraints AS tc " +
                                    "JOIN information_schema.key_column_usage AS kcu ON tc.constraint_name = kcu.constraint_name AND tc.table_schema = kcu.table_schema " +
                                    "JOIN information_schema.constraint_column_usage AS ccu ON ccu.constraint_name = tc.constraint_name AND ccu.table_schema = tc.table_schema" +
                                " WHERE tc.constraint_type = 'FOREIGN KEY' AND tc.table_name = '" + txtTabela.Text + "' " +
                                " group by kcu.column_name,ccu.table_name,ccu.column_name, tc.table_name ";

                            commandE = new NpgsqlCommand(sqla, cona);
                            rsE = commandE.ExecuteReader();


                            String[] fk = new string[count];
                            String[] fktableref = new string[count];

                            if (rsE.HasRows)
                            {
                                i = 0;
                                while (rsE.Read())
                                {
                                    fk[i] = rsE.GetString(rsE.GetOrdinal("fk"));
                                    fktableref[i] = rsE.GetString(rsE.GetOrdinal("tabelaref"));
                                    i = i + 1;
                                }
                            }
                            rsE.Close();
                            String Tabelasref = "";
                            for(i = 0;  i < fktableref.Length; i++)
                            {
                                if(fktableref.Equals("pessoa"))
                                {
                                    Tabelasref = Tabelasref + fktableref[i] + ".nome, ";
                                }
                                else
                                {
                                    Tabelasref = Tabelasref + fktableref[i] + ".descricao, ";
                                }
                                
                            }

                            String model = Util.Controller(coluna, tipo, txtPakage.Text, txtClasse.Text, txtTabela.Text, fk, fktableref, cheToken.Checked, txtdbRequerTokenFalse.Text);
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
        // Cargos 
        private void metroButton4_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader rsO;
            System.Data.SqlClient.SqlConnection conO;
            System.Data.SqlClient.SqlCommand commandO;

            String connectO = "Persist Security Info=False; Data Source=" + Environment.MachineName + "\\SQLEXPRESS;Initial Catalog=padrao;User ID=sa; Password=Adonai@#1816";
            conO = new System.Data.SqlClient.SqlConnection(connectO);
            conO.Open();


            String sql = "select * from cargos ";
            commandO = new System.Data.SqlClient.SqlCommand(sql, conO);
            rsO = commandO.ExecuteReader();

            NpgsqlConnection conD = new NpgsqlConnection("Host=localhost;Username=postgres;Password=1816;Database=adonai_" + txtidbanco.Text);
            conD.Open();
            

            if (rsO.HasRows)
            {
                while (rsO.Read())
                {
                    String sqla = "INSERT INTO cargo(ID,Descricao) VALUES (@ID,@Descricao)";
                    NpgsqlCommand commandD = new NpgsqlCommand(sqla, conD);

                    commandD.Parameters.AddWithValue("@ID", rsO.GetInt32(rsO.GetOrdinal("ID")));
                    commandD.Parameters.AddWithValue("@Descricao", rsO.GetString(rsO.GetOrdinal("Descricao")));

                    commandD.ExecuteNonQuery();
                    commandD.Dispose();
                }
            }
            conD.Close();
            conD.Dispose();
            conO.Close();
            conO.Dispose();
            rsO.Close();
            commandO.Dispose();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader rsO;
            System.Data.SqlClient.SqlConnection conO;
            System.Data.SqlClient.SqlCommand commandO;

            String connectO = "Persist Security Info=False; Data Source=" + Environment.MachineName + "\\SQLEXPRESS;Initial Catalog=padrao;User ID=sa; Password=Adonai@#1816";
            conO = new System.Data.SqlClient.SqlConnection(connectO);
            conO.Open();

            String sql = "DELETE from Membros WHERE ID > 43";
            commandO = new System.Data.SqlClient.SqlCommand(sql, conO);
            commandO.ExecuteNonQuery();
            commandO.Dispose();


            sql = "select * from Membros";
            commandO = new System.Data.SqlClient.SqlCommand(sql, conO);
            rsO = commandO.ExecuteReader();

            NpgsqlConnection conD = new NpgsqlConnection("Host=localhost;Username=postgres;Password=1816;Database=adonai_" + txtidbanco.Text);
            conD.Open();


            if (rsO.HasRows)
            {
                while (rsO.Read())
                {
                    //Pessoa
                    String sqla = "INSERT INTO pessoa(nome,idtipo,IDmultiigreja) VALUES (@nome,@idtipo,@IDmultiigreja)";
                    var commandD = new NpgsqlCommand(sqla, conD);

                    commandD.Parameters.AddWithValue("@nome", rsO.GetString(rsO.GetOrdinal("nome")));
                    commandD.Parameters.AddWithValue("@idtipo", Convert.ToInt32(20));
                    commandD.Parameters.AddWithValue("@IDmultiigreja", Convert.ToInt32(1));

                    commandD.ExecuteNonQuery();
                    commandD.Dispose();


                    String sql1 = "SELECT ID FROM pessoa ORDER BY ID DESC LIMIT 1";
                    var commandD1 = new NpgsqlCommand(sql1, conD);
                    NpgsqlDataReader rs = commandD1.ExecuteReader();
                    int idpessoa = 0;

                    if (rs.HasRows)
                    {
                        while (rs.Read())
                        {
                            idpessoa = rs.GetInt32(rs.GetOrdinal("ID"));
                        }
                    }
                    commandD1.Dispose();
                    rs.Close();



                    sqla = "INSERT INTO pessoa_membro(idpessoa, datanascimento, idcargo, idestadocivil) VALUES (@idpessoa, @datanascimento, @idcargo,@idestadocivil)";
                    commandD = new NpgsqlCommand(sqla, conD);

                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    if (!rsO.IsDBNull(rsO.GetOrdinal("DataNascimento")))
                    {
                        commandD.Parameters.AddWithValue("@datanascimento", rsO.GetDateTime(rsO.GetOrdinal("DataNascimento")));
                    }
                    else
                    {
                        commandD.Parameters.AddWithValue("@datanascimento",DBNull.Value);
                    }
                   
                    commandD.Parameters.AddWithValue("@idcargo", rsO.GetInt32(rsO.GetOrdinal("IDCargo")));
                    commandD.Parameters.AddWithValue("@idestadocivil", Convert.ToInt32(2));

                    commandD.ExecuteNonQuery();
                    commandD.Dispose();


                    // ENDEREÇOS
                    sqla = "INSERT INTO pessoa_endereco(idpessoa, endereco, bairro, idcidade, numero, cep, complemento, tipo) VALUES (@idpessoa, @endereco, @bairro, @idcidade, @numero, @cep, @complemento, @tipo)";
                    commandD = new NpgsqlCommand(sqla, conD);

                    // email principal
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@endereco", rsO.GetString(rsO.GetOrdinal("Endereco")));
                    commandD.Parameters.AddWithValue("@bairro", rsO.GetString(rsO.GetOrdinal("Bairro")));
                    commandD.Parameters.AddWithValue("@idcidade", Convert.ToInt32(4102));
                    commandD.Parameters.AddWithValue("@numero", rsO.GetString(rsO.GetOrdinal("numero")));
                    commandD.Parameters.AddWithValue("@cep", rsO.GetString(rsO.GetOrdinal("cep")));
                    commandD.Parameters.AddWithValue("@complemento", rsO.GetString(rsO.GetOrdinal("complemento")));
                    commandD.Parameters.AddWithValue("@tipo", Convert.ToInt32(0));
                    commandD.ExecuteNonQuery();

                    commandD.Parameters.Clear();

                    // email secundario
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@endereco", "");
                    commandD.Parameters.AddWithValue("@bairro", "");
                    commandD.Parameters.AddWithValue("@idcidade", Convert.ToInt32(0));
                    commandD.Parameters.AddWithValue("@numero", "");
                    commandD.Parameters.AddWithValue("@cep", "");
                    commandD.Parameters.AddWithValue("@complemento", "");
                    commandD.Parameters.AddWithValue("@tipo", Convert.ToInt32(1));
                    commandD.ExecuteNonQuery();

                    commandD.Dispose();

                    // EMAIL
                    sqla = "INSERT INTO pessoa_email(idpessoa, email, tipo) VALUES (@idpessoa,@email, @tipo)";
                    commandD = new NpgsqlCommand(sqla, conD);

                    // 
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@tipo", Convert.ToInt32(0));
                    commandD.Parameters.AddWithValue("@email", rsO.GetString(rsO.GetOrdinal("email")));
                    commandD.ExecuteNonQuery();

                    commandD.Parameters.Clear();

                    // email secundario
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@tipo", Convert.ToInt32(1));
                    commandD.Parameters.AddWithValue("@email", rsO.GetString(rsO.GetOrdinal("email")));
                    commandD.ExecuteNonQuery();

                    commandD.Dispose();


                    // TELEFONES
                    sqla = "INSERT INTO pessoa_telefone(idpessoa, telefone, tipo) VALUES (@idpessoa, @telefone, @tipo)";
                    commandD = new NpgsqlCommand(sqla, conD);

                    // 
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@telefone", rsO.GetString(rsO.GetOrdinal("foneRes")));
                    commandD.Parameters.AddWithValue("@tipo", 0);
                    commandD.ExecuteNonQuery();

                    commandD.Parameters.Clear();

                    // email secundario
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@telefone", rsO.GetString(rsO.GetOrdinal("foneComer")));
                    commandD.Parameters.AddWithValue("@tipo", 1);
                    commandD.ExecuteNonQuery();

                    commandD.Parameters.Clear();

                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@telefone", rsO.GetString(rsO.GetOrdinal("foneCel")));
                    commandD.Parameters.AddWithValue("@tipo", 2);
                    commandD.ExecuteNonQuery();

                    commandD.Parameters.Clear();

                    commandD.Dispose();

                }
            }
            conD.Close();
            conD.Dispose();
            conO.Close();
            conO.Dispose();
            rsO.Close();
            commandO.Dispose();
        }

        private void metroLabel14_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=1816;Database=adonai_9999");
            con.Open();

            try
            {

                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO notaversao(data,versao,descricao) VALUES(@data,@versao,@descricao)", con);

                command.Parameters.AddWithValue("@data", Convert.ToDateTime(txtDataVersao.Text));
                command.Parameters.AddWithValue("@versao", txtVersao.Text);
                command.Parameters.AddWithValue("@Descricao", txtDescricao.Text);

                command.ExecuteReader();
                command.Dispose();
                MessageBox.Show("Salvo com sucesso");
            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            //MercadoPago.SDK.setAccessToken = "APP_USR-3416359311987982-100200-91298f74e55ce4e9b9f535947815657f-394686198";
        }

        private void txtDataVersao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlDataReader rsO;
            System.Data.SqlClient.SqlConnection conO;
            System.Data.SqlClient.SqlCommand commandO;

            String connectO = "Persist Security Info=False; Data Source=" + Environment.MachineName + "\\SQLEXPRESS;Initial Catalog=padrao;User ID=sa; Password=Adonai@#1816";
            conO = new System.Data.SqlClient.SqlConnection(connectO);
            conO.Open();



            String sql = "select * from NovosConvertidos";
            commandO = new System.Data.SqlClient.SqlCommand(sql, conO);
            rsO = commandO.ExecuteReader();

            NpgsqlConnection conD = new NpgsqlConnection("Host=localhost;Username=postgres;Password=1816;Database=adonai_" + txtidbanco.Text);
            conD.Open();


            if (rsO.HasRows)
            {
                while (rsO.Read())
                {
                    //Pessoa
                    String sqla = "INSERT INTO pessoa(nome,idtipo,IDmultiigreja) VALUES (@nome,@idtipo,@IDmultiigreja)";
                    var commandD = new NpgsqlCommand(sqla, conD);

                    commandD.Parameters.AddWithValue("@nome", rsO.GetString(rsO.GetOrdinal("nome")) + " Santos");
                    commandD.Parameters.AddWithValue("@idtipo", Convert.ToInt32(50));
                    commandD.Parameters.AddWithValue("@IDmultiigreja", Convert.ToInt32(1));

                    commandD.ExecuteNonQuery();
                    commandD.Dispose();


                    String sql1 = "SELECT ID FROM pessoa ORDER BY ID DESC LIMIT 1";
                    var commandD1 = new NpgsqlCommand(sql1, conD);
                    NpgsqlDataReader rs = commandD1.ExecuteReader();
                    int idpessoa = 0;

                    if (rs.HasRows)
                    {
                        while (rs.Read())
                        {
                            idpessoa = rs.GetInt32(rs.GetOrdinal("ID"));
                        }
                    }
                    commandD1.Dispose();
                    rs.Close();



                    sqla = "INSERT INTO pessoa_novoconvertido(idpessoa, datanascimento, idestadocivil, dataconversao) VALUES (@idpessoa, @datanascimento, @idestadocivil,@dataconversao)";
                    commandD = new NpgsqlCommand(sqla, conD);

                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    if (!rsO.IsDBNull(rsO.GetOrdinal("DataNascimento")))
                    {
                        commandD.Parameters.AddWithValue("@datanascimento", rsO.GetDateTime(rsO.GetOrdinal("DataNascimento")));
                    }
                    else
                    {
                        commandD.Parameters.AddWithValue("@datanascimento", DBNull.Value);
                    }

                    Random ra = new Random();
                    DateTime start = new DateTime(2019, 1, 1);
                    int range = (DateTime.Today - start).Days;
                    commandD.Parameters.AddWithValue("@dataconversao",start.AddDays(ra.Next(range)));
                    commandD.Parameters.AddWithValue("@idestadocivil", Convert.ToInt32(2));

                    commandD.ExecuteNonQuery();
                    commandD.Dispose();


                    // ENDEREÇOS
                    sqla = "INSERT INTO pessoa_endereco(idpessoa, endereco, bairro, idcidade, numero, cep, complemento, tipo) VALUES (@idpessoa, @endereco, @bairro, @idcidade, @numero, @cep, @complemento, @tipo)";
                    commandD = new NpgsqlCommand(sqla, conD);

                    // email principal
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@endereco", rsO.GetString(rsO.GetOrdinal("Endereco")));
                    commandD.Parameters.AddWithValue("@bairro", rsO.GetString(rsO.GetOrdinal("Bairro")));
                    commandD.Parameters.AddWithValue("@idcidade", Convert.ToInt32(4102));
                    String util = rsO.GetString(rsO.GetOrdinal("numero"));
                    if(util.Length > 10)
                    {
                        commandD.Parameters.AddWithValue("@numero", util.Substring(0, 9));
                    }
                    else
                    {
                        commandD.Parameters.AddWithValue("@numero", util);
                    }
                    
                    if (!rsO.IsDBNull(rsO.GetOrdinal("cep")))
                    {
                        util = rsO.GetString(rsO.GetOrdinal("cep"));
                        if (util.Length > 10)
                        {
                            commandD.Parameters.AddWithValue("@cep", util.Substring(0, 9));
                        }
                        else
                        {
                            commandD.Parameters.AddWithValue("@cep", rsO.GetString(rsO.GetOrdinal("cep")));
                        }
                        
                    }
                    else
                    {
                        commandD.Parameters.AddWithValue("@cep",DBNull.Value);
                    }

                    if (!rsO.IsDBNull(rsO.GetOrdinal("complemento")))
                    {
                        commandD.Parameters.AddWithValue("@complemento", rsO.GetString(rsO.GetOrdinal("complemento")));
                    }
                    else
                    {
                        commandD.Parameters.AddWithValue("@complemento", DBNull.Value);
                    }
                    
                    commandD.Parameters.AddWithValue("@tipo", Convert.ToInt32(0));
                    commandD.ExecuteNonQuery();

                    commandD.Parameters.Clear();

                    // email secundario
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@endereco", "");
                    commandD.Parameters.AddWithValue("@bairro", "");
                    commandD.Parameters.AddWithValue("@idcidade", Convert.ToInt32(0));
                    commandD.Parameters.AddWithValue("@numero", "");
                    commandD.Parameters.AddWithValue("@cep", "");
                    commandD.Parameters.AddWithValue("@complemento", "");
                    commandD.Parameters.AddWithValue("@tipo", Convert.ToInt32(1));
                    commandD.ExecuteNonQuery();

                    commandD.Dispose();

                    // EMAIL
                    sqla = "INSERT INTO pessoa_email(idpessoa, email, tipo) VALUES (@idpessoa,@email, @tipo)";
                    commandD = new NpgsqlCommand(sqla, conD);

                    // 
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@tipo", Convert.ToInt32(0));
                    commandD.Parameters.AddWithValue("@email", rsO.GetString(rsO.GetOrdinal("email")));
                    commandD.ExecuteNonQuery();

                    commandD.Parameters.Clear();

                    // email secundario
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@tipo", Convert.ToInt32(1));
                    commandD.Parameters.AddWithValue("@email", rsO.GetString(rsO.GetOrdinal("email")));
                    commandD.ExecuteNonQuery();

                    commandD.Dispose();


                    // TELEFONES
                    sqla = "INSERT INTO pessoa_telefone(idpessoa, telefone, tipo) VALUES (@idpessoa, @telefone, @tipo)";
                    commandD = new NpgsqlCommand(sqla, conD);

                    // 
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@telefone", rsO.GetString(rsO.GetOrdinal("foneRes")));
                    commandD.Parameters.AddWithValue("@tipo", 0);
                    commandD.ExecuteNonQuery();

                    commandD.Parameters.Clear();

                    // email secundario
                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@telefone", rsO.GetString(rsO.GetOrdinal("foneComer")));
                    commandD.Parameters.AddWithValue("@tipo", 1);
                    commandD.ExecuteNonQuery();

                    commandD.Parameters.Clear();

                    commandD.Parameters.AddWithValue("@idpessoa", Convert.ToInt32(idpessoa));
                    commandD.Parameters.AddWithValue("@telefone", rsO.GetString(rsO.GetOrdinal("foneCel")));
                    commandD.Parameters.AddWithValue("@tipo", 2);
                    commandD.ExecuteNonQuery();

                    commandD.Parameters.Clear();

                    commandD.Dispose();

                }
            }
            conD.Close();
            conD.Dispose();
            conO.Close();
            conO.Dispose();
            rsO.Close();
            commandO.Dispose();
        }

        private void txtPakage_Click(object sender, EventArgs e)
        {

        }
    }
}
