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
            return _context.Clients.ToList();
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public Client? GetById(int id)
        {
            return _context.Clients.Find(id);
        }

        public void Update(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var client = _context.Clients.Find(id);
            if(client != null)
            {
                _context.Clients.Remove(client);
            }
        }
    }
}
