using System.ComponentModel.DataAnnotations.Schema;

namespace lab1_var5.Models
{
    [Table(name:"roster")]
    public class Player
    {
        public String playerid { get; set; }
        public int? jersey { get; set; }
        public String? fname { get; set; }
        public String? sname { get; set; }
        public String? position { get; set; }
        public String? birthday { get; set; }
        public int? weight { get; set; }
        public int? height { get; set; }
        public String? birthcity { get; set; }
        public String? birthstate { get; set; }
        public String? photo { get; set; }
    }
}
