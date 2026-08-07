using System;
using System.Collections.Generic;
using FreelanceHub.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task Add(Client client)
        {
             _context.Clients.Add(client);
            await _context.SaveChangesAsync();
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

        public async Task<int> GetTotalClients()
        {
            return _context.Clients.Count();
        }

        public async Task<int> GetClientsWithPhone()
        {
            return _context.Clients.Count(c => !string.IsNullOrEmpty(c.Phone));
        }

        public async Task<int> GetClientsWithoutPhone()
        {
            return await _context.Clients.CountAsync(c => string.IsNullOrEmpty(c.Phone));
        }

        public async Task<int> GetTotalUsers()
        {
            return await _context.Users.CountAsync();
        }
        public async Task<Client?> GetById(int id)
        {
           return await _context.Clients.FindAsync(id);
        }

        public async Task Update(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var client =await _context.Clients.FindAsync(id);
            if(client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
    }
}
