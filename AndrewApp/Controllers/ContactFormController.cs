using AndrewDAL.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace AndrewApp.Controllers
{
    using AndrewApp.Models;
    using AndrewDAL.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ContactFormController : Controller
    {
        private readonly SqLiteContext _context;

        public ContactFormController(SqLiteContext context)
        {
            _context = context;
        }

        // Displays the contact form
        public IActionResult Index()
        {
            return View();
        }

        // Displays the form for creating a new contact submission
        public IActionResult Create()
        {
            return View();
        }

        // Handles form submission (POST request)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Assuming you have a model named `ContactForm` in the database
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

                // Save the contact form submission to the database
                _context.ContactForms.Add(contactForm);
                _context.SaveChanges();

                // Optionally, you can redirect to a confirmation page or show a success message
                return RedirectToAction("Success");
            }

            // If the model is invalid, return to the form with validation errors
            return View(model);
        }

        // Displays a success message after submission
        public IActionResult Success()
        {
            return View();
        }
    }
}
