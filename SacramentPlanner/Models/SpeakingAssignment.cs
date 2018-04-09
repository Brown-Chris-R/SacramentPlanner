using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class SpeakingAssignment
    {
        public int ID { get; set; }
        public int SacramentMeetingID { get; set; }
        [Display(Name = "Speaking Sequence #")]
        public int SpeakingSequence { get; set; }
        [Display(Name = "Date Assigned")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AssignedOnDate { get; set; }
        [Display(Name = "Speaker's Name")]
        [Required]
        public string SpeakerName { get; set; }
        [Display(Name = "Assigned Topic")]
        public string AssignedTopic { get; set; }

        public SacramentMeeting SacramentMeeting { get; set; }
    }
}
