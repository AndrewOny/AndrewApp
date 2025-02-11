using AndrewDAL.Migrations;
using Microsoft.AspNetCore.Mvc;
using AndrewApp.Models;
using AndrewCore.Services;  // Added namespace for services
using AndrewDAL.Models;
using AndrewCore.DTOs;

namespace AndrewApp.Controllers
{
    public class ContactFormController : Controller
    {
        private readonly SqLiteContext _context;
        private readonly ContactFormService _contactFormService;

        public ContactFormController(SqLiteContext context, ContactFormService contactFormService)
        {
            _context = context;
            _contactFormService = contactFormService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Convert ContactFormModel to ContactFormDto
                var contactFormDto = new ContactFormDto
                {
                    NameLabel = model.NameLabel,
                    NamePlaceholder = model.NamePlaceholder,
                    EmailLabel = model.EmailLabel,
                    EmailPlaceholder = model.EmailPlaceholder,
                    TitleLabel = model.TitleLabel,
                    TitlePlaceholder = model.TitlePlaceholder,
                    MessageLabel = model.MessageLabel,
                    MessagePlaceholder = model.MessagePlaceholder
                };

                // Save the contact form submission to the database
                var contactForm = new ContactForm
                {
                    NameLabel = model.NameLabel,
                    NamePlaceholder = model.NamePlaceholder,
                    EmailLabel = model.EmailLabel,
                    EmailPlaceholder = model.EmailPlaceholder,
                    TitleLabel = model.TitleLabel,
                    TitlePlaceholder = model.TitlePlaceholder,
                    MessageLabel = model.MessageLabel,
                    MessagePlaceholder = model.MessagePlaceholder
                };

                _context.ContactForms.Add(contactForm);
                await _context.SaveChangesAsync();

                // Call service to send the email, now passing the DTO
                await _contactFormService.HandleContactFormSubmissionAsync(contactFormDto);

                return RedirectToAction("Success");
            }

            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }


}
