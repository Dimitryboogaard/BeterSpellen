using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace BeterSpellen.Models
{
   public class VraagModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(DagModel))]
        public int DagId { get; set; }
        public DateTime Datum { get; set; }

        [MaxLength(255)]
        public string Vraag { get; set; }
    }
}
