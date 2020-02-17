using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeterSpellen.Models
{
    public class OptieModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(VraagModel))]
        public int VraagId { get; set; }
        [MaxLength(255)]
        public string Optie { get; set; }
        public bool Juist { get; set; }

    }
}
