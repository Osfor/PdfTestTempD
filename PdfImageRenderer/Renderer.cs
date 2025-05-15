using DtronixPdf;
using DtronixPdf.ImageSharp;
using SixLabors.ImageSharp;

namespace PdfImageRenderer;

public enum ImageType
{
    Jpeg,
    Png,
    Bmp,
    Gif,
    Webp
}
public static class Renderer
{
    public static IEnumerable<byte[]> RenderPdfToPageImages(Stream pdfFileData, ImageType imageType, float scale = 1.0f)
    {
        using var document = PdfDocument.Load(pdfFileData, null);

        for (var p = 0; p < document.Pages; p++)
        {
            using var page = document.GetPage(p);
            using var result = page.Render(scale);
            using var stream = new MemoryStream();
            switch (imageType)
            {
                case ImageType.Jpeg:
                    result.GetImage().SaveAsJpeg(stream);
                    break;
                case ImageType.Png:
                    result.GetImage().SaveAsPng(stream);
                    break;
                case ImageType.Bmp:
                    result.GetImage().SaveAsBmp(stream);
                    break;
                case ImageType.Gif:
                    result.GetImage().SaveAsGif(stream);
                    break;
                case ImageType.Webp:
                    result.GetImage().SaveAsWebp(stream);
                    break;
            }
            yield return stream.ToArray();
        }
    }


}
