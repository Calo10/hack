using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace x_devs_hacks.Models
{
    public class PickUpRequestModel
    {
        public int id { get; set; }
        public int IdUser { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Status { get; set; }
    }
}