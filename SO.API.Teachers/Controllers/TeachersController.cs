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
    [Route("[controller]")]
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
    }
}
