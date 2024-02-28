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
            public string Img1 { get; set; }
            public string Img2 { get; set; }
            public string Img3 { get; set; }
            public bool Visible { get; set; }
        
    }
}