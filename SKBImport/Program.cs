using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nsDB2CBase.DB2CConnector;
using System.Data.Common;


namespace SKBImport
{
    class Program
    {
        static void Main(string[] args)
        {
            string SQL = "Select * from Users";
            DB2CConnection conn = new DB2CConnection();
            //conn.ConnectionString(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=SKB_BDD;Integrated Security=True");
            DB2CDataAdapter da = new DB2CDataAdapter();
            DB2CCommand cmd = (DB2CCommand)conn.CreateCommand();
            cmd.CommandText = SQL;
            da.SelectCommand = cmd;
           // DataSet ds = new DataSet();

            conn.Open();
         
                    using (var r = cmd.ExecuteReader())
                    {
                        foreach (DbDataRecord s in r)
                        {
                            string val = s.GetString(2);
                            Console.WriteLine(val);
                        }
                    }
                

            
            conn.Close();

            Console.ReadKey();
        }
    }
}
