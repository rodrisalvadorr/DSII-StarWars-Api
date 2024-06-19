using JediApi.Models;
using JediApi.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JediApi.Services
{
    public class JediService(IJediRepository jediRepository)
    {
        private readonly IJediRepository _jediRepository = jediRepository;

        public Task<Jedi> GetByIdAsync(int id)
        {
            var result = _jediRepository.GetByIdAsync(id);
            
            if (result == null)
            {
                throw new Exception();
            }

            return result;
        }

        public Task<List<Jedi>> GetAllAsync()
        {
            return _jediRepository.GetAllAsync();
        }

        public Task<Jedi> AddAsync(Jedi jedi)
        {
            return _jediRepository.AddAsync(jedi);
        }

        public Task<bool> UpdateAsync(Jedi jedi)
        {
            return _jediRepository.UpdateAsync(jedi);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _jediRepository.DeleteAsync(id);
        }
    }
}
