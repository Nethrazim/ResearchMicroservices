using SO.BusinessLayer.Services;
using SO.BusinessLayer.Teachers.Entities.DTOs;
using SO.DataLayer.Teachers.Model;
using SO.DataLayer.Teachers.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace SO.BusinessLayer.Teachers.Services
{
    public class TeacherService : GenericService<ITeacherRepository, TeacherDTO, Teacher, int> , ITeacherService
    {
        public TeacherService(ITeacherRepository repository, IMapper mapper, IConfiguration configuration) : base(repository, configuration, mapper) { }
    }
}
