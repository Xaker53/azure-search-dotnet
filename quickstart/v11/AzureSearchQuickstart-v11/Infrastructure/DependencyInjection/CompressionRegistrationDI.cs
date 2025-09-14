using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureSearchQuickstart_v11.Services.Compression;
using Microsoft.Extensions.DependencyInjection;

namespace AzureSearchQuickstart_v11.Infrastructure.DependencyInjection
{
    public class CompressionRegistrationDI
    {
        private readonly ServiceProvider provider;

        private static readonly Lazy<CompressionRegistrationDI> _instance = new(()=> new CompressionRegistrationDI());

        public static CompressionRegistrationDI Instance => _instance.Value;


        private CompressionRegistrationDI()
        {
            var services = new ServiceCollection();
            services.AddKeyedTransient<IWordCompression, PopularWords>("PopularWords");
            services.AddKeyedTransient<IWordCompression, Services.Compression.Rake>("Rake");
            services.AddKeyedTransient<IWordCompression, CharacterIndexing>("CharacterIndexing");

            provider = services.BuildServiceProvider();
        }


        public IWordCompression TryGet(string Key) => provider.GetRequiredKeyedService<IWordCompression>(Key);

    }
}
