using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SailingUWP
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {
            //return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            string connect = @"Server=192.168.1.96;Database=sailing;Uid=root;Pwd=abc123;";
            //;  providerName=MySQL.Data.MySqlClient";
        return connect;
                }

    }
}
