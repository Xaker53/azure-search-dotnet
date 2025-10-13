using Core.Entities.MappingProfiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Interface;

namespace WinFormsApp1.Tools
{
    internal class ConvertToJson : IJsonconver
    {
        public StringContent Jsonconver(object ob)
        {
            return new StringContent(JsonConvert.SerializeObject(ob),
              Encoding.UTF8,
              "application/json");
        }
    }
}
