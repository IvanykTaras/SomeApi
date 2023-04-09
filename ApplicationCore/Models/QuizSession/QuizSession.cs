using ApplicationCore.Interfaces.Repository;

namespace ApplicationCore.Models;

public class QuizSession: IIdentity<int>
{
    public int UserId { get; init; }
    
    public int QuizId { get; init; }
    
    public DateTime StartTime { get; init; }
    
    public DateTime EndTime { get; set; }
    
    public DateTime RegisterTime { get; set; }
    
    public TimeSpan MaxDuration { get; init; }
    public int Id { get; set; }

    public IEnumerable<QuizItemAnswer> Answers
    {
        get
        {
            return _answers.AsEnumerable();
        }
    }

    private ISet<QuizItemAnswer> _answers = new HashSet<QuizItemAnswer>();
    

}