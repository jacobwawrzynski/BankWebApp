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
            var account = await _clientRepo.GetByAsync(id);
            return await _clientRepo.DeleteAsync(account);
        }

        public Task<IEnumerable<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Client? client)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(Client client)
        {

        }
    }
}
