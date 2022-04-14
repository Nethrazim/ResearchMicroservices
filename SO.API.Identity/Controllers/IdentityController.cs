using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SO.API.Identity.Entities.Requests;
using SO.API.Identity.Model.Responses;
using SO.BusinessLayer.Identity.Services;

namespace SO.API.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> _logger;
        private IUserService UserService { get; set; }


        public IdentityController(ILogger<IdentityController> logger, IUserService userService)
        {
            _logger = logger;
            UserService = userService;
        }


        [HttpPost]
        [Route("users/authenticate")]
        [AllowAnonymous]
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            AuthenticateResponse response = new AuthenticateResponse();
            response.Entity = await UserService.AuthenticateAsync(request.Username, request.Password);
            return response;
        }

        [HttpPost]
        [Route("users/create")]
        [AllowAnonymous]
        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            CreateUserResponse response = new CreateUserResponse();
            response.Entity = await UserService.CreateUserAsync(request.Username, request.Email, request.Password, request.Role);
            return response;
        }
    }
}
