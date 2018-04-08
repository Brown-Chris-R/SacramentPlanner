using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class SpeakingAssignment
    {
        public int ID { get; set; }
        public int SacramentMeetingID { get; set; }
        public DateTime AssignedOnDate { get; set; }
        public string SpeakerName { get; set; }
        public string AssignedTopic { get; set; }

        public SacramentMeeting SacramentMeeting { get; set; }
    }
}
