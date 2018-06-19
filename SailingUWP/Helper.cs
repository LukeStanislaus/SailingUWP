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
            
            // Luke's PC Name : SSGDYHFG-PC 192.168.1.96
            //Adrian's PC Name : HP-Office  192.168.1.9
            string connect = @"Server=SSGDYHFG-PC;Database=sailing;Uid=adrian;Pwd=abc123;";

            //;  providerName=MySQL.Data.MySqlClient";
        return connect;
                }

    }
}
