using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Words.Saving;
using Spire.Doc;

namespace AzureSearchQuickstart_v11.Services.Text.ReadText
{
    class ReadDocx : IReadFile
    {
        private Document document;
        public string GetText(string FilePath)
        {
            document = new();
            document.LoadText(FilePath);
            return this.document.GetText().Remove(0, 69).Replace("\r", "");
        }
    }
}
