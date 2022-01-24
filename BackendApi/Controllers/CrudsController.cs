using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendApi.Data;
using BackendApi.Models;
using BackendApi.Repositories;
using BackendApi.Models.Dao;
using Microsoft.AspNetCore.Authorization;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudsController : ControllerBase
    {
        private readonly ICrudRepositorie _crudRepositorie;

        public CrudsController(ICrudRepositorie crudRepositorie)
        {
            _crudRepositorie = crudRepositorie;
        }

        // GET: api/Cruds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crud>>> GetCrud()
        {
            var lista = await _crudRepositorie.GetCrud();
            return Ok(lista);
        }

        // GET: api/Cruds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Crud>> GetCrud(int id)
        {
            var crud = await _crudRepositorie.GetCrudId(id);

            if (crud == null)
            {
                return NotFound();
            }

            return Ok(crud);
        }

        // PUT: api/Cruds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCrud(int id, CrudDto crud)
        {
            await _crudRepositorie.PutCrud(id, crud);

            return NoContent();
        }

        // POST: api/Cruds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Crud>> PostCrud(CrudDto crud)
        {
            await _crudRepositorie.PostCrud(crud);

            return CreatedAtAction("GetCrud", new { id = crud.Id }, crud);
        }

        // DELETE: api/Cruds/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCrud(int id)
        {
            var crud = await _crudRepositorie.DeleteCrud(id);
            if (crud == false)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
