using AndrewCore.DTOs;
using AndrewCore.RepositoriesInterfaces;
using AndrewCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCore.Services
{
    public class CmsSectionService : ICmsSectionService
    {
        private readonly ICmsSectionRepository _cmsSectionRepository;

        public CmsSectionService(ICmsSectionRepository cmsSectionRepository)
        {
            _cmsSectionRepository = cmsSectionRepository ?? throw new ArgumentNullException(nameof(cmsSectionRepository));
        }

        public int? CreateCmsSection(CmsSectionDto cmsSectionDto)
        {
            if (cmsSectionDto == null)
                throw new ArgumentNullException(nameof(cmsSectionDto));

            return _cmsSectionRepository.CreateCmsSection(cmsSectionDto);
        }

        public List<CmsSectionDto> GetCmsSections()
        {
            return _cmsSectionRepository.GetCmsSections() ?? new List<CmsSectionDto>();
        }

        public CmsSectionDto GetCmsSectionById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID", nameof(id));

            return _cmsSectionRepository.GetCmsSectionById(id);
        }

        public List<CmsSectionDto> GetCmsSectionsByType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type cannot be null or empty", nameof(type));

            return _cmsSectionRepository.GetCmsSections()
                                        ?.Where(s => s.CmsSectionType?.Name.Equals(type, StringComparison.OrdinalIgnoreCase) == true)
                                        .ToList() ?? new List<CmsSectionDto>();
        }

        public async Task<bool> UpdateCmsSectionAsync(CmsSectionDto cmsSectionDto)
        {
            if (cmsSectionDto == null)
                throw new ArgumentNullException(nameof(cmsSectionDto));

            return await _cmsSectionRepository.UpdateCmsSectionAsync(cmsSectionDto);
        }

        public async Task DeleteCmsSectionAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID", nameof(id));

            await _cmsSectionRepository.DeleteCmsSectionAsync(id);
        }
    }
}
