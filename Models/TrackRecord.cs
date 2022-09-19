using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab1_var5.Models
{
    [Table(name:"TrackRecordPlayer")]
    [Keyless]
    public class TrackRecord
    {
        public String playerid { get; set; }
        public String? season { get; set; }
        public String? team { get; set; }
    }
}
