using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

public class GrpTest : PageModel
{
    private readonly PdfGenerator.PdfGeneratorClient _client;

    public GrpTest(PdfGenerator.PdfGeneratorClient client)
    {
        _client = client;
    }

    [BindProperty] 
    public double Value { get; set; } = 0;
    
    public IActionResult OnGet()
    {
        Value = _client.Convert(new Input() {Value = 5}).Value;
        return Page();
    }
}