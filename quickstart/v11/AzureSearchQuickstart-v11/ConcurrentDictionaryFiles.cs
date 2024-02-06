using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AzureSearch.Quickstart.Program;

namespace AzureSearchQuickstart_v11
{
    class ConcurrentDictionaryFiles
    {
        private ConcurrentDictionary<string, Data[]> myDictionary = new ConcurrentDictionary<string, Data[]>();
        public ConcurrentDictionaryFiles(string filesDirectory)
        {
            Parallel.ForEach(Directory.GetFileSystemEntries(filesDirectory), filePath =>
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        string extension = Path.GetExtension(filePath);

                        if (IsSupportedExtension(extension))
                        {
                            GetFileText FileText = new GetFileText(filePath, extension);
                            string pageText = FileText.getPageText();

                            Data[] dataInfo = new Data[]
                            {
                                new Data { FilePath = filePath, FileName = Path.GetFileName(filePath), FileText = pageText.Replace("\n", "") }
                            };

                            myDictionary.TryAdd(filePath, dataInfo);
                        }
                        else
                        {
                            var data = new Data[]
                            {
                        new Data { FilePath = filePath, FileName = Path.GetFileName(filePath), FileText = "" }
                            };

                            myDictionary.TryAdd(filePath, data);
                        }
                    }
                    else
                    {
                        ConcurrentDictionary<string, Data[]> subFile = Files(filePath);
                        foreach (var info in subFile)
                        {
                            myDictionary.TryAdd(info.Key, info.Value);
                        }
                    }

                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }

            });
        }

        private bool IsSupportedExtension(string extension)
        {
            string[] supportedExtensions = { ".pdf", ".docx", ".doc", ".txt" };

            return supportedExtensions.Contains(extension);
        }

        public ConcurrentDictionary<string, Data[]> Dictionary()
        {
            return this.myDictionary;
        }
    }
}
