using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SO.API.Teachers.Model.Requests;
using SO.API.Teachers.Model.Responses;
using SO.BusinessLayer.Teachers.Entities.DTOs;
using SO.BusinessLayer.Teachers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SO.API.Teachers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly IMapper Mapper;
        private readonly ITeacherService TeachersService;
        private readonly ILogger<TeachersController> _logger;

        public TeachersController(ITeacherService teacherService,
            ILogger<TeachersController> logger,
            IMapper mapper)
        {
            TeachersService = teacherService;
            Mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [Route("teacher/create")]
        public async Task<CreateTeacherResponse> CreateTeacherAsync(CreateTeacherRequest request)
        {
            CreateTeacherResponse response = new CreateTeacherResponse()
            {
                Entity = await TeachersService.CreateAsync(Mapper.Map<TeacherDTO>(request))
            };

            return response;
        }

        [HttpPut]
        [Route("teacher/update")]
        public async Task<UpdateTeacherResponse> UpdateTeacherAsync(UpdateTeacherRequest request)
        {
            UpdateTeacherResponse response = new UpdateTeacherResponse()
            {
                Entity = await TeachersService.UpdateAsync(Mapper.Map<TeacherDTO>(request))
            };
            return response;
        }

        [HttpDelete]
        [Route("teacher/delete")]
        public async Task<DeleteTeacherResponse> DeleteTeacherAsync(DeleteTeacherRequest request)
        {
            DeleteTeacherResponse response = new DeleteTeacherResponse()
            {
                Value = await TeachersService.DeleteAsync(request.Id)
            };

            return response;
        }

        [HttpGet]
        [Route("teacher/getByInstitutionId")]
        public async Task<GetTeachersByInstitutionIdResponse> GetTeachersByInstitutionId([FromQuery] GetTeachersByInstitutionIdRequest request)
        {
            (List<TeacherDTO> teachers, int totalCount) = await TeachersService.GetTeachersByInstitutionId(request.PageIndex, request.PageSize, request.InstitutionId,request.FirstName, request.MiddleName,request.LastName);

            GetTeachersByInstitutionIdResponse response = new GetTeachersByInstitutionIdResponse()
            {
                Entity = teachers,
                TotalCount = totalCount
            };

            return response;
        }
            
    }
}
