using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data.Repository
{
    public class ClientRepository: BaseRepository<Client>, IClientRepository
    {
        private readonly universalContext _context;
        public ClientRepository(universalContext context) : base(context)
        {
            _context = context;
        }

        public Client? Get(string name)
        {
            return _context.Clients.FirstOrDefault(x => x.Name == name);
        }
    }
}
