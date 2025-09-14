using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Doc;

namespace AzureSearchQuickstart_v11.Services.Text.ReadText
{
    class ReadDoc : IReadFile
    {
        private Document document;
        public string GetText(string FilePath)
        {
            document = new Document();
            document.LoadFromFile(FilePath);
            return document.GetText().Remove(0, 69).Replace("\r", "");
        }
    }
}
