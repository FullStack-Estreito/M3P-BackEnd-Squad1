using LabSchoolAPI.Models;
using LabSchoolAPI.DTOs.WhiteLabel;
using LabSchoolAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.Services.Repositories
{
    public class WhiteLabelRepository : IWhiteLabelRepository
    {
        private readonly LabSchoolContext _context;

        public WhiteLabelRepository(LabSchoolContext context)
        {
            _context = context;
        }

        public async Task<WhiteLabelModel> CreateWhiteLabel(WhiteLabelCreateDTO whiteLabelDto)
        {
            var whiteLabel = new WhiteLabelModel
            {
                NomeEmpresa = whiteLabelDto.NomeEmpresa,
                Slogan = whiteLabelDto.Slogan,
                Cores = whiteLabelDto.Cores,
                UrlLogo = whiteLabelDto.UrlLogo,
                Complemento = whiteLabelDto.Complemento
            };

            _context.WhiteLabels.Add(whiteLabel);
            await _context.SaveChangesAsync();

            return whiteLabel;
        }

        public async Task<IEnumerable<WhiteLabelReadDTO>> GetAllWhiteLabels()
        {
            return await _context.WhiteLabels
                .Select(wl => new WhiteLabelReadDTO
                {
                    WhiteLabelId = wl.Id,
                    NomeEmpresa = wl.NomeEmpresa,
                    Slogan = wl.Slogan,
                    Cores = wl.Cores,
                    UrlLogo = wl.UrlLogo,
                    Complemento = wl.Complemento
                })
                .ToListAsync();
        }

        public async Task<WhiteLabelReadDTO> GetWhiteLabelById(int id)
        {
            return await _context.WhiteLabels
                .Where(wl => wl.Id == id)
                .Select(wl => new WhiteLabelReadDTO
                {
                    WhiteLabelId = wl.Id,
                    NomeEmpresa = wl.NomeEmpresa,
                    Slogan = wl.Slogan,
                    Cores = wl.Cores,
                    UrlLogo = wl.UrlLogo,
                    Complemento = wl.Complemento
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateWhiteLabel(WhiteLabelUpdateDTO whiteLabelDto)
        {
            var whiteLabel = await _context.WhiteLabels.FindAsync(whiteLabelDto.WhiteLabelId);
            if (whiteLabel == null)
                return false;

            whiteLabel.NomeEmpresa = whiteLabelDto.NomeEmpresa;
            whiteLabel.Slogan = whiteLabelDto.Slogan;
            whiteLabel.Cores = whiteLabelDto.Cores;
            whiteLabel.UrlLogo = whiteLabelDto.UrlLogo;
            whiteLabel.Complemento = whiteLabelDto.Complemento;

            _context.WhiteLabels.Update(whiteLabel);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> DeleteWhiteLabel(int id)
        {
            var whiteLabel = await _context.WhiteLabels.FindAsync(id);
            if (whiteLabel == null)
                return false;

            _context.WhiteLabels.Remove(whiteLabel);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
