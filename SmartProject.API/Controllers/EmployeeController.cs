using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SmartProject.Core.Entity;
using SmartProject.Repository.EmployeeRepository;

namespace SmartProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    //[ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository= employeeRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var x = _employeeRepository.FindAll().ToList();
            return new string[] { "value1", "value2" };
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new CamelCaseOnlyConverter() }
            };

            return new JsonResult("", settings);
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
