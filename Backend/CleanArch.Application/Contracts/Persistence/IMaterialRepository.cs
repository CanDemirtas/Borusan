using CleanArch.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Contracts.Persistence
{
    public interface IMaterialRepository : IGenericRepositoryAsync<Material>
    {
 
    }
}
