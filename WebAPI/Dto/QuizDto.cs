using ApplicationCore.Models;

namespace WebAPI.Dto
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string Title { get; set; }  
        public List<QuizItemDto> Items { get; set; }

        public static QuizDto of(Quiz quiz)
        {
            var quizDto = new QuizDto() {
                Id = quiz.Id,
                Title = quiz.Title,
                Items = new List<QuizItemDto>()
            };

            foreach (var item in quiz.Items)
            {
                quizDto.Items.Add(QuizItemDto.of(item));
            }

            return quizDto;
        }
    }
}
