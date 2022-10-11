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
            var serieEntidades = _context.Series.Where(s => s.Activo).Include(s => s.Categoria).ToList();
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
        public IActionResult Editar([FromRoute] int id)
        {
            var serieEntidad = _context.Series.FirstOrDefault(s => s.Id == id);
            if (serieEntidad == null)
            {
                return View();
            }
            var categorias = _context.Categorias.Where(c => c.Activo).ToList();
            var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);
            SelectList CategoriasLista = new SelectList(categoriasDTO, "Id", "Name");
            var serieParaEditar = _mapper.Map<SerieEdicionDTO>(serieEntidad);
            serieParaEditar.CategoriasLista = CategoriasLista;
            return View(serieParaEditar);
        }
        [HttpPost]
        public IActionResult Editar(SerieEdicionDTO serieEdicionDTO)
        {

            if (ModelState.IsValid)
            {
                var serieEntidad = _context.Series.FirstOrDefault(s => s.Id == serieEdicionDTO.Id);
                serieEntidad.Director = serieEdicionDTO.Director;
                serieEntidad.Portada = serieEdicionDTO.Portada;
                serieEntidad.FechaCreacion = serieEdicionDTO.FechaCreacion;
                serieEntidad.Nombre = serieEdicionDTO.Nombre;
                serieEntidad.PaisOrigen = serieEdicionDTO.PaisOrigen;
                serieEntidad.Temporadas = serieEdicionDTO.Temporadas;
                serieEntidad.CategoriaId = serieEdicionDTO.CategoriaId;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var categorias = _context.Categorias.Where(c => c.Activo).ToList();
            var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);
            SelectList CategoriasLista = new SelectList(categoriasDTO, "Id", "Name");
            var serie = new SerieEdicionDTO();
            serie.CategoriasLista = CategoriasLista;
            return View(serie);
        }
        public IActionResult Borrar([FromRoute] int id)
        {
            var serie = _context.Series.FirstOrDefault(s => s.Id == id);
            if (serie == null)
            {
                return View();
            }
            SerieDTO serieDTO = _mapper.Map<SerieDTO>(serie);
            return View(serieDTO);
        }
        [HttpPost]
        public IActionResult Borrar(SerieDTO serieDTO)
        {
            var serie = _context.Series.FirstOrDefault(s => s.Id == serieDTO.Id);
            if (serie == null)
            {
                return View();
            }
            //_context.Categorias.Remove(categoria);
            //_context.SaveChanges();
            serie.Activo = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
