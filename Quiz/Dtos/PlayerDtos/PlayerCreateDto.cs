using FluentValidation;
using Quiz.Models;

namespace Quiz.Dtos.PlayerDtos
{
    public class PlayerCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int ExperienceTime { get; set; }
        public List<int> TeamIds { get; set; }
        

    }
    public class PlayerCreateDtoValidator : AbstractValidator<PlayerCreateDto> 
    {
        public PlayerCreateDtoValidator() 
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("Bos ola bilmez!")
                .MaximumLength(30).WithMessage("30 dan boyuk ola bilmez!");
            RuleFor(p => p.Surname)
                .NotNull().WithMessage("Bos ola bilmez!")
                .MaximumLength(30).WithMessage("30 dan boyuk ola bilmez!");
            RuleFor(p => p.Age)
                .NotNull().WithMessage("Bos ola bilmez!")
                .GreaterThanOrEqualTo(18).WithMessage("Idmanci minimum 18 yasinda olmalidir!");
            RuleFor(p => p.ExperienceTime)
                .NotNull().WithMessage("Bos ola bilmez!")
                .GreaterThanOrEqualTo(0).WithMessage("Tecrube 0 ilden asagi ola bilmez!");
        }
    }
}
