using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.MappingProfiles;
using Core.Models;
public class GlobalState 
{ 
    public string JwtToken { get; set; }
    public UserRequest CurrentUser { get; set; } 
}