using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Motorista
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cnh { get; set; }
        public string telefone  { get; set; }
        public string email { get; set; }
        public int senha { get; set; }
    }
}