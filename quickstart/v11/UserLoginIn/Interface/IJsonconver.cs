using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLoginIn.Interface
{
    public interface IJsonconver
    {
        public StringContent Jsonconver<T>(T ob, string ContentType = "application/json");
    }
}
