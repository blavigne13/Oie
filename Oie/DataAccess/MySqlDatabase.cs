using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data;
using Oie.DataAccess.DbSets;

namespace Oie.DataAccess
{
    public class MySqlDatabase
    {
        public void Test()
        {
            var cs = "server=labdb.acs.uwosh.edu;uid=thomaj46;pwd=0455446;database=thomaj46;";
            using (var con = new MySqlConnection(cs))
            {
                var query = "select * from fakedepts where name = 'Urology'";
                con.Open();
                var command = new MySqlCommand(query, con);
                var adapter = new MySqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);

                foreach (var row in dataset.Tables[0].AsEnumerable())
                {
                    Debug.WriteLine(row.Field<string>("name"));
                }
            }
        }
    }
}
