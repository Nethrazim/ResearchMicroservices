using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SO.API.Institution.Model.Requests;
using SO.API.Institution.Model.Responses;
using SO.BusinessLayer.DataReference.Users;
using SO.BusinessLayer.Institution.Entities.DTOs;
using SO.BusinessLayer.Institution.Services;

namespace SO.API.Institution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class InstitutionController : ControllerBase
    {
        private readonly ILogger<InstitutionController> _logger;
        private IInstitutionService InstitutionService { get; set; }
        private IMapper Mapper;

        public InstitutionController(IInstitutionService institutionService, IMapper mapper, ILogger<InstitutionController> logger)
        {
            _logger = logger;
            Mapper = mapper;
            InstitutionService = institutionService;
        }


        [HttpPost]
        [Route("institution/create")]
        [Authorize(Roles = "Admin")]
        public async Task<CreateInstitutionResponse> Create(CreateInstitutionRequest request)
        {
            CreateInstitutionResponse response = new CreateInstitutionResponse();
            response.Entity = await InstitutionService.CreateInstitutionAsync(request.Name, request.AdminId);
            return response;
        }

        [HttpPost]
        [Route("institution/getByAdminId")]
        [Authorize(Roles = "Admin")]
        public async Task<GetInstitutionByAdminIdResponse> GetByAdminId(GetInstitutionByAdminIdRequest request)
        {
            GetInstitutionByAdminIdResponse response = new GetInstitutionByAdminIdResponse();
            response.Entity = await InstitutionService.GetByAdminId(request.AdminId);
            return response;
            
        }


        [HttpDelete]
        [Route("institution/delete")]
        [Authorize(Roles = "Admin")]
        public async Task<DeleteInstitutionResponse> MarkInstitutionAsInactive(DeleteInstitutionRequest request)
        {
            DeleteInstitutionResponse response = new DeleteInstitutionResponse()
            {
                Value = await InstitutionService.DeleteAsync(request.InstitutionId),
                Message = "Institution has been deleted"
            };

            return response;
        }
    }
}
