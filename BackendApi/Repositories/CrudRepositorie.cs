using AutoMapper;
using BackendApi.Data;
using BackendApi.Models;
using BackendApi.Models.Dao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Repositories
{
    public class CrudRepositorie : ICrudRepositorie
    {

        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public CrudRepositorie(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteCrud(int id)
        {
            var crud = await _context.Crud.FindAsync(id);
            if (crud == null)
            {
                return false;
            }

            _context.Crud.Remove(crud);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<CrudDto>> GetCrud()
        {
            List<Crud> lista = await _context.Crud.ToListAsync();
            return _mapper.Map<List<CrudDto>>(lista);
        }

        public async Task<CrudDto> GetCrudId(int id)
        {
            Crud crud = await _context.Crud.FindAsync(id);

            return _mapper.Map<CrudDto>(crud);
        }

        public async Task<CrudDto> PostCrud(CrudDto crud)
        {
            Crud crudq = _mapper.Map<CrudDto, Crud>(crud);
            _context.Crud.Add(crudq);
            await _context.SaveChangesAsync();

            return _mapper.Map<Crud, CrudDto>(crudq);
        }

        public async Task<CrudDto> PutCrud(int id, CrudDto crud)
        {

            Crud crudq = _mapper.Map<CrudDto, Crud>(crud);
            _context.Entry(crudq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrudExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return _mapper.Map<Crud, CrudDto>(crudq);
        }

        private bool CrudExists(int id)
        {
            return _context.Crud.Any(e => e.Id == id);
        }
    }
}
