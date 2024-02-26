using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Spire.Doc;

namespace AzureSearchQuickstart_v11
{
    public class GetFileText
    {
        private string pageText { get; set;} = "";
        private PopularWords PopularWords;
        
        public GetFileText(string filePath, string extension, string Method="Rake")
        {

            switch (extension)
            {
                case ".txt":
                    this.pageText = File.ReadAllText(filePath).Replace("\n", "").Replace("\r", " ");
                    //Console.WriteLine(pageText);
                    break;
                case ".pdf":
                    this.pageText = ExtractTextFromPdf(filePath);
                    //Console.WriteLine($":{pageText}");
                    break;
                case ".docx":
                    Document document = new Document();
                    document.LoadText(filePath);
                    this.pageText = document.GetText().Remove(0, 69).Replace("\r", "");
                    break;
                case ".doc":
                    Document doc = new Document();
                    doc.LoadFromFile(filePath);
                    this.pageText = doc.GetText().Remove(0, 69).Replace("\r", "");
                    break;
            }

            if (pageText.Length > 27090)
            {
                if (Method == "Rake")
                {
                    var rake = new Rake.Rake();
                    var result = rake.Run(this.pageText.ToLower());
                    this.pageText = string.Join(" ", result.Keys);
                }else
                {
                    PopularWords = new(this.pageText);
                    pageText = PopularWords.Result;
                }
                
            }
            
        }

        private string ExtractTextFromPdf(string filePath)
        {
            string pageText = "";

            using (PdfReader pdfReader = new PdfReader(filePath))
            {
                using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
                {
                    int numPages = pdfDocument.GetNumberOfPages();
                    for (int pageNum = 1; pageNum <= numPages; pageNum++)
                    {
                        SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        pageText += PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNum), strategy);
                    }
                }
            }

            return pageText;
        }


        public string getPageText()
        {
            return this.pageText;
        }
    }
}
