using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Database_Connection
{
    class Connection
    {
        MySqlConnection cn = new MySqlConnection();
        MySqlCommand cm = new MySqlCommand();
        MySqlDataReader dr;
        private string con;
        public string MyConnection()
        {
            con = @"server=localhost;database=hotel;User Id=root;password=";
            return con;
        }
    }
}
