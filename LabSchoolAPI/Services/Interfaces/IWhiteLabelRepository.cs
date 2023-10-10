using System.Collections.Generic;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs.WhiteLabel;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface IWhiteLabelRepository
    {
        Task<WhiteLabelModel> CreateWhiteLabel(WhiteLabelCreateDTO whiteLabelDto);
        Task<IEnumerable<WhiteLabelReadDTO>> GetAllWhiteLabels();
        Task<WhiteLabelReadDTO> GetWhiteLabelById(int id);
        Task<bool> UpdateWhiteLabel(WhiteLabelUpdateDTO whiteLabelDto);
        Task<bool> DeleteWhiteLabel(int id);
    }
}
