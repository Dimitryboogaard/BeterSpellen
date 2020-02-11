using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BeterSpellen.Models
{
   public class VraagModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(DagModel))]
        public int DagId { get; set; }
        
        public virtual DagModel Dag { get; set; }
        [MaxLength(255)]
        public string Vraag { get; set; }
    }
}
