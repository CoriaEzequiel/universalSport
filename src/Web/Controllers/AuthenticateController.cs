using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Exceptions;


namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICustomAuthenticationService _customAuthenticationService;

        public AuthenticateController(IConfiguration config, ICustomAuthenticationService authenticateService)
        {
            _config = config;
            _customAuthenticationService = authenticateService;
        }

        [HttpPost("authenticate")] 
        public ActionResult<string> Authenticate([FromBody] CredentialsDtoRequest credentials)
        {
            try
            {
                string token = _customAuthenticationService.Authenticate(credentials); 
                return Ok(token);
            }
            catch (NotAllowedException)
            {
                return Unauthorized(new { message = "Credenciales inválidas. Por favor, verifica tu email y contraseña." });
            }
        }
    }
}