using Retraining_Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retraining_Scheduler.Services
{
    public class Scheduler
    {
        private const int MorningSessionEnd = 12 * 60; // Noon in minutes
        private const int AfternoonSessionEnd = 16 * 60; // 4 PM in minutes

        public Schedule CreateSchedule(List<Session> sessions)
        {
            // Initialize the schedule with a fixed number of tracks (e.g., 2)
            var schedule = new Schedule(2);

            // Split sessions into tracks, morning and afternoon sessions
            AssignSessionsToTracks(sessions, schedule);

            return schedule;
        }

        private void AssignSessionsToTracks(List<Session> sessions, Schedule schedule)
        {
            foreach (var session in sessions)
            {
                bool added = TryAddToTrack(session, schedule.Tracks);
                if (!added)
                {
                    // Create a new track if the session doesn't fit in existing tracks
                    var newTrack = new Track();
                    if (CanFitInSession(newTrack.MorningSessions, session, 9 * 60, 12 * 60))
                    {
                        newTrack.MorningSessions.Add(session);
                    }
                    else
                    {
                        newTrack.AfternoonSessions.Add(session);
                    }
                    schedule.Tracks.Add(newTrack);
                }
            }
        }

        private bool TryAddToTrack(Session session, List<Track> tracks)
        {
            foreach (var track in tracks)
            {
                // Try to fit in the morning session
                if (CanFitInSession(track.MorningSessions, session, 9 * 60, 12 * 60))
                {
                    track.MorningSessions.Add(session);
                    return true;
                }

                // Try to fit in the afternoon session
                if (CanFitInSession(track.AfternoonSessions, session, 13 * 60, 16 * 60))
                {
                    track.AfternoonSessions.Add(session);
                    return true;
                }
            }

            return false; // Could not fit the session into any track
        }

        private bool CanFitInSession(List<Session> sessions, Session newSession, int startTime, int endTime)
        {
            int currentTime = startTime;
            foreach (var session in sessions)
            {
                currentTime += session.Duration;
            }

            return currentTime + newSession.Duration <= endTime;
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

}
