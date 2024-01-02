using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhotoApp.Models;

namespace PhotoApp.Controllers

{

    public class PhotoController : Controller
    {
        static List<Photo> _photo = new List<Photo>();
        static int index = 1;

        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        public IActionResult Index()
        {
            var x = _photoService.FindAll();
            return View(x);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Photo model = new Photo();
            model.Aparats = _photoService
                .FindAllAparats()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Marka })
                .ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Photo model)
        {
            if (ModelState.IsValid)
            {
                _photoService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var contact = _photoService.FindById(id);

            contact.Aparats = _photoService
                .FindAllAparats()
                .Select(oe => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = oe.Marka,
                    Value = oe.Id.ToString(),

                }
                ).ToList();

            if (contact != null)
            {
                return View(contact);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Photo model)
        {
            if (ModelState.IsValid)
            {
                _photoService.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var contact = _photoService.FindById(id);

            contact.Aparats = _photoService
                .FindAllAparats()
                .Select(oe => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = oe.Marka,
                    Value = oe.Id.ToString(),

                }
                ).ToList();

            if (contact != null)
            {
                return View(contact);
            }
            return View(contact);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            var contact = _photoService.FindById(id);
            if (contact == null)
            {
                return NotFound();
            }

            _photoService.Delete(id);

            return RedirectToAction("Index");
        }

    }
}
