using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BrandController : Controller
    {

        private readonly PubContext _context; //es de tipo PubContext para obtener lo de la BDD del archivo json
        public BrandController(PubContext context)   //le asignamos a context lo de la bdd
        {
            _context = context;
        }
        public async Task<IActionResult>  Index()
        {
            return View(await _context.Brands.ToListAsync());  //context la bdd, brands la tabla, to list es para traerlo en lista
        }
    }
}
