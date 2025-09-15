using System;
using System.Collections.Generic;
using System.Text;

namespace AzureSearchQuickstart_v11.Services.Compression
{
    class PopularWords : IWordCompressionWithOutput
    {
        private string result = "";

        public string OutText() => result;

        public void Compression(string _Text)
        {
            var words = _Text.Split(new[] { ' ', '.', ',', '!', '?', '_', '-', '/', '=', '+', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var wordDiction = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string normalWord = word.ToLower();
                if (wordDiction.ContainsKey(normalWord))
                {
                    wordDiction[normalWord]++;
                }
                else
                {
                    wordDiction[normalWord] = 1;
                }
            }

            foreach (var word in wordDiction)
            {
                if (word.Value < 2)
                {
                    wordDiction.Remove(word.Key);
                }
                else
                {
                    result += $"{word.Key} ";
                }
            }

        }

        //public PopularWords(string text)
        //{
        //    var words = text.Split(new[] { ' ', '.', ',', '!', '?', '_', '-', '/', '=', '+', ':', ';'},StringSplitOptions.RemoveEmptyEntries);

        //    var wordDiction = new Dictionary<string, int>();

        //    foreach(var word in words)
        //    {
        //        string normalWord = word.ToLower();
        //        if (wordDiction.ContainsKey(normalWord))
        //        {
        //            wordDiction[normalWord]++;
        //        }else
        //        {
        //            wordDiction[normalWord] = 1;
        //        }
        //    }

        //    foreach(var word in wordDiction)
        //    {
        //        if (word.Value < 2)
        //        {
        //            wordDiction.Remove(word.Key);
        //        }
        //        else
        //        {
        //            result += $"{word.Key} ";
        //        }
        //    }

        //}
    }
}
