using AndrewCore.DTOs;
using System.ComponentModel.DataAnnotations;

namespace AndrewApp.Models
{
    public class CmsSectionModel
    {

            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int ImageId { get; set; }
            public ImageDto Image { get; set; }
            public int CmsSectionTypeId { get; set; }
            public CmsSectionTypeDto CmsSectionType { get; set; }
    }
}
