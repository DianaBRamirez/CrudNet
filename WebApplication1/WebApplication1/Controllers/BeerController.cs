using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class BeerController : Controller
    {
       
        
        private readonly PubContext _context; //es de tipo PubContext para obtener lo de la BDD del archivo json
        public BeerController(PubContext context)   //le asignamos a context lo de la bdd
        {
            _context = context;
        }
        public async Task< IActionResult> Index()
        {
            var beers = _context.Beers.Include(b=>b.Brand);
            return View(await beers.ToListAsync());
        }


        // GET: Obtener el formulario de edición
        public IActionResult Update(int id)
        {
            var beer = _context.Beers.Find(id); // Busca la cerveza por ID
            if (beer == null)
            {
                return NotFound();
            }

            // Mapear los datos al ViewModel
            var model = new BeerViewModel
            {
                BeerId = beer.BeerId,
                Name = beer.Name,
                BrandId = beer.BrandId
            };

            // Cargar las marcas para el dropdown
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", beer.BrandId);
            return View(model);
        }

        // POST: Actualizar la cerveza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beer = await _context.Beers.FindAsync(model.BeerId);
                if (beer == null)
                {
                    return NotFound();
                }

                // Actualizamos los datos
                beer.Name = model.Name;
                beer.BrandId = model.BrandId;

                _context.Update(beer);
                await _context.SaveChangesAsync(); // Guardamos los cambios en la base de datos
                return RedirectToAction(nameof(Index));
            }

            // Si hay un error en el modelo, cargamos nuevamente las marcas
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.BrandId);
            return View(model);
        }


        //Por método get
        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name"); //cremaos diccionario
            return View();
        }



        //por post
        [HttpPost]
        [ValidateAntiForgeryToken] //evitamos que nos manden información de otro sitio
        public async Task< IActionResult> Create(BeerViewModel model) //incluimos la view model 
        {

            if (ModelState.IsValid ) //validamos los datos
            {
                var beer = new Beer()    //ahora hacemos la insercion para ensto creamos una  instancia
                {
                    Name = model.Name,  //recuperamos los datos
                    BrandId = model.BrandId
                };

                _context.Add(beer);  //guardamos instancia
                await _context.SaveChangesAsync();  //guardamos en BDD
                return RedirectToAction(nameof(Index));  //si es exitoso te retorna al index

            }
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.BrandId); //aquí agregamos el dato seleccionado, es decir el id
            return View(model);  //en esta mandamos el modelo
        }


        // POST: Elimina la cerveza seleccionada
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer != null)
            {
                _context.Beers.Remove(beer);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index)); // Redirige a la lista después de eliminar
        }



    }
}
