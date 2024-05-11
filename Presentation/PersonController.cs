using Contract;
using Microsoft.AspNetCore.Mvc;
using Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [Route("[controller]")]
    public class PersonController(IPersonService personService) : ControllerBase
    {
        private readonly IPersonService personService = personService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
        {
            var result = await personService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<PersonDto>> GetById(Guid id)
        {
            var result = await personService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Post([FromBody] PersonAddDto personAddDto)
        {
            var result = await personService.CreateAsync(personAddDto);

            return CreatedAtRoute("GetById", new { id = result.Id }, result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid personId)
        {
            await personService.DeleteAsync(personId);

            return Ok();
        }
    }
}
