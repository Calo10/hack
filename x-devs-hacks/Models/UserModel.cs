using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace x_devs_hacks.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public int Rol { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}