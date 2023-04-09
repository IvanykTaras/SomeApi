using ApplicationCore.Models;

namespace WebAPI.Dto
{
    public class QuizItemDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }


        public static QuizItemDto of(QuizItem quiz)
        {
            var quizeItemDto = new QuizItemDto() {
                Id = quiz.Id,
                Question = quiz.Question,
                Options = new List<string>(quiz.IncorrectAnswers)
            };

            quizeItemDto.Options.Add(quiz.CorrectAnswer);

            return quizeItemDto;
        }
    }
}
