using System;
using System.Threading.Tasks;
using budgetTracker.Data;
using budgetTracker.Dtos;
using budgetTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace budgetTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(request.Name, request.Password);

            if(!response.Success)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {

            byte[] pic;
            if(request.Picture.Length > 0)
                pic = Convert.FromBase64String(request.Picture);
            else
                pic = null;

            var response = await _authRepo.Register(
                new User { 
                    Name = request.Name,
                    DOB = request.DOB,
                    Picture = pic,
                },
                request.Password
            );

            if(!response.Success)
                return BadRequest(response);
            
            return Ok(response);
        }
    }
}