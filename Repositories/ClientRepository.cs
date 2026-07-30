using System;
using System.Collections.Generic;
using FreelanceHub.Models;
using FreelanceHub.Data; 

namespace FreelanceHub.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Client client)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
