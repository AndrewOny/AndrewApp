using System.Diagnostics;
using AndrewApp.Models;
using AndrewCore.DTOs;
using AndrewCore.Services.Interfaces;
using AndrewDAL.Migrations;
using AndrewDAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AndrewApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICmsSectionService _cmsSectionService;
        private readonly IVisitorMessageService _emailService;

        public HomeController(ILogger<HomeController> logger, ICmsSectionService cmsSectionService, IVisitorMessageService emailService)
        {
            _logger = logger;
            _cmsSectionService = cmsSectionService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            var cmsSectionsDto = _cmsSectionService.GetCmsSections();
            var cmsSections = cmsSectionsDto.Select(cs => new CmsSectionModel
            {
                Title = cs.Title,
                Description = cs.Description,
                CmsSectionType = cs.CmsSectionType,
                Image = cs.Image
            }).ToList(); 
            return View(cmsSections); 
        }

        public IActionResult CmsSectionDetails(int id)
        {
            var cmsSectionDto = _cmsSectionService.GetCmsSectionById(id);
            if (cmsSectionDto == null)
            {
                return NotFound();
            }

            var cmsSection = new CmsSectionModel
            {
                Title = cmsSectionDto.Title,
                Description = cmsSectionDto.Description,
                CmsSectionType = cmsSectionDto.CmsSectionType,
                Image = cmsSectionDto.Image
            };

            return View(cmsSection);
        }

        [HttpPost("testemail")]
        public async Task<IActionResult> SendEmail([FromForm] VisitorMessageDto model)
        {
            if (model == null)
                return BadRequest("Invalid request");

            await _emailService.SendEmailAsync(model.Name, model.Email, model.Title, model.Message);
            return new JsonResult(new { success = true, message = "Your message has been sent successfully!" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Home/Error")]
        public IActionResult Error(int statusCode)
        {
            var viewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            if (statusCode == 404)
            {
                return View("NotFound", viewModel);
            }

            return View(viewModel);
        }
    }
}
