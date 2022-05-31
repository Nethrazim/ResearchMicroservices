using AutoMapper;
using SO.API.Teachers.Model.Requests;
using SO.BusinessLayer.Teachers.Entities.DTOs;

namespace SO.API.Teachers.Model.Profiles
{
    public class TeachersProfile : Profile
    {
        public TeachersProfile()
        {
            CreateMap<CreateTeacherRequest, TeacherDTO>();
        }
    }
}
