using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DeteleModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeteleModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category Category { get; set; }
        
        public void OnGet(int id)
        {
            Category = _db.Category.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            
            if (!ModelState.IsValid) return Page();
            
            _db.Remove(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category deteled successfully";

            return RedirectToPage("/Categories/Index");

        }
    }
}
