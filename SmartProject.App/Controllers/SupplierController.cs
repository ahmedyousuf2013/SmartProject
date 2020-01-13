using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartProject.Core.Entity;
using SmartProject.Model.Dto;
using SmartProject.Repository.SupplierRepository;

namespace SmartProject.App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase{
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository= supplierRepository;
            _mapper =  mapper;
        }
   
        // GET: api/Supplier
        [HttpGet]
        public  async Task<ActionResult<List<SupplierDto>>> Get()
        {
            try
            {
                var target = _supplierRepository.FindAll().Select(x => new SupplierDto(x));

                if (target==null)
                {
                    return NotFound();
                }
                return target.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: api/Supplier/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult< SupplierDto>> Get(int id)
        {
            try
            {
                var result = _supplierRepository.FindByCondition(x => x.Id == id).Select(x => new SupplierDto(x)).FirstOrDefault();

                if (result==null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: api/Supplier
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupplierDto  supplierDto)
        {
            try
            {

                var entity = _mapper.Map<Supplier>(supplierDto);

                var supplierResponse =  await _supplierRepository.SaveAsync(entity);

                return StatusCode(201, new  { supplierResponse });
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Supplier/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(int id, [FromBody] Supplier value)
        {
            try
            {
                var supplier = _supplierRepository.FindByCondition(x => x.Id == id).FirstOrDefault(); ;
                
                _supplierRepository.Update(supplier);
                
                return "Completed Sucuessfuly";
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public  async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                var supplier = _supplierRepository.FindByCondition(x => x.Id == id).FirstOrDefault();
                _supplierRepository.Delete(supplier);

                return "Deleted Susccussfuly";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
