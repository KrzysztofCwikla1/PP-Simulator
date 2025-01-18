using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace SimConsole.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string MoveSequence { get; set; } = "dlrludllurdlurrr"; 

        private string GenerateRandomSequence(int length)
        {
            var random = new Random();
            const string allowedChars = "drlu";
            return new string(Enumerable.Repeat(allowedChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var action = Request.Form["action"];
            if (action == "StartSimulation")
            {

                if (MoveSequence.Length != 15 || !MoveSequence.All(c => "drlu".Contains(c)))
                {
                    ModelState.AddModelError(nameof(MoveSequence), "Move sequence must be 15 characters long and contain only d, r, u, or l.");
                    return Page();
                }


                return RedirectToPage("Visualization", new { moves = MoveSequence });
            }
            else if (action == "GenerateSequence")
            {

                MoveSequence = GenerateRandomSequence(15);
                return Page();
            }

            return Page();
        }
    }
}
