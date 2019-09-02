using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Api.Data;
using Portal.Api.Models;

namespace Portal.Api.Controllers
{
    // http://localhost:5000/api/Values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public ValuesController (DataContext DBContext)
        {
            _dbContext = DBContext;
        }
        // GET api/values
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = _dbContext.Values.ToList();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = _dbContext.Values.FirstOrDefault(x =>x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddValue([FromBody] Value value)
        {            
            _dbContext.Values.Add(value);
            _dbContext.SaveChanges();
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult EditValue(int id, [FromBody] Value value)
        {
            var data = _dbContext.Values.Find(id);
            data.Name = value.Name;
            _dbContext.Values.Update(data);
            _dbContext.SaveChanges();
            return Ok(data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _dbContext.Values.Find(id);
            _dbContext.Values.Remove(data);
            _dbContext.SaveChanges();
            return Ok(data);
        }
    }
}
