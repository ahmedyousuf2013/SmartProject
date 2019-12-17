using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartProject.Core.Entity;
using SmartProject.Models;
using SmartProject.Repository;
using SmartProject.Repository.EmployeeRepository;
using SmartProject.RepositoryWrapper;

namespace SmartProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
   // [ApiController]

    public class DefaultController : ControllerBase
    {
        
        //private readonly IEmployeeRepository _employeeRepository;
        //private IRepositoryWrapper _repositoryWrapper;

        //public DefaultController(IEmployeeRepository employeeRepository, IRepositoryWrapper repositoryWrapper)
        //{
        //    _employeeRepository= employeeRepository;
        //    _repositoryWrapper=repositoryWrapper;
        //}
        // GET: api/Default
        [HttpGet]
      
        public IEnumerable<string> Get()
        {
            // var val = _employeeRepository.FindAll();
            //   var val2 = _repositoryWrapper.EmployeeRepository.FindAll();

            //var currentUser = HttpContext.User;
            //int spendingTimeWithCompany = 0;

            //if (currentUser.HasClaim(c => c.Type == "DateOfJoing"))
            //{
            //    DateTime date = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "DateOfJoing").Value);
            //    spendingTimeWithCompany = DateTime.Today.Year - date.Year;
            //}
            return new string[] { "value1", "value2" };
        }

        //// GET: api/Default/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Default
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Default/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
