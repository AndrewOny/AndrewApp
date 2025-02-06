using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewDAL.Models
{
    public class CmsSectionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CmsSection> CmsSections { get; set; } // Add this property
    }
}
