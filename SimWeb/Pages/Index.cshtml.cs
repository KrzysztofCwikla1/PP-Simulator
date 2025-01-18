using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimConsole.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string MoveSequence { get; set; } = "dlrludllurdlurrr"; // Domyœlna wartoœæ sekwencji

    public void OnGet()
    {
        // Nic nie robi - tylko wyœwietla stronê
    }

    public IActionResult OnPost()
    {
        if (MoveSequence.Length != 15 || !MoveSequence.All(c => "drlu".Contains(c)))
        {
            ModelState.AddModelError(nameof(MoveSequence), "Move sequence must be 15 characters long and contain only d, r, u, or l.");
            return Page();
        }

        // Przekierowanie do strony wizualizacji z sekwencj¹ ruchów jako parametr
        return RedirectToPage("Visualization", new { moves = MoveSequence });
    }
}

