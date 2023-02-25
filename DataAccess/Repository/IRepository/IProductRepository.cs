using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IProductRepository
    {
        void SaveProduct(Product product);
        Product GetProductById(int id);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);

        List<Product> GetProducts();
    }
}
