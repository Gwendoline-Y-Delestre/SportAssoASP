using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportAssoASP.Models
{
    public class InscriptionData
    {
        public int ActiviteID { get; set; }
        public string Sport { get; set; }
        public string Section { get; set; }
        public string Jour { get; set; }
        public string Heure { get; set; }
        public int Capacite_max { get; set; }
        public decimal Prix { get; set; }
    }
}