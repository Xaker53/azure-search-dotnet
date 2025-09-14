using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureSearchQuickstart_v11.Services.Text.ReadText;
using Microsoft.Extensions.DependencyInjection;

namespace AzureSearchQuickstart_v11.Infrastructure.DependencyInjection
{
    class GetTextFromFileDI
    {
        private IServiceProvider serviceProvider;
        private static readonly Lazy<GetTextFromFileDI> getTextFromFile = new(()=> new GetTextFromFileDI());

        public static GetTextFromFileDI Instance => getTextFromFile.Value;
        private GetTextFromFileDI()
        {
            var services = new ServiceCollection();
            services.AddKeyedSingleton<IReadFile, ReadTxt> (".txt");
            services.AddKeyedTransient<IReadFile, ReadPdf>(".pdf");
            services.AddKeyedTransient<IReadFile, ReadDocx>(".docx");
            services.AddKeyedTransient<IReadFile, ReadDoc>(".doc");

            serviceProvider = services.BuildServiceProvider();
        }

        public IReadFile GetRead(string Key) => serviceProvider.GetRequiredKeyedService<IReadFile>(Key);
    }
}
