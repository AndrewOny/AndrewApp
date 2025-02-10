using AndrewCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewCore.Services.Interfaces
{
    public interface ICmsSectionService
    {
        // Створення нової CMS секції
        int? CreateCmsSection(CmsSectionDto cmsSectionDto);

        // Отримання всіх CMS секцій
        List<CmsSectionDto> GetCmsSections();

        // Отримання CMS секції за її ID
        CmsSectionDto GetCmsSectionById(int id);

        // Отримання CMS секцій за типом
        List<CmsSectionDto> GetCmsSectionsByType(string type);

        // Оновлення CMS секції
        Task<bool> UpdateCmsSectionAsync(CmsSectionDto cmsSectionDto);

        // Видалення CMS секції
        Task DeleteCmsSectionAsync(int id);
    }

}
