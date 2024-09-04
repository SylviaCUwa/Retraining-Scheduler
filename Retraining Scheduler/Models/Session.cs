using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retraining_Scheduler.Models
{
    public class Session
    {
        public string Name { get; set; }
        public int Duration { get; set; } 
        public bool IsLightning => Duration == 5;
    }
}
