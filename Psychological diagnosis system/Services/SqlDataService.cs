using MySql.Data.MySqlClient;
using Psychological_diagnosis_system.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological_diagnosis_system.Services
{
    class SqlDataService //: IDataService
    {
        string connStr = "server = localhost;user = root;database = psychological_diagnosisi_system;port = 3306; password = root";
        MySqlConnection conn = null;
        MySqlDataReader rdr = null;
        public List<User> GetUsers()
        {
            List<User> users = new List<User> ();
            //try
            //{
            //    conn = new MySqlConnection(connStr);
            //    conn.Open();

            //    string stm = "SELECT * FROM USER_INFO";
            //    MySqlCommand cmd = new MySqlCommand(stm, conn);
            //    rdr = cmd.ExecuteReader();

            //    while(rdr.Read())
            //    {

            //    }
            //}
            return users;
        }
    }
}
