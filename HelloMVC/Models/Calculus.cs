using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloMVC.Models
{
    public class Calculus
    {
                      
        public int Nr1 { get; set; }
        public int Nr2 { get; set;}

        public int Result{ get; set;}

        public string Operand { get; set; }

        public string ErrorMessage { get; set; }


    }
}
