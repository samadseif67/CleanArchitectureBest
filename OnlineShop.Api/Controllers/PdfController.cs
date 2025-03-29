using PuppeteerSharp;
using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp.Media;

[ApiController]
[Route("api/[controller]/[action]")]
public class PdfController : ControllerBase
{
    [HttpPost]
   
    public async Task<IActionResult> ConvertHtmlToPdf([FromBody] string htmlContent)
    {

        var tempDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/temp");
        if (!Directory.Exists(tempDir))
        {
            Directory.CreateDirectory(tempDir);
        }


        var tempFilePath = Path.Combine("wwwroot/temp", "output.pdf");

        await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
        await using var page = await browser.NewPageAsync();
        await page.SetContentAsync(htmlContent);

        // ذخیره مستقیم در فایل
        await page.PdfAsync(tempFilePath, new PdfOptions
        {
            Format = PaperFormat.A4,
            PrintBackground = true
        });



        byte[] pdfBytes = await System.IO.File.ReadAllBytesAsync(tempFilePath);
        System.IO.File.Delete(tempFilePath);

        return File(pdfBytes, "application/pdf", "output.pdf");
    }
}