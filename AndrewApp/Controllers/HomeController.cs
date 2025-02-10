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

        // ??????? ?????? ?? ????????????
        public HomeController(ILogger<HomeController> logger, ICmsSectionService cmsSectionService)
        {
            _logger = logger;
            _cmsSectionService = cmsSectionService;
        }

        // ??? Index ??? ???????????? ?????? CMS ??????
        public IActionResult Index()
        {
            var cmsSectionsDto = _cmsSectionService.GetCmsSections(); // ????????? ??? ??????
            var cmsSections = cmsSectionsDto.Select(cs => new CmsSectionModel
            {
                Title = cs.Title,
                Description = cs.Description,
                CmsSectionType = cs.CmsSectionType,
                Image = cs.Image
            }).ToList(); // ???????????? ?? ?????? ??? ?????????????
            return View(cmsSections); // ????????? ?? ? View
        }

        // ??? ??? ???????????? CMS ?????? ?? ?? ID
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
    }
}
