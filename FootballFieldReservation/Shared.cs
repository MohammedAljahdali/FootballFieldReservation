using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FootballFieldReservation
{
    public class Shared
    {
        
        public static string conn =
            File.OpenText(
                (AppDomain.CurrentDomain.BaseDirectory.ToString()).Substring(0,
                (AppDomain.CurrentDomain.BaseDirectory.ToString().Length - 
                    "FootballFieldReservation".Length - 1)) + "ignore/" + "conn.txt").ReadToEnd();

    }
}