using AutoMapper;
using TraineesManagementSystem.Repositary.Entites;
using TraineesManagementSystem.Services.Models;

namespace TraineesManagementSystem.Services
    
{
    public class AutoMapperConfiguration :Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<TraineeDetailsModel, TraineeDetails>();
        }
    }
}
