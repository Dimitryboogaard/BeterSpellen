using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeterSpellen.Models
{
    class antwoorden
    {
        [PrimaryKey, AutoIncrement]
        public int antwoorden_id { get; set; }
        [ForeignKey(typeof(opties))]
        public int optie_id { get; set; }
        [MaxLength(255)]
        public int user_id { get; set; }
        public bool juist { get; set; }
        public bool antwoord { get; set; }
    }
}
