using Domain.Entities;
using Application.Models.Request;
namespace Application.Interfaces
{
    public interface IClientService
    {
        List<Client> GetAllClients();
        Client? Get(int id);
        Client? Get(string name);
        int AddClient(ClientCreateRequest request);
        void DeleteClient(int id);
        void UpdateClient(int id, ClientUpdateRequest request);
    }
}
