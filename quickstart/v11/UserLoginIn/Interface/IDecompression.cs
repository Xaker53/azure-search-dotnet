using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginIn.Interface
{
    public interface IDecompression
    {
        public Task<string> DecompressionFile(string stringJson);
    }
}
