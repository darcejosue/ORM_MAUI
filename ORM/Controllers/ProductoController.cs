using ORM.Models;
using ORM.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Controllers
{
    public class ProductoController
    {
        private readonly SQLiteAsyncConnection _database;

        public ProductoController(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ProductoModel>().Wait();
        }

        public Task<int> SaveProduct(ProductoModel producto)
        {
            if (producto.Id != 0)
            {
                return _database.UpdateAsync(producto);
            }
            else
            {
                return _database.InsertAsync(producto);
            }
        }

        public Task<List<ProductoModel>> GetProducts()
        {
            return _database.Table<ProductoModel>().ToListAsync();
        }
        public Task<ProductoModel> GetProductById(int id)
        {
            return _database.Table<ProductoModel>()
                .Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteProductById(ProductoModel producto)
        {
            return _database.DeleteAsync(producto);
        }
    }
}
