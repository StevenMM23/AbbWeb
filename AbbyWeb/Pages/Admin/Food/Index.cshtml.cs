using Abby.DataAccess.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.Models;
namespace AbbyWeb.Pages.Admin.Food;

public class Index : PageModel
{
    private readonly ApplicationDbContext _db;

    public Index(ApplicationDbContext db)
    {
        _db = db;
    }
    public IEnumerable<Abby.Models.Food> Food { get; set; }
    public void OnGet()
    {
        
    }
}