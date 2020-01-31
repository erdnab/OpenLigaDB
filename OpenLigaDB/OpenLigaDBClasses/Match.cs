using System;
using System.Collections.Generic;

namespace OpenLigaDBClasses
{
    public class Match
    {
        public List<Goal> Goals { get; set; }
        public Group Group { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public Location Location { get; set; }
        public DateTime MatchDateTime { get; set; }
        public int MatchID { get; set; }
        public bool MatchIsFinished { get; set; }
        public List<MatchResult> MatchResults { get; set; }
        public int? NumberOfViewers { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
    }
}