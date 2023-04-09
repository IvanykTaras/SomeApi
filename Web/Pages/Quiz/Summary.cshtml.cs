using System.Net.Mime;
using System.Text;
using ApplicationCore.Interfaces;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;

namespace Web.Pages;

public class Summary : PageModel
{   
    private readonly IQuizUserService _userService;
    private readonly PdfGenerator.PdfGeneratorClient _client;
    
    public int QuizId { get; set; }
    [BindProperty]
    public int CorrectAnswerCount { get; set; }
    public Summary(IQuizUserService userService, PdfGenerator.PdfGeneratorClient client)
    {
        _userService = userService;
        _client = client;
    }

    public void OnGet(int quizId, int userId)
    {
        CorrectAnswerCount = _userService.CountCorrectAnswersForQuizFilledByUser(quizId, userId);
    }

    public async Task<ActionResult> OnPostAsync()
    {
        string name = "Karol";
        var document = await _client.GenerateAsync(new HtmlDocumentRequest()
            {Content = $"<html><h1>Certyfikat dla  {name}</h1><p>Zdobył punktów {CorrectAnswerCount}</p></html>", Name = "Certificate"});
        var stream = new MemoryStream(document.Content.ToByteArray());  
        return new FileStreamResult(stream, new MediaTypeHeaderValue("application/pdf"))  
        {  
            
            FileDownloadName = "result.pdf"  
        };  
    }
}