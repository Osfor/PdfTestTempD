using PdfImageRenderer;

AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

Console.WriteLine("Task started");

using var fs = new FileStream("test.pdf", FileMode.Open);

foreach (var imageBytes in Renderer.RenderPdfToPageImages(fs, ImageType.Png, 1.6f))
{
    Console.WriteLine(Convert.ToBase64String(imageBytes).Substring(0, 50) + "...");
}

Console.WriteLine("Task completed");


static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
{
    Console.WriteLine(e.ExceptionObject.ToString());
    Environment.Exit(1);
}