using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureSearchQuickstart_v11.Services.Compression;
using Microsoft.Extensions.DependencyInjection;

namespace AzureSearchQuickstart_v11.Infrastructure
{
    public class CompressionRegistrationDI
    {
        private readonly ServiceProvider provider;

        private static readonly Lazy<CompressionRegistrationDI> _instance = new(()=> new CompressionRegistrationDI());

        public static CompressionRegistrationDI Instance => _instance.Value;


        private CompressionRegistrationDI()
        {
            var services = new ServiceCollection();
            services.AddKeyedSingleton<IWordCompression, PopularWords>("PopularWords");
            services.AddKeyedSingleton<IWordCompression, Services.Compression.Rake>("Rake");
            services.AddKeyedSingleton<IWordCompression, CharacterIndexing>("CharacterIndexing");

            this.provider = services.BuildServiceProvider();
        }


        public IWordCompression TryGet(string Key) => this.provider.GetRequiredKeyedService<IWordCompression>(Key);

    }
}
