

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserLoginIn.Interface;

namespace UserLoginIn.Tools
{
    internal class Decompression : IDecompression
    {
        public Task<string> DecompressionFile (string stringJson)
        {
            var dict = JsonSerializer.Deserialize<Dictionary<string, List<int>>>(stringJson);
            if (dict == null || !dict.ContainsKey("Text_size")) throw new Exception("This string is null");

            int sizeArray = dict["Text_size"][0];
            dict.Remove("Text_size");
            var result = new char[sizeArray];

            foreach (var word in dict)
            {
                foreach (int pos in word.Value)
                {
                    result[pos] = word.Key[0];
                }
            }

            return Task.FromResult(new string (result));
        }
    }
}
