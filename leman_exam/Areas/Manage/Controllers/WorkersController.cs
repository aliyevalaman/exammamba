using leman_exam.DAL;
using leman_exam.Models;
using Microsoft.AspNetCore.Mvc;

namespace leman_exam.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class WorkersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public WorkersController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View(_context.Workers.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Workers workers)
        {
            if (!ModelState.IsValid) { return View(); }
            if (!workers.ImgFile.ContentType.Contains(@"image/")){

                ModelState.AddModelError("ImgFile", "File duzgun daxil edilmeyib");
                return View();


            }
            string path = _environment.WebRootPath + @"\Upload\";
            string filename = Guid.NewGuid() + workers.ImgFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                workers.ImgFile.CopyTo(stream);

            }
            workers.ImgUrl = filename;
            _context.Workers.Add(workers);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var workers = _context.Workers.FirstOrDefault(x => x.Id == id);
            if (workers == null)
            {
                return NotFound();
            }
            return View(workers);
        }
        [HttpPost]
        public IActionResult Update(Workers workers)
        {

            if (!ModelState.IsValid) { return View(); }

            if (workers.ImgFile != null)
            {
                string path = _environment.WebRootPath + @"\Upload\";
                string filename = Guid.NewGuid() + workers.ImgFile.FileName;
                using (FileStream stream = new FileStream(path + filename, FileMode.Create))
                {
                    workers.ImgFile.CopyTo(stream);
                }
                workers.ImgUrl = filename;
            }
            _context.Workers.Update(workers);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Delete(int id)
        {
            var workers = _context.Workers.FirstOrDefault(x => x.Id == id);
            if (workers == null)
            {
                return View();

            }
            _context.Workers.Remove(workers);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }

    
}
