// See https://aka.ms/new-console-template for more information

using ConsoleGRPCClient;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:5000");
var client = new PdfGenerator.PdfGeneratorClient(channel);
var output = client.Convert(new Input() {Value = 10});
Console.WriteLine(output.Value);
var pdf = client.Generate(new HtmlDocumentRequest() {Content = "<p>Hello from HTML</>",Name = "Certyfikat"});
pdf.Content.WriteTo(new FileStream("c:\\data\\aa.pdf", FileMode.Create, access: FileAccess.Write));

