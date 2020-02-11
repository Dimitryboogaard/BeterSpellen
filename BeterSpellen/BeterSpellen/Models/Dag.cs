using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeterSpellen.Models
{
    public class DagModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime datum { get; set; }
    }
}