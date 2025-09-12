using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureSearchQuickstart_v11
{
    public class CharacterIndexing: IWordCompression
    {
        private Dictionary<string, List<int>> SaveLetter;
        private string JsonText;
        private int Position = 0;

        public void Compression(string _Text)
        {
            SaveLetter = new();
            SaveLetter["Text_size"] = new List<int> { _Text.Length };

            foreach (char Text in _Text)
            {
                string value = Text.ToString();

                if (!SaveLetter.ContainsKey(value))
                {
                    SaveLetter[value] = new List<int>();
                }

                SaveLetter[value].Add(this.Position);
                this.Position++;
            }
        }

        public string OutText() => JsonText = JsonSerializer.Serialize(this.SaveLetter);
    }
}
