using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentPlanner.Models
{
    public class SacramentMeeting
    {
        public int ID { get; set; }
        [Display(Name = "Meeting Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? MeetingDate { get; set; }
        [Display(Name = "Special Note")]
        public string SpecialNote { get; set; }
        [Display(Name = "Conducting")]
        public string ConductorName { get; set; }
        [Display(Name = "Opening Hymn #")]
        [Range(1, 341)]
        public int OpeningSongNumber { get; set; }
        [Display(Name = "Opening Hymn")]
        public string OpeningSongTitle { get; set; }
        [Display(Name = "Opening Prayer")]
        public string OpeningPrayerName { get; set; }
        [Range(1, 341)]
        [Display(Name = "Sacrament Hymn #")]
        public int SacramentSongNumber { get; set; }
        [Display(Name = "Sacrament Hymn")]
        public string SacramentSongTitle { get; set; }
        public ICollection<SpeakingAssignment> Speakers { get; set; }
        [Range(0, 341)]
        [Display(Name = "Rest Hymn #")]
        public int? IntermediateSongNumber { get; set; }
        [Display(Name = "Rest Hymn")]
        public string IntermediateSongTitle { get; set; }
        [Range(1, 341)]
        [Display(Name = "Closing Hymn #")]
        public int ClosingSongNumber { get; set; }
        [Display(Name = "Closing Hymn")]
        public string ClosingSongTitle { get; set; }
        [Display(Name = "Closing Prayer")]
        public string ClosingPrayerName { get; set; }

    }
}
