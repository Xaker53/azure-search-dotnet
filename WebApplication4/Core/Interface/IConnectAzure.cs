using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.ModelAzure;

namespace Core.Interface
{
    public interface IConnectAzure
    {
        public List<Files> ConnectSearchFiles(string request = "", string userId = "");
        public Task DeleteAllByUserIdAsync(string userId);
    }
}
