using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")] //https://localhost:7172/api/ApiBeer
    [ApiController]
    public class ApiBeer : ControllerBase  //regresa  Json
    {

        private readonly PubContext _context;   //recibimos lo de la Bdd
        public ApiBeer(PubContext context)
        {
            _context = context;
        }



        public async Task<List<Beer>> Get()   //nombre del modelo
          => await _context.Beers.ToListAsync();//Obtenemos info de la tabla Beers
    }
}
