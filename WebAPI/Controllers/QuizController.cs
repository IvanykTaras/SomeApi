using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [Route("/api/v1/quizzes")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        public readonly IQuizUserService _service;

        public QuizController(IQuizUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<QuizDto> FindById(int id)
        {
            var find = _service.FindQuizById(id);

            if (find is null)
            {
                return NotFound();
            }

            return QuizDto.of(find);
        }

        [HttpGet]
        public IEnumerable<QuizDto> FindAll()
        {
            var allQuizes = new List<QuizDto>();

            foreach (var item in _service.FindAllQuizzes())
            {
                allQuizes.Add(QuizDto.of(item));
            }

            return allQuizes;
        }

        [HttpGet]
        [Route("{userId}/{quizId}")]
        public int FindAnswer(int userId, int quizId)
        {
            return _service.CountCorrectAnswersForQuizFilledByUser(quizId,userId);
        }

        [HttpPost]
        [Route("{quizId}/items/{itemId}")]
        public void SaveAnswer([FromBody] QuizItemAnswerDto dto, [FromRoute] int quizId, [FromRoute] int itemId)
        {
             _service.SaveUserAnswerForQuiz(quizId, dto.UserId, itemId, dto.Answer);   
        }


    }
}
