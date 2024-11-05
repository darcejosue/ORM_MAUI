using ORM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Controllers
{
    public class ProveedorController
    {
        private readonly SQLiteAsyncConnection _database; 
        public ProveedorController(string dbPath) {
            _database = new SQLiteAsyncConnection(dbPath); 
            _database.CreateTableAsync<ProveedorModel>().Wait(); 
        }

        public Task<List<ProveedorModel>> GetProveedores() { 
            return _database.Table<ProveedorModel>().ToListAsync();
        }

        public Task<ProveedorModel> GetProveedorById(int id)
        {
            return _database.Table<ProveedorModel>()
                .Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveProveedor(ProveedorModel proveedor) {
            if (proveedor.Id != 0) { 
                return _database.UpdateAsync(proveedor);
            }
            else
            {
                return _database.InsertAsync(proveedor);
            }
        }

        public Task<int> DeteleProveedor(ProveedorModel proveedor)
        {
            return _database.DeleteAsync(proveedor);
        }


    }
}
