namespace LibClass.Commom.Enum
{
    public static class EnumManager
    {
        private const string SEPARATION_STRING = " - ";

        /// <summary>
        /// Load Description Monitored Account
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string LoadDescriptionMonitoredAccount(short code)
        {
            string description = string.Empty;

            if (code > 0)
            {
                MonitoredAccount objMonitoredAccount = (MonitoredAccount)code;
                description = objMonitoredAccount.Description();
                description = description.Substring(description.IndexOf(SEPARATION_STRING) + 3);
            }

            return description;
        }

        /// <summary>
        /// Load Description Event
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string LoadDescriptionEvent(short code)
        {
            string description = string.Empty;

            if (code > 0)
            {
                Event objEvent = (Event)code;
                description = objEvent.Description();
                description = description.Substring(description.IndexOf(SEPARATION_STRING) + 3);
            }

            return description;
        }

        /// <summary>
        /// Load Description Partition
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string LoadDescriptionPartition(short code)
        {
            string description = string.Empty;

            if (code > 0)
            {
                Partition objPartition = (Partition)code;
                description = objPartition.Description();
                description = description.Substring(description.IndexOf(SEPARATION_STRING) + 3);
            }

            return description;
        }

        /// <summary>
        /// Load Description Zone
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string LoadDescriptionZone(short code)
        {
            string description = string.Empty;

            if (code > 0)
            {
                Zone objPartition = (Zone)code;
                description = objPartition.Description();
                description = description.Substring(description.IndexOf(SEPARATION_STRING) + 3);
            }

            return description;
        }

        /// <summary>
        /// Load Description User
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string LoadDescriptionUser(short code)
        {
            string description = string.Empty;

            if (code > 0)
            {
                User objPartition = (User)code;
                description = objPartition.Description();
                description = description.Substring(description.IndexOf(SEPARATION_STRING) + 3);
            }

            return description;
        }
    }
}