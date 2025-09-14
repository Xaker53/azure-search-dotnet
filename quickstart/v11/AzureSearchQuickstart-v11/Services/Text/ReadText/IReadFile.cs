using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSearchQuickstart_v11.Services.Text.ReadText
{
    public interface IReadFile
    {
        string GetText(string FilePath);
    }
}
