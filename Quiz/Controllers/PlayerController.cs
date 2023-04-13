using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Data.DAL;
using Quiz.Dtos.PlayerDtos;
using Quiz.Models;

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PlayerController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(PlayerCreateDto createDto) 
        {
            Player newPlayer = new() 
            {
                Name=createDto.Name,
                Surname=createDto.Surname,
                Age=createDto.Age,
                ExperienceTime=createDto.ExperienceTime
            };
            List<PlayerTeam> teams = new List<PlayerTeam>();
            foreach (var addedTeam in createDto.TeamIds) 
            {
                var team = await _appDbContext.Teams.FirstOrDefaultAsync(t => t.Id == addedTeam);
                if(team==null) return StatusCode(404);
                PlayerTeam playerTeam = new();
                playerTeam.TeamId=team.Id;
                playerTeam.PlayerId = newPlayer.Id;
                _appDbContext.PlayerTeams.Add(playerTeam);
                teams.Add(playerTeam);
            }
            newPlayer.PlayerTeams=teams;
            _appDbContext.Players.Add(newPlayer);
            _appDbContext.SaveChanges();
            return StatusCode(201);
        }
    }
}
