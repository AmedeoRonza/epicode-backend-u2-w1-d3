using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Scarpe
    {
            public int IdProdotto { get; set; }
            public string NomeProdotto { get; set; }
            public string Descrizione { get; set; }
            public decimal Prezzo { get; set; }
            public string img1 { get; set; }
            public string img2 { get; set; }
            public string img3 { get; set; }
            public bool Visible { get; set; }

        public Scarpe() { }

    }
}