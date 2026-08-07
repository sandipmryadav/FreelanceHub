using FreelanceHub.Models;

namespace FreelanceHub.Repositories
{
    public interface IClientRepository
    {
       Task <List<Client>> GetAll();
        Task<Client?> GetById(int id);
        Task Add(Client client);
        Task Update(Client client);
        Task Delete(int id);

        IQueryable<Client> Search(string? search);
        Task <int> GetTotalClients();
        Task <int> GetClientsWithPhone();
        Task <int> GetClientsWithoutPhone();
        Task <int> GetTotalUsers();
    }
}
