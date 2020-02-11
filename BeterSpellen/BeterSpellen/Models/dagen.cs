using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeterSpellen.Models
{
    class dagen
    {
        [PrimaryKey, AutoIncrement]
        public int dag_id { get; set; }
        public DateTime datum { get; set; }
    }
}
