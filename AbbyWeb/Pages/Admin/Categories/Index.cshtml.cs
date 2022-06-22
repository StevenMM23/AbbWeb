using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Category> Categories { get; set; }
        
        

        //OnGet() Es lo primero que hace la pagina cuando es abierta
        //En este caso esta obteniendo los registros de Categories de la base de datos
        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
