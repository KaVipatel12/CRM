using PuppeteerSharp;
using PuppeteerSharp.Media;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CRM_Api.Helpers
{
    public class PDFConvertSettings
    {
        public bool AddHeader { get; set; }
        public string HeaderViewPath { get; set; } = string.Empty;
        public bool AddFooter { get; set; }
        public string FooterViewPath { get; set; } = string.Empty;
    }

    public class HtmlToPdfHelper
    {
        public async Task<string> GenerateHTMLToPDFAsync(string htmlTemplateText, string contentRootPath, PDFConvertSettings? pdfConvertSettings = null)
        {
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            // Launch browser
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                Args = new[] { "--no-sandbox", "--disable-setuid-sandbox" }
            });

            await using var page = await browser.NewPageAsync();

            // Set content
            await page.SetContentAsync(htmlTemplateText);

            // PDF Options
            var pdfOptions = new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true,
                MarginOptions = new MarginOptions
                {
                    Top = "10mm",
                    Bottom = "10mm",
                    Left = "10mm",
                    Right = "10mm"
                }
            };

            // Add Header/Footer if requested
            if (pdfConvertSettings != null)
            {
                pdfOptions.DisplayHeaderFooter = true;
                
                if (pdfConvertSettings.AddHeader && !string.IsNullOrEmpty(pdfConvertSettings.HeaderViewPath))
                {
                    string headerPath = Path.Combine(contentRootPath, pdfConvertSettings.HeaderViewPath);
                    if (File.Exists(headerPath))
                        pdfOptions.HeaderTemplate = await File.ReadAllTextAsync(headerPath);
                }

                if (pdfConvertSettings.AddFooter && !string.IsNullOrEmpty(pdfConvertSettings.FooterViewPath))
                {
                    string footerPath = Path.Combine(contentRootPath, pdfConvertSettings.FooterViewPath);
                    if (File.Exists(footerPath))
                        pdfOptions.FooterTemplate = await File.ReadAllTextAsync(footerPath);
                }
            }

            // Generate PDF
            var pdfData = await page.PdfDataAsync(pdfOptions);
            
            await browser.CloseAsync();

            return Convert.ToBase64String(pdfData);
        }
    }
}
