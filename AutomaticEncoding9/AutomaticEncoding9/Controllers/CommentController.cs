using AutomaticEncoding9.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutomaticEncoding9.Controllers
{
    public class CommentController : Controller
    {
        private static readonly List<CommentVM> _comments = new();

        public IActionResult Index()
        {
            var vm = new CommentPageVM
            {
                Comments = _comments
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(CommentPageVM commentPageVM)
        {
            if (ModelState.IsValid && commentPageVM.NewComment != null)
            {
                _comments.Add(commentPageVM.NewComment);
            }
            var vm = new CommentPageVM
            {
                Comments = _comments
            };
            ModelState.Clear(); //zorgt ervoor dat de tekstvakken leeg zijn na het posten
            return View(vm);
        }
    }
}
