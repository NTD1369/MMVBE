using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MMVDashboard.Application.Interfaces;
using MMVDashboard.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMVDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //_bankInService.
            return null;
        }
        [HttpGet]
        [Route("login")]
        public async Task<GenericResult> GetLogin(string userName, string passWord)
        {
            return await _userService.Login(userName, passWord);

        }
    }
}
