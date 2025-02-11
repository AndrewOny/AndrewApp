using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using AndrewCore.DTOs;
using AndrewCore.RepositoriesInterfaces;

namespace AndrewCore.Services
{
    public class ContactFormService  // Made public
    {
        private readonly IContactFormRepository _contactFormRepository;

        public ContactFormService(IContactFormRepository contactFormRepository)
        {
            _contactFormRepository = contactFormRepository;
        }

        public async Task HandleContactFormSubmissionAsync(ContactFormDto model)
        {
            // Call the repository to send the email
            await _contactFormRepository.SendContactFormEmailAsync(model);
        }
    }
}

