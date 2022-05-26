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
        private IInstitutionService InstitutionService { get; }
        private IAddressService AddressService { get; }
        private IContactService ContactService { get; }

        private IMapper Mapper;

        public InstitutionController(IInstitutionService institutionService, 
            IAddressService addressService,
            IContactService contactService,
            IMapper mapper, ILogger<InstitutionController> logger)
        {
            _logger = logger;
            Mapper = mapper;
            InstitutionService = institutionService;
            AddressService = addressService;
            ContactService = contactService;
        }


        [HttpPost]
        [Route("institution/create")]
        [Authorize(Roles = "Admin")]
        public async Task<CreateInstitutionResponse> CreateAsync(CreateInstitutionRequest request)
        {
            CreateInstitutionResponse response = new CreateInstitutionResponse();
            response.Entity = await InstitutionService.CreateInstitutionAsync(request.Name, request.AdminId);
            return response;
        }

        [HttpGet]
        [Route("institution/getByAdminId")]
        [Authorize(Roles = "Admin")]
        public async Task<GetInstitutionByAdminIdResponse> GetInstitutionByAdminIdAsync([FromQuery] GetInstitutionByAdminIdRequest request)
        {
            GetInstitutionByAdminIdResponse response = new GetInstitutionByAdminIdResponse();
            response.Entity = await InstitutionService.GetByAdminId(request.AdminId);
            return response;

        }

        [HttpPut]
        [Route("institution/update")]
        [Authorize(Roles = "Admin")]
        public async Task<UpdateInstitutionResponse> UpdateAsync(UpdateInstitutionRequest request)
        {
            UpdateInstitutionResponse response = new UpdateInstitutionResponse()
            {
                Entity = await InstitutionService.UpdateAsync(request.InstitutionId, request.Name),
                Message = "Institution updated"
            };
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

        [HttpPost]
        [Route("address/create")]
        [Authorize(Roles = "Admin")]
        public async Task<CreateAddressResponse> CreateInstitutionAddress(CreateAddressRequest request)
        {
            CreateAddressResponse response = new CreateAddressResponse()
            {
                Entity = await AddressService.CreateAsync(Mapper.Map<AddressDTO>(request))
            };
            return response;
        }

        [HttpPut]
        [Route("address/update")]
        [Authorize(Roles = "Admin")]
        public async Task<UpdateAddressResponse> UpdateInstitutionAddress(UpdateAddressRequest request)
        {
            UpdateAddressResponse response = new UpdateAddressResponse()
            {
                Entity = await AddressService.UpdateAsync(Mapper.Map<AddressDTO>(request))
            };
            return response;
        }

        [HttpGet]
        [Route("address/getByInstitutionId")]
        [Authorize(Roles = "Admin")]
        public async Task<GetAddressByInstitutionIdResponse> GetAddressByInstitutionId([FromQuery] GetAddressByInstitutionIdRequest request)
        {
            GetAddressByInstitutionIdResponse response = new GetAddressByInstitutionIdResponse()
            {
                Entity = await AddressService.GetByInstitutionId(request.InstitutionId)
            };
            return response;
        }

        [HttpGet]
        [Route("contact/getByInstitutionId")]
        [Authorize(Roles = "Admin")]
        public async Task<GetContactByInstitutionIdResponse> GetContactByInstitutionId([FromQuery] GetContactByInstitutionIdRequest request)
        {
            GetContactByInstitutionIdResponse response = new GetContactByInstitutionIdResponse()
            {
                Entity = await ContactService.GetByInstitutionId(request.InstitutionId)
            };
            return response;
        }

        [HttpPost]
        [Route("contact/create")]
        [Authorize(Roles = "Admin")]
        public async Task<CreateContactResponse> CreateContact([FromBody] CreateContactRequest request)
        {
            CreateContactResponse response = new CreateContactResponse()
            {
                Entity = await ContactService.CreateAsync(Mapper.Map<ContactDTO>(request))
            };
            return response;
        }

        [HttpPut]
        [Route("contact/update")]
        [Authorize(Roles = "Admin")]
        public async Task<UpdateContactResponse> UpdateContact([FromBody] UpdateContactRequest request)
        {
            UpdateContactResponse response = new UpdateContactResponse()
            {
                Entity = await ContactService.UpdateAsync(Mapper.Map<ContactDTO>(request)) 
            };

            return response;
        }
    }
}
