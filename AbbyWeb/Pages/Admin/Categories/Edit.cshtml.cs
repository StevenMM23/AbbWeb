using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
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
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(String.Empty, "The DisplayOrder cannot Exactly math the Name");
            }
            if (!ModelState.IsValid) return Page();
            
            _db.Update(Category);
            await _db.SaveChangesAsync();
            TempData["success"] = "Category updated successfully";

            return RedirectToPage("/Categories/Index");

        }
    }
}
