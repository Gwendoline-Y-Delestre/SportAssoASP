using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportAssoASP.Models
{
    public class Employe
    {
        public int EmployeID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }

        public string NomPrenom { get; set; }

        public string Datedenaissane { get; set; }


    }
}