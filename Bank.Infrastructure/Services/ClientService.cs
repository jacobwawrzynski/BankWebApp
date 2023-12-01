using Bank.Core.Models;
using Bank.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private IBaseRepository<Client> _clientRepo;

        public ClientService(IBaseRepository<Client> clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            var account = await _clientRepo.GetByIdAsync(id);
            return await _clientRepo.DeleteAsync(account);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _clientRepo.GetAllAsync();
        }

        public Task<Client?> GetByIdAsync(int? id)
        {
            return _clientRepo.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int? id, Client clientUpdate)
        {
            var client = await _clientRepo.GetByIdAsync(id);
            client.Phone = clientUpdate.Phone;
            client.City = clientUpdate.City;
            client.Surname = clientUpdate.Surname;
            client.Forename = clientUpdate.Forename;
            return await _clientRepo.UpdateAsync(client);
        }

        public async Task<bool> CreateAsync(Client client)
        {
            return await _clientRepo.CreateAsync(client);
        }
    }
}
