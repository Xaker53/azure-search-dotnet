using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Rake
{
    internal static class StopListHelper
    {
        public static HashSet<string> ParseFromPath(string? stopWordsPath)
        {
            var stopWords = new HashSet<string>(StringComparer.Ordinal);

            foreach (var line in string.IsNullOrWhiteSpace(stopWordsPath)
                ? ReadDefaultStopListLine()
                : File.ReadAllLines(stopWordsPath))
            {
                ReadOnlySpan<char> normalizedLine = line.AsSpan().Trim();

                if (normalizedLine.Length == 0 || normalizedLine[0] == '#') continue;

                var splitter = new StringSplitter(normalizedLine, ' ');

                while (splitter.TryGetNext(out var word))
                {
                    stopWords.Add(word.ToString());
                }
            }

            return stopWords;
        }

        private static IEnumerable<string> ReadDefaultStopListLine()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "AzureSearchQuickstart_v11.SmartStoplist3.txt";

            var stream = assembly.GetManifestResourceStream(resourceName);
            var reader = new StreamReader(stream);

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}