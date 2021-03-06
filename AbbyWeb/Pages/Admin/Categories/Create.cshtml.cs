
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category Category { get; set; }
        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(String.Empty, "The DisplayOrder cannot Exactly math the Name");
            }
            if (!ModelState.IsValid) return Page();
            
            await _db.AddAsync(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("/Categories/Index");

        }
    }
}
