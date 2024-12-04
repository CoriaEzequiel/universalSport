using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Context;



namespace Infrastructure.Data.Repository
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        private readonly universalContext _context;
        public AdminRepository(universalContext context) : base(context)
        {
            _context = context;
        }

        public Admin? Get(string name)
        {
            return _context.Admins.FirstOrDefault(x => x.Name == name);
        }
    }
}
