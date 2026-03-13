using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
namespace MVCDemo.Controllers
{
    public class DogController : Controller
    {
        static private List<Dog> dogs = new List<Dog>();
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DogController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        private async Task<string?> SaveImageAsync(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            try
            {
                // Create uploads folder if it doesn't exist
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "dogs");
                Directory.CreateDirectory(uploadsFolder);

                // Generate unique filename
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                // Save file
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // Return relative path for storing in database
                return Path.Combine("/uploads/dogs", fileName).Replace("\\", "/");
            }
            catch
            {
                return null;
            }
        }
        // GET: DogController
        public ActionResult Index()
        {
            return View(dogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            var dog = dogs.FirstOrDefault(d => d.Id == id);
            if (dog == null)
            {
                return View("DogNotFound", id);
            }
            return View(dog);
        }

        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Dog d)
        {
            try
            {
                // Handle image upload
                if (d.ImageFile != null && d.ImageFile.Length > 0)
                {
                    d.ImagePath = await SaveImageAsync(d.ImageFile);
                }

                if (ModelState.IsValid)
                {
                    dogs.Add(d);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Create", d);
                }
            }
            catch
            {
                return View("Create", d);
            }
        }

        // GET: DogController/Edit/5
        public ActionResult Edit(int id)
        {
            var dog = dogs.FirstOrDefault(d => d.Id == id);
            if (dog == null)
            {
                return NotFound();
            }
            return View(dog);
        }

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Dog d)
        {
            try
            {
                var dog = dogs.FirstOrDefault(x => x.Id == id);
                if (dog == null)
                {
                    return NotFound();
                }
                dog.Name = d.Name;
                dog.Age = d.Age;

                // Handle image upload
                if (d.ImageFile != null && d.ImageFile.Length > 0)
                {
                    dog.ImagePath = await SaveImageAsync(d.ImageFile);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DogController/Delete/5
        public ActionResult Delete(int id)
        {
            var dog = dogs.FirstOrDefault(d => d.Id == id);
            if (dog == null)
            {
                return NotFound();
            }
            return View(dog);
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var dog = dogs.FirstOrDefault(d => d.Id == id);
                if (dog != null)
                {
                    // Delete image file if it exists
                    if (!string.IsNullOrEmpty(dog.ImagePath))
                    {
                        try
                        {
                            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, dog.ImagePath.TrimStart('/'));
                            if (System.IO.File.Exists(imagePath))
                            {
                                System.IO.File.Delete(imagePath);
                            }
                        }
                        catch
                        {
                            // Continue with deletion even if image deletion fails
                        }
                    }
                    dogs.Remove(dog);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
