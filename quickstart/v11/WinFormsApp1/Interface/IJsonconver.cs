using Core.Entities.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Interface
{
    internal interface IJsonconver
    {
        public StringContent Jsonconver(object ob);
    }
}
