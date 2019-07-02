using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YK.CodeGenerator
{
    public class SqlParameterGen
    {
        public static string GenCode(string tSqlParameters)
        {
            var b = new StringBuilder();
            var pmArr = tSqlParameters.Split("\r\n,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var pmDict = new List<string>();
            var procName = "Noname";
            for (var i = 0; i < pmArr.Length; i++)
            {
                pmArr[i] = pmArr[i].Trim();
                if (i == 0 && (pmArr[i].ToUpper().Contains(" PROCEDURE ") || pmArr[i].ToUpper().Contains(" PROC ")))
                {
                    procName = pmArr[i].Split(" .[]".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Last().Trim();
                    continue;
                }

                if (string.IsNullOrWhiteSpace(pmArr[i]) || pmArr[i].StartsWith("--") || pmArr[i].StartsWith("/*"))
                {
                    continue;
                }

                var p = pmArr[i].Split("[] ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (p.Length < 2)
                {
                    throw new Exception(pmArr[i]);
                }

                var paramName = p[0];
                pmDict.Add(paramName);
            }

            b.AppendLine("#region [PROCNAME]".Replace("[PROCNAME]", procName));
            b.AppendLine("public static SqlCommand [PROCNAME]() {".Replace("[PROCNAME]", procName));
            b.AppendLine("var cmd = new SqlCommand(\"[PROCNAME]\") { CommandType = CommandType.StoredProcedure };"
                .Replace("[PROCNAME]", procName));

            for (var i = 0; i < pmDict.Count; i++)
            {
                b.AppendLine("cmd.Parameters.Add(new SqlParameter() { ParameterName = \"[PMNAME]\" });".Replace("[PMNAME]", pmDict[i]));
            }

            b.AppendLine("return cmd;");
            b.AppendLine("}");
            b.AppendLine("#endregion");
            return b.ToString();
        }
    }
}
