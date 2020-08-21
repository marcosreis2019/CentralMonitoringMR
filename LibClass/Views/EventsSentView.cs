using System;

namespace LibClass.Views
{
    /// <summary>
    /// Class for viewing sent events.
    /// </summary>
    public class EventsSentView
    {
        public DateTime Date { get; set; }

        public string Account { get; set; }

        public string Event { get; set; }

        public string Partition { get; set; }

        public string Zone { get; set; }

        public string User { get; set; }
    }
}