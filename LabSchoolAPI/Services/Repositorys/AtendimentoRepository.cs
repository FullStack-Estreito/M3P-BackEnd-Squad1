using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Models;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Services.Interfaces;

namespace LabSchoolAPI.Services.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly LabSchoolContext _context;

        public AtendimentoRepository(LabSchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Atendimento>> GetAllAsync()
        {
            return await _context.Atendimentos.ToListAsync();
        }

        public async Task<Atendimento> GetByIdAsync(int id)
        {
            return await _context.Atendimentos.FindAsync(id);
        }

        public async Task<Atendimento> CreateAsync(Atendimento atendimento)
        {
            _context.Atendimentos.Add(atendimento);
            await _context.SaveChangesAsync();
            return atendimento;
        }

        public async Task UpdateAsync(Atendimento atendimento)
        {
            _context.Entry(atendimento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento != null)
            {
                _context.Atendimentos.Remove(atendimento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Atendimentos.AnyAsync(a => a.Id == id);
        }
    }
}
