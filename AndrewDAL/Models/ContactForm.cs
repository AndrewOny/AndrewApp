using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndrewDAL.Models
{
    public class ContactForm
    {
        [Key]
        public int Id { get; set; }
        public string NameLabel { get; set; } = string.Empty;
        public string NamePlaceholder { get; set; } = string.Empty;

        public string EmailLabel { get; set; } = string.Empty;
        public string EmailPlaceholder { get; set; } = string.Empty;

        public string TitleLabel { get; set; } = string.Empty;
        public string TitlePlaceholder { get; set; } = string.Empty;

        public string MessageLabel { get; set; } = string.Empty;
        public string MessagePlaceholder { get; set; } = string.Empty;
    }
}
