using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeterSpellen.Models
{
    public class Vraag
    {
        [PrimaryKey, AutoIncrement]
        public int VraagID { get; set; }
        public string DagVraag { get; set; }
        public string Antwoord1 { get; set; }
        public string Antwoord2 { get; set; }
        public string Antwoord3 { get; set; }
        public string Antwoord4 { get; set; }
        public int GoedeAntwoord { get; set; }
        
    }

}
