using AspReactApp.Server.Data;
using AspReactApp.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspReactApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PersonController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            var data = await _dataContext.Persons.ToArrayAsync();
            return data;
        }

        [HttpPost]
        public IActionResult PostPerson(Person person)
        {
            if(ModelState.IsValid)
            {
                _dataContext.Persons.Add(person);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var person = _dataContext.Persons.Find(id);
            if(person != null)
            {
                _dataContext.Persons.Remove(person);
                _dataContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
