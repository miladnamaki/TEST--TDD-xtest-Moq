using Microsoft.AspNetCore.Mvc;
using MvcTest.Models;
using MvcTest.Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcTest.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductServies _servies;

        public ProductApiController(IProductServies servies)
        {
            _servies = servies;
        }

        // GET: api/<ApiController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_servies.GetALL());
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _servies.GetById(id);
            if (product==null)
            {
                return NotFound();
            }
            return Ok(product);

        }

        // POST api/<ApiController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            var result = _servies.Add(value);
            return CreatedAtAction("Get", new {Id=result.Id });
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public  IActionResult Put( [FromBody] Product value)
        {
            
            if (value.Id>0)
            {
                _servies.edit(value);
                return Ok(true);
            }
            return BadRequest("حذف انجام نشد ");
            
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productt = _servies.GetById(id);
                
            if (productt ==null)
            {
                
                return NotFound();
            }
            else
            {
                _servies.Remove(id);
                return Ok();

            }
           
        }
    }
}
