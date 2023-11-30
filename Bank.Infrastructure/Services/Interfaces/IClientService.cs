using Bank.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client?> GetByAsync(int? id);
        Task<bool> SaveAsync(Client client);
        Task<bool> DeleteAsync(Client? id);
        Task<bool> UpdateAsync(Client? client);
    }
}
