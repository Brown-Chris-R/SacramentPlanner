using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class SacramentMeeting
    {
        public int ID { get; set; }
        public DateTime MeetingDate { get; set; }
        public string SpecialNote { get; set; }
        public string ConductorName { get; set; }
        public int OpeningSongNumber { get; set; }
        public string OpeningSongTitle { get; set; }
        public string OpeningPrayerName { get; set; }
        public int SacramentSongNumber { get; set; }
        public string SacramentSongTitle { get; set; }
        public ICollection<SpeakingAssignment> Speakers { get; set; }
        public int IntermediateSongNumber { get; set; }
        public string IntermediateSongTitle { get; set; }
        public int ClosingSongNumber { get; set; }
        public string ClosingSongTitle { get; set; }
        public string ClosingPrayerName { get; set; }

    }
}
