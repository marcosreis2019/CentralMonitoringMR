using System;

namespace LibClass.Views
{
    /// <summary>
    /// Class for viewing received events.
    /// </summary>
    public class EventsReceivedView
    {
        public DateTime Date { get; set; }

        public short Panel { get; set; }

        public int Account { get; set; }

        public short Event { get; set; }

        public string Description { get; set; }

        public byte Partition { get; set; }

        public byte Zone { get; set; }

        public byte User { get; set; }
    }
}