using AndrewCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewCore.RepositoriesInterfaces
{
    public interface ICmsSectionRepository
    {
        int? CreateCmsSection(CmsSectionDto cmsSectionDto);
        List<CmsSectionDto> GetCmsSections();
        CmsSectionDto GetCmsSectionById(int id);
        List<CmsSectionDto> GetCmsSectionsByType(string type);
        Task<bool> UpdateCmsSectionAsync(CmsSectionDto cmsSectionDto);
        Task DeleteCmsSectionAsync(int id);
    }
}
