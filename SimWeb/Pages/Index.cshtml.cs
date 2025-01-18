using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimConsole.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string MoveSequence { get; set; } = "dlrludllurdlurrr"; // Domy�lna warto�� sekwencji

    public void OnGet()
    {
        // Nic nie robi - tylko wy�wietla stron�
    }

    public IActionResult OnPost()
    {
        if (MoveSequence.Length != 15 || !MoveSequence.All(c => "drlu".Contains(c)))
        {
            ModelState.AddModelError(nameof(MoveSequence), "Move sequence must be 15 characters long and contain only d, r, u, or l.");
            return Page();
        }

        // Przekierowanie do strony wizualizacji z sekwencj� ruch�w jako parametr
        return RedirectToPage("Visualization", new { moves = MoveSequence });
    }
}

