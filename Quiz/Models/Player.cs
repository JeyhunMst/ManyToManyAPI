namespace Quiz.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public int ExperienceTime { get; set; }
        public List<PlayerTeam> PlayerTeams { get; set; }
        
    }
}
