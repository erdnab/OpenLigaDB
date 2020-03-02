namespace OpenLigaDBClasses
{
    public class Team
    {
        public int Draw { get; set; }
        public int Goals { get; set; }
        public int Lost { get; set; }
        public int Matches { get; set; }
        public int OpponentGoals { get; set; }
        public int Points { get; set; }
        public string ShortName { get; set; }
        public string TeamIconUrl { get; set; }

        private int _teamId;
        public int TeamId
        {
            get
            {
                if (_teamId <= 0)
                {
                    if (TeamInfoId > 0)
                        TeamId = TeamInfoId;
                }
                return _teamId;
            }
            set
            {
                _teamId = value;
            }
        }
        public int TeamInfoId { get; set; }
        public string TeamName { get; set; }
        public int Won { get; set; }
    }
}