using AutoMapper;
using JefflixMVC.Models.DTOS;
using JefflixMVC.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JefflixMVC.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SeriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var serieEntidades = _context.Series.Where(s => s.Activo).ToList();
            var seriesDTO = _mapper.Map<List<SerieDTO>>(serieEntidades);
            return View(seriesDTO);
        }
        public  IActionResult Nuevo()
        {
            var categorias = _context.Categorias.Where(c => c.Activo).ToList();
            var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);
            SelectList CategoriasLista = new SelectList(categoriasDTO, "Id", "Name");
            var serieCreacionDTO = new SerieCreacionDTO();
            serieCreacionDTO.CategoriasLista = CategoriasLista;
            return View(serieCreacionDTO);
        }
        [HttpPost]
        public IActionResult Nuevo(SerieCreacionDTO serieCreacionDTO)
        {
            if (ModelState.IsValid)
            {
                var entidad = _mapper.Map<Serie>(serieCreacionDTO);
                entidad.Activo = true;
                _context.Series.Add(entidad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var categorias = _context.Categorias.Where(c => c.Activo).ToList();
            var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);
            SelectList CategoriasLista = new SelectList(categoriasDTO, "Id", "Name");
            var serie = new SerieCreacionDTO();
            serie.CategoriasLista = CategoriasLista;
            return View(serie);
        }
    }
}
