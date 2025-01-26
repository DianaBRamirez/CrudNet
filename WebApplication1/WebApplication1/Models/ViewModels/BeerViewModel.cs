using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels
{


    //clase para formularios
    public class BeerViewModel
    {
        [Required] //hace que sea requerido
        [Display(Name="Nombre" )]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Marca")] //hace que aparezca marca en vez de el BrandId
        public int BrandId { get; set; }

        // Agregamos el ID para manejar la edición
        public int BeerId { get; set; }
    }
}
