using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace ServerPOI.Conection
{
    public class Connection
    {
        public static MySqlConnection con() 
        {
            string server = "localhost";
            string uid = "root";
            string password = "admin";
            string database="projectoPoi";
            MySqlConnection conectar = new MySqlConnection("server="+server+";"+ "database="+ database +
                ";" + "uid="+uid+";"+ "pwd="+password+");
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=projectoPoi; uid=root; pwd=admin");
           
            conectar.Open();
            return conectar;
        }

    }
}
