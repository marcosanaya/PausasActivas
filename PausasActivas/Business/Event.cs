using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PausasActivas.Business
{
    public enum EventTypePause
    {
        PauseStart,
        PauseEnd
    }

    [Serializable]
    public class Event
    {
        public Guid IDEvent { get; set; }
        public EventTypePause Type { get; set; }
        public DateTime OriginEvent { get; set; }
        public DateTime NextTime { get; set; }
        public List<int>? Postponeds { get; set; }
    }
}
