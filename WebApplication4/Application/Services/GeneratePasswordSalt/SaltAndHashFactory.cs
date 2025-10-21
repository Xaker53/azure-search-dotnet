using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.Interface.Auth;

namespace Application.Services.GeneratePasswordSalt
{
    public class SaltAndHashFactory : ISaltAndHashFactory
    {
        private readonly IEnumerable<IStrategyMarker> _strategies;

        public SaltAndHashFactory(IEnumerable<IStrategyMarker> strategies)
        {
            _strategies = strategies;
        }

        public T GetStrategy<T>() where T : IStrategyMarker
        {
            var strategy = _strategies.OfType<T>().FirstOrDefault();
            if (strategy == null)
            {
                throw new InvalidOperationException($"Strategy of type {typeof(T).Name} not found");
            }
            return strategy;
        }
    }
}
