namespace OpenLigaDBClasses
{
    public class Goal
    {
        public string Comment { get; set; }
        public int GoalGetterID { get; set; }
        public string GoalGetterName { get; set; }
        public int GoalID { get; set; }
        public bool IsOvertime { get; set; }
        public bool IsOwnGoal { get; set; }
        public int? MatchMinute { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
    }
}