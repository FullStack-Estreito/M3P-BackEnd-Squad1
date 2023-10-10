using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;
using LabSchoolAPIAtendimentoRepositoryodels;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<Atendimento> CreateAsync(Atendimento atendimento);
        Task<IEnumerable<Atendimento>> GetAllAsync();
        Task<Atendimento> GetByIdAsync(int id);
        Task UpdateAsync(Atendimento atendimento);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}