using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeterSpellen.Models
{
    public class AntwoordModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(OptieModel))]
        public int OptieId { get; set; }
        [MaxLength(255)]
        public OptieModel Optie { get; set; }
        public int UserId { get; set; }
        public bool Juist { get; set; }
        public bool Antwoord { get; set; }
    }
}
