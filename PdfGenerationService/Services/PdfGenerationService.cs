using DinkToPdf;
using DinkToPdf.Contracts;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using PdfGenerationService.Configuration;

namespace PdfGenerationService;

public class PdfGenerationService: PdfGenerator.PdfGeneratorBase
{
    private readonly IConverter _converter;
    private readonly HtmlToPdfConfiguration _configuration;

    public PdfGenerationService(IConverter converter, HtmlToPdfConfiguration configuration)
    {
        _converter = converter;
        _configuration = configuration;
    }

    public override async Task<PdfDocumentResponse> Generate(HtmlDocumentRequest request, ServerCallContext context)
    {
        int a = 5;
        _configuration.GlobalSettings.DocumentTitle = request.Name;
        _configuration.GlobalSettings.Out = "";                         //save to buffer
        _configuration.ObjectSettings.HtmlContent = request.Content;
        var  document = new HtmlToPdfDocument(){GlobalSettings = _configuration.GlobalSettings, Objects = { _configuration.ObjectSettings }};
        return new PdfDocumentResponse()
        {
            Content = ByteString.CopyFrom(_converter.Convert(document)),
            Created = Timestamp.FromDateTime(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc))
        };
    }
}