using SO.BusinessLayer.Services;
using SO.BusinessLayer.Teachers.Entities.DTOs;
using SO.DataLayer.Teachers.Model;
using SO.DataLayer.Teachers.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace SO.BusinessLayer.Teachers.Services
{
    public class TeacherService : GenericService<ITeacherRepository, TeacherDTO, Teacher, int> , ITeacherService
    {
        public TeacherService(ITeacherRepository repository, IMapper mapper, IConfiguration configuration) : base(repository, configuration, mapper) { }
        public async Task<(List<TeacherDTO> teachers, int totalCount)> GetTeachersByInstitutionId(int pageIndex, int pageSize, int institutionId, string firstName, string middleName, string lastName)
        {
            (List<Teacher> teachers, int totalCount) = await Repository.GetTeachersByInstitutionId(pageIndex, pageSize, institutionId,firstName,middleName,lastName);

            return (Mapper.Map<List<TeacherDTO>>(teachers), totalCount);
        }
    }
}
