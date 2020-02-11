using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeterSpellen.Models
{
    class opties
    {
        [PrimaryKey, AutoIncrement]
        public int optie_id { get; set; }
        [ForeignKey(typeof(vragen))]
        public int vraag_id { get; set; }
        [MaxLength(255)]
        public string optie { get; set; }
        public bool juist { get; set; }

    }
}
