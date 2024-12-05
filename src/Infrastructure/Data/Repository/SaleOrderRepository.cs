using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Context;

namespace Infrastructure.Data
{
    public class SaleOrderRepository : BaseRepository<SaleOrder>, ISaleOrderRepository
    {
        private readonly universalContext _context;
        public SaleOrderRepository(universalContext context) : base(context)
        {
            _context = context;
        }

        public List<SaleOrder> GetAllByClient(int clientId) 
        {
            return _context.SaleOrders
                .Include(so => so.Client)
                .Include(so => so.SaleOrderDetails)
                .ThenInclude(so => so.Product)
                .Where(r => r.ClientId == clientId)
                .ToList();
        }

        public SaleOrder? GetById(int id)
        {
            return _context.SaleOrders
                .Include(r => r.Client)
                .Include(r => r.SaleOrderDetails)
                .ThenInclude(so => so.Product)
                .SingleOrDefault(x => x.Id == id);
        }
    }
}