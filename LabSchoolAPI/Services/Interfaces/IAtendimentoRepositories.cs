using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Models;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface IAtendimentoRepositories
    {
        Task<Atendimento> CreateAtendimento(AtendimentoCreateDTO atendimentoDto);
        Task<IEnumerable<Atendimento>> GetAllAtendimentos();
        Task<Atendimento> GetAtendimentoById(int id);
        Task<bool> UpdateAtendimento(AtendimentoUpdateDTO atendimentoDto);
        Task<bool> DeleteAtendimento(int id);
    }
}