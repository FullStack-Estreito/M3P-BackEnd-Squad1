using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.Services.Interfaces
{
    public class ILogRepository
    {
        Task<LogReadDTO> CreateAsync(LogCreateDTO logCreateDTO);
        Task<IEnumerable<LogReadDTO>> GetAllAsync();
        Task<LogReadDTO> GetByIdAsync(int id);
        Task UpdateAsync(LogUpdateDTO logUpdateDTO);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}