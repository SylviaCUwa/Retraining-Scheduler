using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retraining_Scheduler.Models
{
    public class Track
    {
        public List<Session> MorningSessions { get; set; }
        public List<Session> AfternoonSessions { get; set; }

        public Track()
        {
            MorningSessions = new List<Session>();
            AfternoonSessions = new List<Session>();
        }
    }
}
