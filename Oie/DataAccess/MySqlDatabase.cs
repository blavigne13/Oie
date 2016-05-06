using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Oie.DataAccess
{
    public class MySqlDatabase
    {
        public void Test()
        {
            var cs = "server=labdb.acs.uwosh.edu;uid=thomaj46;pwd=0455446;database=thomaj46;";
            using (var con = new MySqlConnection(cs))
            {
                var query = "select * from fakedepts";
                con.Open();
                var command = new MySqlCommand(query, con);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine(reader[0]);
                }
            }
        }
    }
}
