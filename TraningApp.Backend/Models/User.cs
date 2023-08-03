using Microsoft.AspNetCore.Identity;

namespace TraningApp.Backend.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; } 
        public string? UserName { get; set;} = "Default";
        public string? Password { get; set;} = "Default";
        public int CurrentWeight { get; set; } = 1;
        public int CurrentHeightMeters { get; set; } = 2;
        public int age { get; set; } = 29;
        public int WeightGoal { get; set; } = 2;


    }
}