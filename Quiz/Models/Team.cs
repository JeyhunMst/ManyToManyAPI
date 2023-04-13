namespace Quiz.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<PlayerTeam> PlayerTeams { get; set; }
    }
}
