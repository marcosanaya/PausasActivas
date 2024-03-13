using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PausasActivas.Business
{
    public class HistoryItem(int QItems)
    {
        private readonly int qItems = QItems;

        private List<Event>? PastNevents { get; set; } = [];

        public List<Event>? GetLastEvents()
        {
            throw new NotImplementedException();
            //return pastNevents;
        }

        private void ReadLastEvents()
        { throw new NotImplementedException();
        }

        private int WriteLastEvents()
        {
            throw new NotImplementedException();
        }
    }
}
