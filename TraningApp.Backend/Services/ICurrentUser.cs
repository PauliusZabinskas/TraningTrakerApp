using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraningApp.Backend.Models;

namespace Services
{
    public interface ICurrentUser
    {
        int? GetUser(); 
    }
}