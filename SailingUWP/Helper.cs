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
            

            //  Luke's PC Name : SSGDYHFG-PC 192.168.1.96
            //  Adrian's PC Name : HP-Office  192.168.1.9
            //  Instructions to open port on Windows 10 PC :
            //  1.  start Windows Defender Firewall
            //  2.  Select advanced Settings
            //  3. Select Inbound rules (lefthand Pane)
            //  4.  Select "New Rule" (under righthand Actions Pane)
            //  5.  Type of Rule = Port => next
            //  6.  Apply to specific port "3306" => next
            //  7.  "allow the connection" => next => next
            //  8.  Name the connection e.g "MySQL Inbound"
            //  9.  Repeat for Outbound port


            
            string connect = @"Server=192.168.1.96;Database=sailing;Uid=root;Pwd=abc123;";

           // string connect = @"Server=SSGDYHFG-PC;Database=sailing;Uid=adrian;Pwd=abc123;";

            //;  providerName=MySQL.Data.MySqlClient";
        return connect;
                }

    }
}
