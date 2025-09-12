using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSearchQuickstart_v11
{
    interface IWordCompression
    {
        void Compression(string _Text);
        string OutText();
    }
}
