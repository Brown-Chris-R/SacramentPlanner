using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacramentPlanner.Models;

namespace SacramentPlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any Sacrament Meetings.
            if (context.SacramentMeetings.Any())
            {
                return;   // DB has been seeded
            }

            var sacramentMeetings = new SacramentMeeting[]
            {
                new SacramentMeeting { MeetingDate = DateTime.Parse("2018-02-25"), ConductorName = "Bishop Smith", OpeningSongNumber = 2,
                    OpeningSongTitle = "The Spirit Of God", OpeningPrayerName = "Sister Porter", SacramentSongNumber = 184, SacramentSongTitle = "Upon the Cross of Calvary",
                    IntermediateSongNumber = 220, IntermediateSongTitle = "Lord, I Would Follow Thee", ClosingSongNumber = 239, ClosingSongTitle = "Choose The Right",
                    ClosingPrayerName = "Brother Allred" },
                new SacramentMeeting { MeetingDate = DateTime.Parse("2018-03-04"), SpecialNote = "Fast and Testimony", ConductorName = "Brother Johnson", OpeningSongNumber = 140,
                    OpeningSongTitle = "Did You Think to Pray?", OpeningPrayerName = "Sister White", SacramentSongNumber = 187, SacramentSongTitle = "God Loved Us, So He Sent His Son",
                    ClosingSongNumber = 81, ClosingSongTitle = "Press Forward Saints",
                    ClosingPrayerName = "Brother Brown" },
                new SacramentMeeting { MeetingDate = DateTime.Parse("2018-03-11"), ConductorName = "Brother Johnson", OpeningSongNumber = 136,
                    OpeningSongTitle = "I Know That My Redeemer Lives", OpeningPrayerName = "Sister Knapp", SacramentSongNumber = 182, SacramentSongTitle = "We'll Sing Al Hail To Jesus Name",
                    IntermediateSongNumber = 227, IntermediateSongTitle = "There is Sunshine in My Soul Today", ClosingSongNumber = 243, ClosingSongTitle = "Let Us All Press On",
                    ClosingPrayerName = "Brother Knapp" },
                new SacramentMeeting { MeetingDate = DateTime.Parse("2018-03-18"), SpecialNote = "High Council Speakers", ConductorName = "Brother Johnson",
                    OpeningSongNumber = 85, OpeningSongTitle = "How Firm a Foundation", OpeningPrayerName = "Brother Porter", SacramentSongNumber = 190,
                    SacramentSongTitle = "In Memory of the Crucified", IntermediateSongTitle = "Special Music: Piano solo by Sister Rogers",
                    ClosingSongNumber = 241, ClosingSongTitle = "Count Your Blessings", ClosingPrayerName = "Sister Merrell" },
                new SacramentMeeting { MeetingDate = DateTime.Parse("2018-03-25"), ConductorName = "Brother Miller", OpeningSongNumber = 2,
                    OpeningSongTitle = "Come, Listen to a Prophet's Voice", OpeningPrayerName = "Sister Johnsen", SacramentSongNumber = 193, SacramentSongTitle = "I Stand All Amazed",
                    IntermediateSongNumber = 247, IntermediateSongTitle = "We Love Thy House, O God", ClosingSongNumber = 223, ClosingSongTitle = "Have I Done Any Good?",
                    ClosingPrayerName = "Brother Laws" },
                new SacramentMeeting { MeetingDate = DateTime.Parse("2018-04-01"), SpecialNote="General Conference" }

            };

            foreach (SacramentMeeting s in sacramentMeetings)
            {
                context.SacramentMeetings.Add(s);
            }
            context.SaveChanges();

            var speakingAssignments = new SpeakingAssignment[]
            {
                new SpeakingAssignment {
                    SacramentMeetingID = sacramentMeetings.Single( s => s.MeetingDate == DateTime.Parse("2018-02-25")).ID, AssignedOnDate = DateTime.Parse("2018-02-10"), 
                    SpeakerName = "Sister Jones", AssignedTopic = "Repentance" },
                new SpeakingAssignment {
                    SacramentMeetingID = sacramentMeetings.Single( s => s.MeetingDate == DateTime.Parse("2018-02-25")).ID, AssignedOnDate = DateTime.Parse("2018-02-10"),
                    SpeakerName = "Brother Jones", AssignedTopic = "Forgiveness" },
                new SpeakingAssignment {
                    SacramentMeetingID = sacramentMeetings.Single( s => s.MeetingDate == DateTime.Parse("2018-03-11")).ID, AssignedOnDate = DateTime.Parse("2018-02-10"),
                    SpeakerName = "Sam Matthews", AssignedTopic = "Faith" },
                new SpeakingAssignment {
                    SacramentMeetingID = sacramentMeetings.Single( s => s.MeetingDate == DateTime.Parse("2018-03-11")).ID, AssignedOnDate = DateTime.Parse("2018-02-10"),
                    SpeakerName = "Hunter Knapp", AssignedTopic = "Hope" },
                new SpeakingAssignment {
                    SacramentMeetingID = sacramentMeetings.Single( s => s.MeetingDate == DateTime.Parse("2018-03-11")).ID, AssignedOnDate = DateTime.Parse("2018-02-10"),
                    SpeakerName = "Rose Howard", AssignedTopic = "Charity" },
                new SpeakingAssignment {
                    SacramentMeetingID = sacramentMeetings.Single( s => s.MeetingDate == DateTime.Parse("2018-03-18")).ID, AssignedOnDate = DateTime.Parse("2018-02-10"),
                    SpeakerName = "Brother Garner (Stake)", AssignedTopic = "Preparedness" },
                new SpeakingAssignment {
                    SacramentMeetingID = sacramentMeetings.Single( s => s.MeetingDate == DateTime.Parse("2018-03-18")).ID, AssignedOnDate = DateTime.Parse("2018-02-10"),
                    SpeakerName = "Brother Williams (Stake HC)", AssignedTopic = "Study the Scriptures" },
                new SpeakingAssignment {
                    SacramentMeetingID = sacramentMeetings.Single( s => s.MeetingDate == DateTime.Parse("2018-03-25")).ID, AssignedOnDate = DateTime.Parse("2018-02-10"),
                    SpeakerName = "Liz Clark", AssignedTopic = "Young Women Values" },
                new SpeakingAssignment {
                    SacramentMeetingID = sacramentMeetings.Single( s => s.MeetingDate == DateTime.Parse("2018-03-25")).ID, AssignedOnDate = DateTime.Parse("2018-02-10"),
                    SpeakerName = "Sister Kay", AssignedTopic = "Cheerful Giving" },
                new SpeakingAssignment {
                    SacramentMeetingID = sacramentMeetings.Single( s => s.MeetingDate == DateTime.Parse("2018-03-25")).ID, AssignedOnDate = DateTime.Parse("2018-02-10"),
                    SpeakerName = "Brother Kay", AssignedTopic = "Service" }
            };

            foreach (SpeakingAssignment a in speakingAssignments)
            {
                context.SpeakingAssignments.Add(a);
            }
            context.SaveChanges();
        }
    }
}
