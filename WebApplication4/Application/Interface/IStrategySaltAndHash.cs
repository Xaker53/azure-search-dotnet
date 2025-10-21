using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IStrategySaltAndHash
    {
        public string Generate(string password, string salt);
    }
}
