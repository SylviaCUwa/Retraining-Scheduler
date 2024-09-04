using Retraining_Scheduler.Models;
using Retraining_Scheduler.Services;

class Program
{
    static void Main(string[] args)
    {
        var sessions = new List<Session>
        {
            new Session { Name = "Organising Parents for Academy Improvements", Duration = 60 },
            new Session { Name = "Teaching Innovations in the Pipeline", Duration = 45 },
            new Session { Name = "Teacher Computer Hacks", Duration = 30 },
            new Session { Name = "Making Your Academy Beautiful", Duration = 45 },
            new Session { Name = "Academy Tech Field Repair", Duration = 45 },
            new Session { Name = "Sync Hard", Duration = 5 },  // Lightning talk
            new Session { Name = "Unusual Recruiting", Duration = 5 },  // Lightning talk
            new Session { Name = "Parent Teacher Conferences", Duration = 60 },
            new Session { Name = "Managing Your Dire Allowance", Duration = 45 },
            new Session { Name = "Customer Care", Duration = 30 },
            new Session { Name = "AIMs – 'Managing Up'", Duration = 30 },
            new Session { Name = "Dealing with Problem Teachers", Duration = 45 },
            new Session { Name = "Hiring the Right Cook", Duration = 60 },
            new Session { Name = "Government Policy Changes and New Globe", Duration = 60 },
            new Session { Name = "Adjusting to Relocation", Duration = 45 },
            new Session { Name = "Public Works in Your Community", Duration = 30 },
            new Session { Name = "Talking To Parents About Billing", Duration = 30 },
            new Session { Name = "So They Say You're a Devil Worshipper", Duration = 60 },
            new Session { Name = "Two-Streams or Not Two-Streams", Duration = 30 },
            new Session { Name = "Piped Water", Duration = 30 }
        };

        var scheduler = new Scheduler();
        var schedule = scheduler.CreateSchedule(sessions);

        // Print the schedule
        int trackNumber = 1;
        foreach (var track in schedule.Tracks)
        {
            Console.WriteLine($"Track {trackNumber++}:");
            PrintSessions("Morning", track.MorningSessions, 9 * 60);
            Console.WriteLine("12:00PM Lunch");
            PrintSessions("Afternoon", track.AfternoonSessions, 13 * 60);
            Console.WriteLine("04:00PM Sharing Session");
            Console.WriteLine();
        }
    }

    static void PrintSessions(string sessionType, List<Session> sessions, int startTime)
    {
        foreach (var session in sessions)
        {
            Console.WriteLine($"{FormatTime(startTime)} {session.Name} {session.Duration}min");
            startTime += session.Duration;
        }
    }

    static string FormatTime(int minutes)
    {
        int hours = minutes / 60;
        int mins = minutes % 60;
        string period = hours >= 12 ? "PM" : "AM";
        hours = hours > 12 ? hours - 12 : hours;
        return $"{hours:D2}:{mins:D2}{period}";
    }
}
