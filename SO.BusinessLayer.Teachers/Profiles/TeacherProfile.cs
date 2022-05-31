using AutoMapper;
using SO.BusinessLayer.Teachers.Entities.DTOs;
using SO.DataLayer.Teachers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SO.BusinessLayer.Teachers.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherDTO, Teacher>().ReverseMap();
        }
    }
}
