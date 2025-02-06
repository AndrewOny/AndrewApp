using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewDAL.Models
{
    public class CmsSection
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(Image))]
        public int ImageId { get; set; }
        public Image Image { get; set; }

        [ForeignKey(nameof(CmsSectionType))]
        public int CmsSectionTypeId { get; set; }
        public CmsSectionType CmsSectionType { get; set; }
    }
}
