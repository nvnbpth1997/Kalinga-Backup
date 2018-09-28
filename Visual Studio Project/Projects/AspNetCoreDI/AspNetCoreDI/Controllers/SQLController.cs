using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SQLController : ControllerBase
    {
        readonly IConfiguration _configuration;
        readonly IHostingEnvironment _hostingEnvironment;
        public SQLController(IConfiguration configuration, IHostingEnvironment HostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = HostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                ConnectionString = _configuration["SQL:ConnectionString"],
                ContentPath = _hostingEnvironment.ContentRootPath

            });
        }

    }
}