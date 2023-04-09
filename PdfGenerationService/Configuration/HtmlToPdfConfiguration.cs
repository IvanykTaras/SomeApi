using DinkToPdf;

namespace PdfGenerationService.Configuration;

public class HtmlToPdfConfiguration
{
    public GlobalSettings GlobalSettings { get;  } = new()
    {
        ColorMode = ColorMode.Color,
        Orientation = Orientation.Portrait,
        PaperSize = PaperKind.A4,
        Margins = new MarginSettings {Top = 10},
    };

    public ObjectSettings ObjectSettings { get; } =  new()
    {
        PagesCount = true,
        WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =  Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
        HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
        FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
    };
}