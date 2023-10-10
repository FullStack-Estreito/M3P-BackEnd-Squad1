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

        public async Task<Atendimento> CreateAtendimento(AtendimentoCreateDTO atendimentoDto)
        {
            var atendimento = new Atendimento
            {
                Data = atendimentoDto.Data,
                Descricao = atendimentoDto.Descricao,
                AlunoId = atendimentoDto.AlunoId,
                PedagogoId = atendimentoDto.PedagogoId,
                StatusAtivo = atendimentoDto.StatusAtivo
            };

            _context.Atendimentos.Add(atendimento);
            await _context.SaveChangesAsync();

            return atendimento;
        }

        public async Task<IEnumerable<Atendimento>> GetAllAtendimentos()
        {
            return await _context.Atendimentos.ToListAsync();
        }

        public async Task<Atendimento> GetAtendimentoById(int id)
        {
            return await _context.Atendimentos.FindAsync(id);
        }

        public async Task<bool> UpdateAtendimento(AtendimentoUpdateDTO atendimentoDto)
        {
            var atendimento = await _context.Atendimentos.FindAsync(atendimentoDto.AtendimentoId);
            if (atendimento == null)
                return false;

            atendimento.Data = atendimentoDto.Data;
            atendimento.Descricao = atendimentoDto.Descricao;
            atendimento.AlunoId = atendimentoDto.AlunoId;
            atendimento.PedagogoId = atendimentoDto.PedagogoId;
            atendimento.StatusAtivo = atendimentoDto.StatusAtivo;

            _context.Atendimentos.Update(atendimento);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAtendimento(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento == null)
                return false;

            _context.Atendimentos.Remove(atendimento);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}