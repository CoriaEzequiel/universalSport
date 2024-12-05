using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly universalContext _context;

        public ProductRepository(universalContext context) : base(context) 
        {
            _context = context;
        }

        public Product? Get(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public List<Product> GetProductWithMaxPrice(decimal price)
        {
            return _context.Products.Where(p => p.Price <= price).ToList();
        }
    }
}
