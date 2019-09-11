using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Api.Data;
using Portal.Api.Models;

namespace Portal.Api.Controllers
{
    // http://localhost:5000/api/Values
    [Authorize]
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
        public async Task<IActionResult> GetValues()
        {
            var values = await _dbContext.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _dbContext.Values.FirstOrDefaultAsync(x =>x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddValue([FromBody] Value value)
        {            
            _dbContext.Values.Add(value);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditValue(int id, [FromBody] Value value)
        {
            var data = await _dbContext.Values.FindAsync(id);
            data.Name = value.Name;
            _dbContext.Values.Update(data);
            await _dbContext.SaveChangesAsync();
            return Ok(data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _dbContext.Values.FindAsync(id);
            _dbContext.Values.Remove(data);
            await _dbContext.SaveChangesAsync();
            return Ok(data);
        }
    }
}
