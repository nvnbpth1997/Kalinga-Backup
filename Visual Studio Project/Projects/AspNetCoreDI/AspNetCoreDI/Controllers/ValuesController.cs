using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCoreDI.Contracts;
using AspNetCoreDI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AspNetCoreDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly SMTP  _smtpOptions;
        public ValuesController(IOptions<SMTP> SMTPOptions)
        {
            _smtpOptions = SMTPOptions.Value;
        }

        // GET api/values
        [HttpGet]
        //method injection
        public IActionResult Get()
        {

            throw new NotImplementedException("Not implemented default get");

            //return Ok(new
            //{
            //    message = _smtpOptions.domain
            //});
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromServices] IHttpClientFactory HttpClientFactory, int id)
        {
            var client = HttpClientFactory.CreateClient();

            var result = await client.GetAsync(new Uri($"https://jsonplaceholder.typicode.com/todos/{id}"));
            
            return Ok((await result.Content.ReadAsStringAsync()));
        }
    }
}
