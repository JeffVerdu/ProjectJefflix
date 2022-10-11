using AutoMapper;
using JefflixMVC.Models;
using JefflixMVC.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JefflixMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var seriesEntidades = _context.Series.Where(s => s.Activo).ToList();
            var seriesDTO = _mapper.Map<List<SerieParaMostrarDTO>>(seriesEntidades);
            return View(seriesDTO);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}