using FreelanceHub.Models;

namespace FreelanceHub.Repositories
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        Client? GetById(int id);
        void Add(Client client);
        void Update(Client client);
        void Delete(int id);

        IQueryable<Client> Search(string? search);
        int GetTotalClients();
        int GetClientsWithPhone();
        int GetClientsWithoutPhone();
        int GetTotalUsers();
    }
}
