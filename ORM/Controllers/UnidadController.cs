using ORM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Controllers
{
    public class UnidadController
    {
        private readonly SQLiteAsyncConnection _database;
        public UnidadController(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UnidadesModel>().Wait();
        }

        public Task<List<UnidadesModel>> GetUnidades()
        {
            return _database.Table<UnidadesModel>().ToListAsync();
        }

        public Task<UnidadesModel> GetUnidadesById(int id)
        {
            return _database.Table<UnidadesModel>()
                .Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveUnidades(UnidadesModel unidad)
        {
            if (unidad.Id != 0)
            {
                return _database.UpdateAsync(unidad);
            }
            else
            {
                return _database.InsertAsync(unidad);
            }
        }

        public Task<int> DeteleUnidad(UnidadesModel unidad)
        {
            return _database.DeleteAsync(unidad);
        }
    }
}
