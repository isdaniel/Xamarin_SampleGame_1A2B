using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace GameModel
{
    [Table("Score")]
    public class Score
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int CountTime { get; set; }
    }
}
