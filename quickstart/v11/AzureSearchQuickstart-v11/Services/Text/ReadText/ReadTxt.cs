using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSearchQuickstart_v11.Services.Text.ReadText
{
    class ReadTxt : IReadFile
    {
        public string GetText(string FilePath)
        {
            return File.ReadAllText(FilePath).Replace("\n", "").Replace("\r", " ");
        }
    }
}
