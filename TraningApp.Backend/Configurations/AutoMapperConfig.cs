using AutoMapper;
using TraningApp.Backend.Models;
using TraningApp.Backend.Models.DTOs;
using TraningApp.Backend.Models.DTOs.SessionDTOs;
using TraningTrakerApp.Backend.Models;

namespace TraningApp.Backend.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Session, CreateSessionDTO>().ReverseMap();
        CreateMap<Session, SessionDTO>().ReverseMap();
        CreateMap<Session, SessionDetailsDTO>().ReverseMap();


        CreateMap<Exercise, CreateExerciseDTO>().ReverseMap();




    }
}