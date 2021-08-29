using API_FlowersStore.API.Contracts;
using API_FlowersStore.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace API_FlowersStore.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(Roles = ApplicationIdentityRole.Admin)]
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(Contracts.User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            var contractUsers = _mapper.Map<Contracts.User[]>(users);
            return Ok(contractUsers);
        }

        [Authorize(Roles = ApplicationIdentityRole.Admin)]
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(Contracts.User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            var contractUser = _mapper.Map<Contracts.User>(user);
            return Ok(contractUser);
        }

        [Authorize(Roles = ApplicationIdentityRole.Admin)]
        [HttpPost("GetByNameAndPassword")]
        [ProducesResponseType(typeof(Contracts.User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByNameAndPassword(UserCredentials userCredentials)
        {
            var user = await _userService.GetByNameAndPassword(userCredentials.Name, userCredentials.Password);
            var contractUser = _mapper.Map<Contracts.User>(user);
            return Ok(contractUser);
        }
    }
}
