using AutoMapper;
using JefflixMVC.Models.DTOS;
using JefflixMVC.Models.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace JefflixMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var categoriasEntidadaes = _context.Categorias.ToList();
            var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categoriasEntidadaes);
            return View(categoriasDTO);
        }

        public IActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Nuevo(CategoriaCreacionDTO categoriaCreacionDTO)
        {
            if (ModelState.IsValid)
            {
                var entidad = _mapper.Map<Categoria>(categoriaCreacionDTO);
                _context.Add(entidad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Editar([FromRoute] int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return View();
            }
            var categoriaParaEditar = _mapper.Map<CategoriaEdicionDTO>(categoria);
            return View(categoriaParaEditar);
        }
        [HttpPost]
        public IActionResult Editar(CategoriaEdicionDTO categoriaEdicionDTO)
        {
            if (ModelState.IsValid)
            {
                var categoria = _context.Categorias.FirstOrDefault(c => c.Id == categoriaEdicionDTO.Id);
                categoria.Name = categoriaEdicionDTO.Name;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();   
        }
    }
}
