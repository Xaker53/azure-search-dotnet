using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;


namespace AzureSearchQuickstart_v11.Services.Text.ReadText
{
    class ReadPdf : IReadFile
    {
        private string pageText = "";
        public string GetText(string FilePath)
        {
            return ExtractTextFromPdf(FilePath);
        }

        private string ExtractTextFromPdf(string filePath)
        {
            using (PdfReader pdfReader = new PdfReader(filePath))
            {
                using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
                {
                    int numPages = pdfDocument.GetNumberOfPages();
                    for (int pageNum = 1; pageNum <= numPages; pageNum++)
                    {
                        SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        this.pageText += PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNum), strategy);
                    }
                }
            }
            return this.pageText;
        }
    }
}
