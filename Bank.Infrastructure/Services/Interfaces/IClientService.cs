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
        Task<Client?> GetByIdAsync(int? id);
        Task<bool> CreateAsync(Client client);
        Task<bool> DeleteAsync(int? id);
        Task<bool> UpdateAsync(int? id, Client clientUpdate);
    }
}
