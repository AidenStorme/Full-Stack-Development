using Microsoft.AspNetCore.Mvc;
using AutomaticEncoding9.ViewModels;

namespace AutomaticEncoding9.Controllers
{
    public class CommentController : Controller
    {
        private static readonly List<CommentVM> _comments = new(); // nieuwe lege comment list maken
        public IActionResult Index()
        {
            var vm = new CommentPageVM
            {
                Comments = _comments // Alle comments doorgeven aan de view
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(CommentPageVM commentPageVM)
        {
            if(ModelState.IsValid && commentPageVM.NewComment != null)
            {
                _comments.Add(commentPageVM.NewComment); // Nieuwe comment toevoegen aan de lijst
            }
            var vm = new CommentPageVM
            {
                Comments = _comments // Alle comments doorgeven aan de view
            };
            ModelState.Clear(); // Textboxes leeg maken na invoer
            return View(vm);
        }
    }
}
