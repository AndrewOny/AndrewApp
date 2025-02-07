using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndrewCore.DTOs;
using AndrewCore.RepositoriesInterfaces;
using AndrewDAL.Migrations;
using AndrewDAL.Models;

namespace AndrewDAL.Repositories
{
    public class CmsSectionRepository : ICmsSectionRepository
    {
        private readonly SqLiteContext _context;

        public List<CmsSectionDto> GetCmsSectionsByType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type cannot be null or empty", nameof(type));

            return _context.CmsSections
                .Where(s => s.CmsSectionType != null && s.CmsSectionType.Name.Equals(type, StringComparison.OrdinalIgnoreCase))
                .Select(s => new CmsSectionDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    ImageId = s.ImageId,
                    CmsSectionTypeId = s.CmsSectionTypeId
                })
                .ToList();
        }

        public CmsSectionRepository(SqLiteContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int? CreateCmsSection(CmsSectionDto cmsSectionDto)
        {
            if (cmsSectionDto == null)
                throw new ArgumentNullException(nameof(cmsSectionDto));

            var entity = new CmsSection
            {
                Title = cmsSectionDto.Title,
                Description = cmsSectionDto.Description,
                ImageId = cmsSectionDto.ImageId,
                CmsSectionTypeId = cmsSectionDto.CmsSectionTypeId
            };

            _context.CmsSections.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public List<CmsSectionDto> GetCmsSections()
        {
            return _context.CmsSections
                .Select(s => new CmsSectionDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    ImageId = s.ImageId,
                    CmsSectionTypeId = s.CmsSectionTypeId
                })
                .ToList();
        }

        public CmsSectionDto GetCmsSectionById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID", nameof(id));

            var section = _context.CmsSections.Find(id);
            if (section == null) return null;

            return new CmsSectionDto
            {
                Id = section.Id,
                Title = section.Title,
                Description = section.Description,
                ImageId = section.ImageId,
                CmsSectionTypeId = section.CmsSectionTypeId
            };
        }

        public async Task<bool> UpdateCmsSectionAsync(CmsSectionDto cmsSectionDto)
        {
            if (cmsSectionDto == null)
                throw new ArgumentNullException(nameof(cmsSectionDto));

            var section = await _context.CmsSections.FindAsync(cmsSectionDto.Id);
            if (section == null) return false;

            section.Title = cmsSectionDto.Title;
            section.Description = cmsSectionDto.Description;
            section.ImageId = cmsSectionDto.ImageId;
            section.CmsSectionTypeId = cmsSectionDto.CmsSectionTypeId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteCmsSectionAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID", nameof(id));

            var section = await _context.CmsSections.FindAsync(id);
            if (section == null) return;

            _context.CmsSections.Remove(section);
            await _context.SaveChangesAsync();
        }
    }
}
