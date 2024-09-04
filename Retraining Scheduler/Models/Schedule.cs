using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retraining_Scheduler.Models
{
    public class Schedule
    {
        public List<Track> Tracks { get; set; }

        public Schedule(int numberOfTracks)
        {
            Tracks = new List<Track>();
            for (int i = 0; i < numberOfTracks; i++)
            {
                Tracks.Add(new Track());
            }
        }
    }
}
