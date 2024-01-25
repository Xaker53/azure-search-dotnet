using System;
using System.Collections.Generic;
using System.Text;

namespace AzureSearchQuickstart_v11
{
    class PopularWords
    {
        public static string Result(string text)
        {
            string result = "";
            var words = text.Split(new[] { ' ', '.', ',', '!', '?', '_', '-', '/', '=', '+', ':', ';'},StringSplitOptions.RemoveEmptyEntries);

           
            var wordDiction = new Dictionary<string, int>();

            foreach(var word in words)
            {
                string normalWord = word.ToLower();
                if (wordDiction.ContainsKey(normalWord))
                {
                    wordDiction[normalWord]++;
                }else
                {
                    wordDiction[normalWord] = 1;
                }
            }

            foreach(var word in wordDiction)
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
            return result;
        }
    }
}
