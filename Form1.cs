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
        public static String dbName = "";
        public static String tableName = "";
        public static String endpointName = "";
        public static Boolean util;
        public static Boolean rest;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conO = new NpgsqlConnection("Host=" + txtLocalBanco.Text + ";Username=postgres;Password=1816;Database=adonai_9999");
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

                        NpgsqlConnection conD = new NpgsqlConnection("Host=" + txtLocalBanco.Text + ";Username=postgres;Password=1816;Database=adonai_" + Convert.ToString(rs.GetInt32(rs.GetOrdinal("IDPessoa"))));
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
            NpgsqlConnection conO = new NpgsqlConnection("Host=" + txtLocalBanco.Text + ";Username=postgres;Password=1816;Database=" + baseOriginal.Text);
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
            
            if (cmbBanco.Text == "PostgreSql")
            {
                generatePostgres();
            }
            else if(cmbBanco.Text == "SQL Server")
            {
                MessageBox.Show("Ainda não configurado", "Atenção", MessageBoxButtons.OK);
            }
            else
            {
                generateMySql();
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
            NpgsqlConnection con = new NpgsqlConnection("Host="+ txtLocalBanco.Text+";Username=postgres;Password=1816;Database=adonai_9999");
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

        private void metroLabel18_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            string conexao = "";
            if(cmbBanco.Text.Equals("PostgreSql"))
            {
                conexao = "\tprivate String url = \"jdbc:postgresql://localhost:5432/\";\n" +
                        "\n" +
                        "\tpublic String getUrl() {\n" +
                        "\t\treturn url;\n" +
                        "\t}\n" +
                        "\n" +
                        "\tpublic boolean openSessionConnections(String db) throws ClassNotFoundException {\n" +
                        "\n" +
                        "\t\tboolean ret;\n" +
                        "\n" +
                        "\t\ttry {\n" +
                        "\t\t\tString url = getUrl()+db;\n" +
                        "\t\t\tClass.forName(\"org.postgresql.Driver\");\n" +
                        "\t\t\tString senha = \"1816\";\n" +
                        "\t\t\tDriverManager.getConnection(url, \"postgres\", senha);\n" +
                        "\t\t\tret = true;\n" +
                        "\t\t} catch (SQLException e) {\n" +
                        "\t\t\tret = false;\n" +
                        "\t\t\tSystem.out.println(e);\n" +
                        "\n" +
                        "\t\t}\n" +
                        "\n" +
                        "\t\treturn ret;\n" +
                        "\t}\n" +
                        "\n" +
                        "\tpublic Connection getNewConnections(String db) throws SQLException {\n" +
                        "\n" +
                        "\t\tConnection con = null;\n" +
                        "\t\tString url = getUrl()+db;\n" +
                        "\t\ttry {\n" +
                        "\t\t\tString senha = \"1816\";\n" +
                        "\t\t\tcon = DriverManager.getConnection(url,\"postgres\",senha);\n" +
                        "\t\t}\n" +
                        "\t\tcatch(SQLException e) {\n" +
                        "\t\t\tSystem.out.println(e);\n" +
                        "\n" +
                        "\t\t}\n" +
                        "\t\treturn con;\n" +
                        "\t}";
            }

            FormUteis txtmodel = new FormUteis(conexao);
            txtmodel.Show();

        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            String util = "public class UtilToken {\n" +
                "\n" +
                "    private String criterios;\n" +
                "\n" +
                "    private int pagina;\n" +
                "\n" +
                "    private String route;\n" +
                "\n" +
                "    public String getRoute() {\n" +
                "        return route;\n" +
                "    }\n" +
                "\n" +
                "    public void setRoute(String route) {\n" +
                "        this.route = route;\n" +
                "    }\n" +
                "\n" +
                "    public int getPagina() {\n" +
                "        return pagina;\n" +
                "    }\n" +
                "\n" +
                "    public void setPagina(int pagina) {\n" +
                "        this.pagina = pagina;\n" +
                "    }\n" +
                "\n" +
                "    public String getCriterios() {\n" +
                "        return criterios;\n" +
                "    }\n" +
                "\n" +
                "    public void setCriterios(String criterios) {\n" +
                "        this.criterios = criterios;\n" +
                "    }\n" +
                "\n" +
                "    public static String decode(String token){\n" +
                "\n" +
                "        String[] tk = token.split(\" \");\n" +
                "        String decode = Base64.base64Decode(tk[1]);\n" +
                "        decode = decode.substring(0,4);\n" +
                "        String[] a = decode.split(\"&\");\n" +
                "        return a[0];\n" +
                "    }\n" +
                "\n" +
                "    public static int decodeId(String token){\n" +
                "\n" +
                "        String[] tk = token.split(\" \");\n" +
                "        String decode = Base64.base64Decode(tk[1]);\n" +
                "        String[] id = decode.split(\"&\");\n" +
                "\n" +
                "        return Integer.parseInt(id[1]);\n" +
                "    }\n" +
                "\n" +
                "    public static String[] decodeUsersApp(String token){\n" +
                "\n" +
                "        String decode = Base64.base64Decode(token);\n" +
                "        String[] tk = decode.split(\"&\");\n" +
                "        return tk;\n" +
                "    }\n" +
                "}";
            FormUteis txtmodel = new FormUteis(util);
            txtmodel.Show();
        }

        private void generatePostgres()
        {
            String model = "";
            dbName = txtDataBase.Text;
            tableName = txtTabela.Text;
            endpointName = txtendpoint.Text;
            util = cheUtil.Checked;
            rest = cheRest.Checked;
            try
            {
                NpgsqlConnection con = new NpgsqlConnection("Host=" + txtLocalBanco.Text + ";Username=" + txtUser.Text + ";Password=" + txtPassword.Text + ";Database=" + txtDataBase.Text);
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
                NpgsqlCommand commandD = new NpgsqlCommand(sql, con);


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
                    if (cheModel.Checked)// Aqui .é o model
                    {
                        if (checlassico.Checked)
                        {
                            if (lang.Text.Equals("Java"))
                                model = Util.Model(coluna, tipo, txtPakage.Text, txtClasse.Text, txtConexao.Text);
                            else if (lang.Text.Equals("C#"))
                                model = Util.ModelCsharp(coluna, tipo, txtPakage.Text, txtClasse.Text, txtConexao.Text);
                            else if (lang.Text.Equals("JavaScript"))
                                model = Util.ModelJs(coluna);
                        }
                        else if (chepain.Checked)
                        {
                            model = Util.ModelPain(coluna, tipo, txtPakage.Text, txtClasse.Text);
                        }

                        Form2 txtmodel = new Form2(model);
                        txtmodel.Show();
                    }
                    if (cheResource.Checked)// Aqui .é o Resource
                    {
                        if (checlassico.Checked)
                        {
                            model = Util.Resource(coluna, tipo, txtPakage.Text, txtClasse.Text, txtendpoint.Text, cheToken.Checked, txtConexao.Text);
                        }
                        else if (chepain.Checked)
                        {
                            model = Util.ResourceCrud(txtPakage.Text, txtClasse.Text, cheToken.Checked);
                        }

                        Form3 txtmodel = new Form3(model);
                        txtmodel.Show();
                    }
                    if (cheController.Checked) // Aqui é o controller, no caso do pain-crud aqui irá mudar
                    {
                        String sqla = "SELECT COUNT(kcu.column_name) as p " +
                            " FROM  information_schema.table_constraints AS tc " +
                                "JOIN information_schema.key_column_usage AS kcu ON tc.constraint_name = kcu.constraint_name AND tc.table_schema = kcu.table_schema " +
                                "JOIN information_schema.constraint_column_usage AS ccu ON ccu.constraint_name = tc.constraint_name AND ccu.table_schema = tc.table_schema" +
                            " WHERE tc.constraint_type = 'FOREIGN KEY' AND tc.table_name = '" + txtTabela.Text + "' " +
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
                        for (i = 0; i < fktableref.Length; i++)
                        {
                            if (fktableref.Equals("pessoa"))
                            {
                                Tabelasref = Tabelasref + fktableref[i] + ".nome, ";
                            }
                            else
                            {
                                Tabelasref = Tabelasref + fktableref[i] + ".descricao, ";
                            }

                        }

                        if (checlassico.Checked)
                        {
                            model = Util.Controller(coluna, tipo, txtPakage.Text, txtClasse.Text, txtTabela.Text, fk, fktableref, cheToken.Checked, txtDataBase.Text, txtConexao.Text);
                        }
                        else if (chepain.Checked)
                        {
                            model = Util.ControllerCrud(txtClasse.Text, txtConexao.Text, cheToken.Checked);
                        }


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

        private void generateMySql()
        {
            String model = "";
            dbName = txtDataBase.Text;
            tableName = txtTabela.Text;
            endpointName = txtendpoint.Text;
            util = cheUtil.Checked;
            rest = cheRest.Checked;
            try
            {
                MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection("Server=" + txtLocalBanco.Text + ";Database=" + txtDataBase.Text + ";Uid=" + txtUser.Text + ";Pwd=" + txtPassword.Text);
                con.Open();
                MySql.Data.MySqlClient.MySqlConnection cona = new MySql.Data.MySqlClient.MySqlConnection("Server=" + txtLocalBanco.Text + ";Database=" + txtDataBase.Text + ";Uid=" + txtUser.Text + ";Pwd=" + txtPassword.Text);
                cona.Open();

                String sql = "SELECT Count(column_name) as p FROM INFORMATION_SCHEMA.COLUMNS where table_name = '" + txtTabela.Text + "' and table_schema = '" + txtDataBase.Text + "'";
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, con);

                MySql.Data.MySqlClient.MySqlDataReader rs = command.ExecuteReader();

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
                sql = "SELECT column_name as coluna, data_type as tipo FROM INFORMATION_SCHEMA.COLUMNS where table_name = '" + txtTabela.Text + "' and table_schema = '"+ txtDataBase.Text + "' ORDER BY ORDINAL_POSITION";
                MySql.Data.MySqlClient.MySqlCommand commandD = new MySql.Data.MySqlClient.MySqlCommand(sql, con);


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
                    if (cheModel.Checked)// Aqui .é o model
                    {
                        if (checlassico.Checked)
                        {
                            if(lang.Text.Equals("Java"))
                                model = Util.Model(coluna, tipo, txtPakage.Text, txtClasse.Text, txtConexao.Text);
                            else if(lang.Text.Equals("C#"))
                                model = Util.ModelCsharp(coluna, tipo, txtPakage.Text, txtClasse.Text, txtConexao.Text);
                            else if (lang.Text.Equals("JavaScript"))
                                model = Util.ModelJs(coluna);
                        }
                        else if (chepain.Checked)//apenas java
                        {
                            model = Util.ModelPain(coluna, tipo, txtPakage.Text, txtClasse.Text);
                        }

                        Form2 txtmodel = new Form2(model);
                        txtmodel.Show();
                    }
                    if (cheResource.Checked)// Aqui .é o Resource
                    {
                        if (checlassico.Checked)
                        {
                            model = Util.Resource(coluna, tipo, txtPakage.Text, txtClasse.Text, txtendpoint.Text, cheToken.Checked, txtConexao.Text);
                        }
                        else if (chepain.Checked)
                        {
                            model = Util.ResourceCrud(txtPakage.Text, txtClasse.Text, cheToken.Checked);
                        }

                        Form3 txtmodel = new Form3(model);
                        txtmodel.Show();
                    }
                    if (cheController.Checked) // Aqui é o controller, no caso do pain-crud aqui irá mudar
                    {
                        //String sqla = "SELECT COUNT(kcu.column_name) as p " +
                        //    " FROM  information_schema.table_constraints AS tc " +
                        //        "JOIN information_schema.key_column_usage AS kcu ON tc.constraint_name = kcu.constraint_name AND tc.table_schema = kcu.table_schema " +
                        //        "JOIN information_schema.constraint_column_usage AS ccu ON ccu.constraint_name = tc.constraint_name AND ccu.table_schema = tc.table_schema" +
                        //    " WHERE tc.constraint_type = 'FOREIGN KEY' AND tc.table_name = '" + txtTabela.Text + "' " +
                        //    " group by kcu.column_name,ccu.table_name,ccu.column_name";

                        //NpgsqlCommand commandE = new NpgsqlCommand(sqla, cona);
                        //NpgsqlDataReader rsE = commandE.ExecuteReader();

                        //count = 0;
                        //if (rsE.HasRows)
                        //{

                        //    while (rsE.Read())
                        //    {

                        //        count++;
                        //    }
                        //}
                        //rsE.Close();
                        //cona.Close();

                        //cona.Open();

                        //sqla = "SELECT kcu.column_name, ccu.table_name AS tabelaref, ccu.column_name AS columnref, tc.table_name," +
                        //    " ('INNER JOIN ' || ccu.table_name || ' ON ' || tc.table_name || '.' || kcu.column_name || ' = ' || ccu.table_name || '.' || ccu.column_name )as fk " +
                        //    " FROM  information_schema.table_constraints AS tc " +
                        //        "JOIN information_schema.key_column_usage AS kcu ON tc.constraint_name = kcu.constraint_name AND tc.table_schema = kcu.table_schema " +
                        //        "JOIN information_schema.constraint_column_usage AS ccu ON ccu.constraint_name = tc.constraint_name AND ccu.table_schema = tc.table_schema" +
                        //    " WHERE tc.constraint_type = 'FOREIGN KEY' AND tc.table_name = '" + txtTabela.Text + "' " +
                        //    " group by kcu.column_name,ccu.table_name,ccu.column_name, tc.table_name ";

                        //commandE = new NpgsqlCommand(sqla, cona);
                        //rsE = commandE.ExecuteReader();


                        //String[] fk = new string[count];
                        //String[] fktableref = new string[count];

                        //if (rsE.HasRows)
                        //{
                        //    i = 0;
                        //    while (rsE.Read())
                        //    {
                        //        fk[i] = rsE.GetString(rsE.GetOrdinal("fk"));
                        //        fktableref[i] = rsE.GetString(rsE.GetOrdinal("tabelaref"));
                        //        i = i + 1;
                        //    }
                        //}
                        //rsE.Close();
                        //String Tabelasref = "";
                        //for (i = 0; i < fktableref.Length; i++)
                        //{
                        //    if (fktableref.Equals("pessoa"))
                        //    {
                        //        Tabelasref = Tabelasref + fktableref[i] + ".nome, ";
                        //    }
                        //    else
                        //    {
                        //        Tabelasref = Tabelasref + fktableref[i] + ".descricao, ";
                        //    }

                        //}

                        if (checlassico.Checked)
                        {
                            if (lang.Text.Equals("Java"))
                                model = Util.Controller(coluna, tipo, txtPakage.Text, txtClasse.Text, txtTabela.Text,new String[10], new String[10], cheToken.Checked, txtDataBase.Text, txtConexao.Text);
                            else if (lang.Text.Equals("C#"))
                                model = Util.ControllerCSharpSimple(coluna, tipo, txtPakage.Text, txtClasse.Text, txtTabela.Text, new String[10], new String[10], cheToken.Checked, txtDataBase.Text, txtConexao.Text);
                        }
                        else if (chepain.Checked)
                        {
                            model = Util.ControllerCrud(txtClasse.Text, txtConexao.Text, cheToken.Checked);
                        }


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
    }
}
