using Microsoft.EntityFrameworkCore;

namespace lab1_var5.Models
{
    [Keyless]
    public class TrackRecord
    {
        public String playerid { get; set; }
        public String? season { get; set; }
        public String? team { get; set; }
    }
}
