using BackendApi.Models;
using BackendApi.Models.Dao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendApi.Repositories
{
    public interface ICrudRepositorie
    {
        public Task<List<CrudDto>> GetCrud();

        public Task<CrudDto> GetCrudId(int id);

        public Task<CrudDto> PutCrud(int id, CrudDto crud);

        public Task<CrudDto> PostCrud(CrudDto crud);

        public Task<bool> DeleteCrud(int id);
    }
}
