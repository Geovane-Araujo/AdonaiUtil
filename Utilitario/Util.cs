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
            codigo = codigo + "import java.io.Serializable; \n\n";
            codigo = codigo + "public class "+ classe + "Model implements Serializable {\n\n\n";
            codigo = codigo + "    private static final long serialVersionUID = 1L;\n\n";

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
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "byte[]";
                }
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "byte[]";
                }
                else if (tipo[i].Equals("bigint"))
                {
                    tipoatributo = "long";
                }

                aux = coluna[i];
                atributo = char.ToLower(aux[0]) + aux.Substring(1);
                codigo = codigo + "    private " + tipoatributo + " " + atributo + "; \n\n";
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
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "byte[]";
                }
                else if (tipo[i].Equals("bytea"))
                {
                    tipoatributo = "byte[]";
                }
                else if (tipo[i].Equals("bigint"))
                {
                    tipoatributo = "long";
                }

                aux = coluna[i];
                atributo = char.ToUpper(aux[0]) + aux.Substring(1);
                aux2 = coluna[i];
                atributo2 = char.ToLower(aux2[0]) + aux.Substring(1);

                // getters
                codigo = codigo + "    public " + tipoatributo + " get"+atributo+"() { \n";
                codigo = codigo + "        return " + atributo2 + ";\n";
                codigo = codigo + "    }\n\n\n";

                //setter
                codigo = codigo + "    public void set" + atributo + "("+tipoatributo+" " + atributo2 + ") { \n";
                codigo = codigo + "        this." + atributo2 + " = "+ atributo2 + ";\n";
                codigo = codigo + "    }\n\n";
            }
            codigo = codigo + "\n}";


            return codigo;
        }

        public static String Resource(String[] coluna, String[] tipo, String package, String classe)
        {
            
            String atributo = "";
            var aux = "";
            char aspas = (char) 34;

            String codigo = "package " + package + ".resource;\n\n";
            codigo = codigo + "import org.springframework.http.ResponseEntity; \n";
            codigo = codigo + "import org.springframework.web.bind.annotation.*; \n";
            codigo = codigo + "import java.sql.SQLException; \n\n\n";

            codigo = codigo + "@RestController \n";
            codigo = codigo + "@RequestMapping(value = "+aspas+"/adonai"+aspas+") \n";
            codigo = codigo + "@CrossOrigin(origins =" + aspas + "*" + aspas + ") \n";
            codigo = codigo + "public class " + classe + "Resource {\n\n\n";

            aux = classe;
            atributo = char.ToLower(aux[0]) + aux.Substring(1);
            // save
            codigo = codigo + "    @PostMapping(" + aspas + "/"+ atributo + aspas + ") \n";
            codigo = codigo + "    public ResponseEntity<?> save(@RequestHeader(value = "+aspas+ "Authorization"+aspas+"String token, @RequestBody "+classe+"Model "+ atributo + ") throws SQLException {\n\n\n";

            codigo = codigo + "        "+classe + "Controller " + atributo + "controller = new " + classe + "Controller;\n";
            codigo = codigo + "        Object obj = " + atributo + "controller.save(token," + atributo+");\n";
            codigo = codigo + "        return ResponseEntity.ok().body(obj);\n\n";
            codigo = codigo + "    }\n\n\n";


            // get
            codigo = codigo + "    @GetMapping(" + aspas + "/" + atributo + "/{pagina}/{criterios}"+ aspas + ") \n";
            codigo = codigo + "    public ResponseEntity<?> get(@RequestHeader(value = " + aspas + "Authorization" + aspas + "String token, @PathVariable(value=" + aspas + "pagina " + aspas + ") int pagina, @PathVariable(value=" + aspas + "criterios " + aspas + ") String criterios) throws SQLException {\n\n\n";


            codigo = codigo + "        Object obj = " + aspas + "" + aspas+ ";\n";
            codigo = codigo + "        if(criterios.equals("+aspas+"a" + aspas + ")){\n\n";
            codigo = codigo + "            criterios = " + aspas + "" + aspas + ";\n";
            codigo = codigo + "         }\n\n";
            codigo = codigo + "        "+classe + "Controller " + atributo + "controller = new " + classe + "Controller;\n";
            codigo = codigo + "        obj = " + atributo + "controller.get(token, pagina, criterios);\n";
            codigo = codigo + "        return ResponseEntity.ok().body(obj);\n\n";
            codigo = codigo + "    }\n\n\n";


            // getbyId
            codigo = codigo + "    @GetMapping(" + aspas + "/" + atributo + "/{id}" + aspas + ") \n";
            codigo = codigo + "    public ResponseEntity<?> get(@RequestHeader(value = " + aspas + "Authorization" + aspas + "String token, @PathVariable(value=" + aspas + "id " + aspas + ") int id) throws SQLException {\n\n\n";


            codigo = codigo + "        Object obj = " + aspas + "" + aspas + ";";
            codigo = codigo + "        "+ classe + "Controller " + atributo + "controller = new " + classe + "Controller;\n";
            codigo = codigo + "        obj = " + atributo + "controller.getbyId(token, id);\n";
            codigo = codigo + "        return ResponseEntity.ok().body(obj);\n\n";
            codigo = codigo + "    }\n";

            codigo = codigo + "}\n\n\n";

            return codigo;
        }

        public static String Controller(String[] coluna, String[] tipo, String package, String classe, String tabela)
        {

            String atributo = "";
            var aux = "";
            String sql = "";
            char aspas = (char)34;

            String codigo = "package " + package + ".controller;\n\n";


            codigo = codigo + "public class " + classe + "Controller {\n\n\n";
            codigo = codigo = "Connect connection = new Connection();\n";
            codigo = codigo = "UtilController util = new UtilController();\n";
            codigo = codigo = "String sql ="+aspas+""+aspas+" ;\n";
            codigo = codigo = "String descricao = "+aspas+"Cadastro."+classe+";\n";
            codigo = codigo = "String log =" + aspas + "" + aspas + " ;\n";

            aux = classe;
            atributo = char.ToLower(aux[0]) + aux.Substring(1);

            // save
            codigo = codigo + "    public "+classe+"save(String token, "+classe+"Model) throws SQLException {\n\n\n";

            codigo = codigo + "        Connection con = null;\n";
            codigo = codigo + "        PreparedStatement stmt = null;\n";
            codigo = codigo + "        ResultSet rs = null;\n\n\n";

            codigo = codigo + "        int scalar = 0;\n\n";

            codigo = codigo + "        try{\n\n";

            codigo = codigo + "        String decode = Util.decode(token);\n";
            codigo = codigo + "        con = connection.Conexao(decode);\n\n";

            codigo = codigo + "        con.setAutoCommit(false);\n\n";

            codigo = codigo + "            if("+classe+"Model.isAdd()){\n\n";

            for(int i = 0;i < coluna.Length; i++)
            {
                sql = sql + ", " +coluna[i];
            }

            codigo = codigo + "                "+aspas+"INSERT INTO"+tabela+"("+ sql + aspas+"\n\n";

            codigo = codigo + "    }\n";

            codigo = codigo + "}\n\n\n";

            return codigo;
        }
    }
}
