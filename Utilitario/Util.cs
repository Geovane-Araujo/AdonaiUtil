using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdonaiSoft_Utilitario.Utilitario
{
    class Util
    {
        public static String Model(String[] coluna, String[] tipo, String package, String classe)
        {
            String atributo = "";
            String atributo2 = "";
            String tipoatributo = "";
            var aux = "";
            var aux2 = "";

            String codigo = "package " + package + ";\n\n";
            codigo += "import java.io.Serializable; \n\n";
            codigo += "public class " + classe + "Model implements Serializable {\n\n\n";
            codigo += "    private static final long serialVersionUID = 1L;\n\n";

            for(int i = 0;i < coluna.Length; i++)
            {
                if (tipo[i].Equals("integer"))
                {
                    tipoatributo = "int";
                }
                else if(tipo[i].Equals("character varying"))
                {
                    tipoatributo = "String";
                }
                else if (tipo[i].Equals("real"))
                {
                    tipoatributo = "double";
                }
                else if (tipo[i].Equals("text"))
                {
                    tipoatributo = "String";
                }
                else if (tipo[i].Equals("double precision"))
                {
                    tipoatributo = "double";
                }
                else if (tipo[i].Equals("byte"))
                {
                    tipoatributo = "byte";
                }
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "bytes";
                }
                else if (tipo[i].Equals("bigint"))
                {
                    tipoatributo = "long";
                }
                else if (tipo[i].Equals("timestamp without time zone"))
                {
                    tipoatributo = "Timestamp";
                }
                else if (tipo[i].Equals("date"))
                {
                    tipoatributo = "Date";
                }

                aux = coluna[i];
                atributo = char.ToLower(aux[0]) + aux.Substring(1);
                codigo += "    private " + tipoatributo + " " + atributo + "; \n\n";
            }

            for (int i = 0; i < coluna.Length; i++)
            {
                if (tipo[i].Equals("integer"))
                {
                    tipoatributo = "int";
                }
                else if (tipo[i].Equals("character varying"))
                {
                    tipoatributo = "String";
                }
                else if (tipo[i].Equals("real"))
                {
                    tipoatributo = "double";
                }
                else if (tipo[i].Equals("text"))
                {
                    tipoatributo = "String";
                }
                else if (tipo[i].Equals("double precision"))
                {
                    tipoatributo = "double";
                }
                else if (tipo[i].Equals("byte"))
                {
                    tipoatributo = "byte";
                }
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "bytes";
                }
                else if (tipo[i].Equals("bigint"))
                {
                    tipoatributo = "long";
                }
                else if (tipo[i].Equals("timestamp without time zone"))
                {
                    tipoatributo = "Timestamp";
                }
                else if (tipo[i].Equals("date"))
                {
                    tipoatributo = "Date";
                }

                aux = coluna[i];
                atributo = char.ToUpper(aux[0]) + aux.Substring(1);
                aux2 = coluna[i];
                atributo2 = char.ToLower(aux2[0]) + aux.Substring(1);

                // getters
                codigo += "    public " + tipoatributo + " get"+atributo+"() { \n";
                codigo += "        return " + atributo2 + ";\n";
                codigo += "    }\n\n\n";

                //setter
                codigo += "    public void set" + atributo + "("+tipoatributo+" " + atributo2 + ") { \n";
                codigo += "        this." + atributo2 + " = "+ atributo2 + ";\n";
                codigo += "    }\n\n";
            }
            codigo += "\n}";


            return codigo;
        }

        public static String Resource(String[] coluna, String[] tipo, String package, String classe)
        {
            
            String atributo = "";
            var aux = "";
            char aspas = (char) 34;

            String codigo = "package " + package + ".resource;\n\n";
            codigo += "import org.springframework.http.ResponseEntity; \n";
            codigo += "import org.springframework.web.bind.annotation.*; \n";
            codigo += "import java.sql.SQLException; \n\n\n";

            codigo += "@RestController \n";
            codigo += "@RequestMapping(value = " +aspas+"/adonai"+aspas+") \n";
            codigo += "@CrossOrigin(origins =" + aspas + "*" + aspas + ") \n";
            codigo += "public class " + classe + "Resource {\n\n\n";

            aux = classe;
            atributo = char.ToLower(aux[0]) + aux.Substring(1);
            var atr = atributo + "controller";

            codigo += "    @Autowired\n";
            codigo += "    private " + classe + "Controller " + atr.ToLower() + ";\n\n";
            // save
            codigo += "    @PostMapping(" + aspas + "/"+ atributo.ToLower() + aspas + ") \n";
            codigo += "    public ResponseEntity<?> save(@RequestHeader(value = " +aspas+ "Authorization"+aspas+")String token, @RequestBody "+classe+" "+ atributo.ToLower() + ") throws SQLException {\n\n";

            codigo += "        Object obj = " + atr.ToLower() + ".save(token," + atributo+");\n";
            codigo += "        return ResponseEntity.ok().body(obj);\n\n";
            codigo += "    }\n\n\n";

            // getbyId
            codigo += "    @GetMapping(" + aspas + "/" + atributo.ToLower() + "/{id}" + aspas + ") \n";
            codigo += "    public ResponseEntity<?> get(@RequestHeader(value = " + aspas + "Authorization" + aspas + ")String token, @PathVariable(value=" + aspas + "id " + aspas + ") int id) throws SQLException {\n\n";

            codigo += "        Object obj = " + atr.ToLower() + ".getbyId(token, id);\n";
            codigo += "        return ResponseEntity.ok().body(obj);\n\n";
            codigo += "    }\n";

            codigo += "}\n\n\n";

            return codigo;
        }

        public static String Controller(String[] coluna, String[] tipo, String package, String classe, String tabela,String[] fk, String[] fktableref )
        {

            String atributo = "";
            String tipoatributo = "";
            var aux = "";
            String sql = "";
            char aspas = (char)34;
            String column = "";

            String codigo = "package " + package + ".controller;\n\n";


            codigo += "    public class " + classe + "Controller {\n\n\n";
            codigo += "    Connect connection = new Connection();\n";
            codigo += "    UtilController util = new UtilController();\n";
            codigo += "    String sql =" +aspas+""+aspas+" ;\n";
            codigo += "    String descricao = " +aspas+"Cadastro."+classe+";\n";
            codigo += "    String log =" + aspas + "" + aspas + " ;\n\n\n\n";

            aux = classe;
            atributo = char.ToLower(aux[0]) + aux.Substring(1);

            // save
            codigo += "    public Object save(String token, " +classe+ "Model  "+ atributo + ") throws SQLException {\n\n\n";

            codigo += "        Connection con = null;\n";
            codigo += "        PreparedStatement stmt = null;\n";
            codigo += "        ResultSet rs = null;\n\n\n";

            codigo += "        Hashtable retorno = new Hashtable();n\n\n";

            codigo += "        int scalar = 0;\n\n";

            codigo += "        try{\n\n";

            codigo += "        String decode = Util.decode(token);\n";
            codigo += "        con = connection.Conexao(decode);\n\n";

            codigo += "        con.setAutoCommit(false);\n\n";

            // add
            codigo += "            if(" + atributo + ".isAdd()){\n\n";

            String values = "";
            for(int i = 1;i < coluna.Length; i++)
            {
                sql = sql + ", " +coluna[i];
                values += "?, ";
            }

            codigo += "                sql = " +aspas+"INSERT INTO "+tabela+"("+ sql+") VALUES("+ values+");" + aspas+";\n\n\n";
            codigo += "                stmt = con.prepareStatement(sql);\n\n\n\n";
            int a = 1;
            for (int i = 1; i < coluna.Length; i++)
            {
                if (tipo[i].Equals("integer"))
                {
                    tipoatributo = "stmt.setInt(";
                }
                else if (tipo[i].Equals("character varying"))
                {
                    tipoatributo = "stmt.setString(";
                }
                else if (tipo[i].Equals("real"))
                {
                    tipoatributo = "stmt.setDouble(";
                }
                else if (tipo[i].Equals("text"))
                {
                    tipoatributo = "stmt.setString(";
                }
                else if (tipo[i].Equals("double precision"))
                {
                    tipoatributo = "stmt.setDouble(";
                }
                else if (tipo[i].Equals("byte"))
                {
                    tipoatributo = "stmt.setByte(";
                }
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "stmt.setBytea(";
                }
                else if (tipo[i].Equals("bigint"))
                {
                    tipoatributo = "stmt.setLong(";
                }
                else if (tipo[i].Equals("timestamp without time zone"))
                {
                    tipoatributo = "stmt.setTimestamp(";
                }
                else if (tipo[i].Equals("date"))
                {
                    tipoatributo = "stmt.setDate(";
                }

                aux = coluna[i];
                column = char.ToUpper(aux[0]) + aux.Substring(1);
               
                
                codigo +=  "                "+tipoatributo+ +a+", " + atributo+".get"+ column + "());\n";
                a = a + 1;
            }
            codigo += "                stmt.execute();\n\n\n\n";
            codigo += "                log = " +aspas+"Adicionaou"+aspas+";\n\n\n\n";
            codigo += "            }\n\n\n\n";


            // edit
            codigo += "            if(" + atributo + ".isEdit()){\n\n";

            sql = "";
            for (int i = 1; i < coluna.Length; i++)
            {
                sql = sql + coluna[i]+ " = ?, ";
            }

            

            codigo += "                sql = " + aspas + "UPDATE " + tabela + " SET " + sql + " WHERE id = ? ;" + aspas + "\n\n\n";
            codigo += "                stmt = con.prepareStatement(sql);\n\n\n\n";
            a = 1;
            for (int i = 1; i < coluna.Length; i++)
            {
                if (tipo[i].Equals("integer"))
                {
                    tipoatributo = "stmt.setInt(";
                }
                else if (tipo[i].Equals("character varying"))
                {
                    tipoatributo = "stmt.setString(";
                }
                else if (tipo[i].Equals("real"))
                {
                    tipoatributo = "stmt.setDouble(";
                }
                else if (tipo[i].Equals("text"))
                {
                    tipoatributo = "stmt.setString(";
                }
                else if (tipo[i].Equals("double precision"))
                {
                    tipoatributo = "stmt.setDouble(";
                }
                else if (tipo[i].Equals("byte"))
                {
                    tipoatributo = "stmt.setByte(";
                }
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "stmt.setBytea(";
                }
                else if (tipo[i].Equals("bigint"))
                {
                    tipoatributo = "stmt.setLong(";
                }
                else if (tipo[i].Equals("timestamp without time zone"))
                {
                    tipoatributo = "stmt.setTimestamp(";
                }
                else if (tipo[i].Equals("date"))
                {
                    tipoatributo = "stmt.setDate(";
                }

                aux = coluna[i];
                column = char.ToUpper(aux[0]) + aux.Substring(1);


                codigo = codigo + "                " + tipoatributo + a + ", " + atributo + ".get" + column + "());\n";
                a = a + 1;
            }
            codigo = codigo + "                " + tipoatributo + a + ", " + atributo + ".getId());\n";

            codigo += "                stmt.execute();\n\n\n\n";
            codigo += "                log = " + aspas + "Editou" + aspas + ";\n\n\n\n";
            codigo += "            }\n\n\n\n";


            // del
            codigo += "            if(" + atributo + ".isDel()){\n\n";

            aux = coluna[0];
            column = char.ToLower(aux[0]) + aux.Substring(1);

            codigo += "                sql = " + aspas + "DELETE FROM " + tabela + " WHERE id = "+ atributo + ".getId();" + aspas + "\n\n\n";
            codigo += "                stmt = con.prepareStatement(sql);\n\n";
            codigo += "                stmt.execute();\n\n";

           
            codigo += "                log = " + aspas + "Apagou" + aspas + ";\n\n";
            codigo += "            }\n\n\n\n";

            codigo += "            retorno.put(" +aspas+"ret"+aspas+", "+aspas+"success"+aspas+");\n";
            codigo += "            retorno.put(" + aspas + "motivo" + aspas + ", " + aspas + "OK" + aspas + ");\n";
            codigo += "            retorno.put(" + aspas + "obj" + aspas + ", " + atributo + ");\n";


            codigo += "        }\n";
            codigo += "        catch(SQLException e) {\n\n";
            codigo += "            retorno.put(" + aspas + "ret" + aspas + ", " + aspas + "unsuccess" + aspas + ");\n";
            codigo += "            retorno.put(" + aspas + "motivo" + aspas + ", e.getMessage());\n\n";
            codigo += "        }\n";
            codigo += "        finally {\n";
            codigo += "            con.close();\n";
            codigo += "            rs.close();\n";
            codigo += "            stmt.close();\n";
            codigo += "        }\n\n";
            codigo += "        return retorno;\n";
            codigo += "    }\n";


            codigo += "    public Object getById(String token, int id) throws SQLException {\n\n\n";

            codigo += "        sql = " +aspas+"SELECT  "+aspas+";\n";

            codigo += "        Connection con = null;\n";
            codigo += "        PreparedStatement stmt = null;\n";
            codigo += "        ResultSet rs = null;\n";
            codigo += "        Hashtable retorno = new Hashtable();\n\n\n";

            codigo += "        try{\n\n";

            codigo += "            String decode = Util.decode(token);\n";
            codigo += "            con = connection.Conexao(decode);\n";
            codigo += "            stmt = con.prepareStatement(sql);\n";
            codigo += "            rs = stmt.executeQuery();\n\n";

            codigo += "            while(rs.next()){\n";


            codigo += "            }\n";

            codigo += "            retorno.put(" + aspas + "ret" + aspas + ", " + aspas + "success" + aspas + ");\n";
            codigo += "            retorno.put(" + aspas + "motivo" + aspas + ", " + aspas + "OK" + aspas + ");\n";
            codigo += "            retorno.put(" + aspas + "obj" + aspas + ", " + atributo + ");\n";


            codigo += "        }\n";
            codigo += "        catch(SQLException e) {\n\n";
            codigo += "            retorno.put(" + aspas + "ret" + aspas + ", " + aspas + "unsuccess" + aspas + ");\n";
            codigo += "            retorno.put(" + aspas + "motivo" + aspas + ", e.getMessage());\n\n";
            codigo += "        }\n";
            codigo += "        finally {\n";
            codigo += "            con.close();\n";
            codigo += "            rs.close();\n";
            codigo += "            stmt.close();\n";
            codigo += "        }\n\n";
            codigo += "        return retorno;\n";
            codigo += "    }\n";


            codigo += "}\n\n\n";

            return codigo;
        }
    }
}
