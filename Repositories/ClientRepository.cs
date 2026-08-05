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

        public IQueryable<Client> Search(string? search)
        {
            var clients = _context.Clients.OrderByDescending(c => c.CreatedAt).AsQueryable();

            if(!string.IsNullOrWhiteSpace(search))
            {
                clients = clients.Where(c =>
                c.Name.Contains(search) ||
                c.Email.Contains(search) ||
                c.CompanyName.Contains(search)
                );
            }

            return clients;
        }

        public int GetTotalClients()
        {
            return _context.Clients.Count();
        }

        public int GetClientsWithPhone()
        {
            return _context.Clients.Count(c => !string.IsNullOrEmpty(c.Phone));
        }

        public int GetClientsWithoutPhone()
        {
            return _context.Clients.Count(c => string.IsNullOrEmpty(c.Phone));
        }

        public int GetTotalUsers()
        {
            return _context.Users.Count();
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
                _context.SaveChanges();
            }
        }
    }
}
