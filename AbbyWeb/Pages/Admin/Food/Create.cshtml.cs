using Abby.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Food;

public class Edit : PageModel
{
    public Abby.Models.Food Food { get; set; }
    private readonly ApplicationDbContext _db;

    public Edit(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        await _db.AddAsync(Food);
        await _db.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}