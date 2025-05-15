using System;
using System.IO;
using DtronixPdf;
using DtronixPdf.ImageSharp;
using SixLabors.ImageSharp;

using Microsoft.Extensions.Hosting;


//требуется заставить работать на Linux

Console.WriteLine("Task started");

AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;


var b = Host.CreateApplicationBuilder(args);
var app = b.Build();

////////////////////////////////////////

const string TestPdf = "test.pdf";


var document = PdfDocument.Load(TestPdf, null);

using var page = document.GetPage(0);

float scale = 1.6f;
using var result = page.Render(scale);
using var stream = new MemoryStream();
result.GetImage().SaveAsPng(stream);

Console.WriteLine(Convert.ToBase64String(stream.ToArray()));

document.Dispose();

Console.WriteLine($"Rendering Complete");


////////////////////////////////////////

Console.WriteLine("Task completed");

app.Run();

static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
{
    Console.WriteLine(e.ExceptionObject.ToString());
    Environment.Exit(1);
}