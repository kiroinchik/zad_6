using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProductsService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Create(Product model);
        Task Update(Product model);
        Task Delete(int id);
    }
}
