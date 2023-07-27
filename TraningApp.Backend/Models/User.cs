using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraningApp.Backend.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string? UserName { get; set;}
        public string? Password { get; set;}
        public int CurrentWeight { get; set; }
        public int CurrentHeightMeters { get; set; }
        public int age { get; set; }
        public int WeightGoal { get; set; }


    }
}