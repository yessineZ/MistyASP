using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using misty.DataAccess.Repository;
using misty.DataAccess.Repository.IRepository;
using misty.Models;
using MistyASP.DataAccess.Data;
using System.CodeDom;

namespace MistyASP.Controllers {
    public class GameController : Controller {



        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GameController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;


        }

        public IActionResult Index() {
            List<Game> catergories = _unitOfWork.GameRepository.GetAll(includes :"Category").ToList();

            return View(catergories);
        }
        [HttpGet]
        public IActionResult Upsert(int? id) {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.CategoryList = CategoryList;


            if (id == null || id == 0) {
                return View();
            }
            else {
                Game game = _unitOfWork.GameRepository.Get(u => u.Id == id);
                return View(game);
            }
        }



        [HttpPost]
        public IActionResult Upsert(Game obj, IFormFile? file) {
            if (obj.Title == obj.Author.ToString()) {
                ModelState.AddModelError("name", "You cant put the title and the Author with the same name");
            }

            if (obj.Title == "test") {
                ModelState.AddModelError("", "You cant put the name test");
            }

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null) {
                string name = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string ModelPath = Path.Combine(wwwRootPath, @"images\games");

                if (!string.IsNullOrEmpty(obj.ImageUrl)) {
                    // Delete old image
                    var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath)) {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Update or add the game object
                if (obj.Id == 0) {
                    _unitOfWork.GameRepository.Add(obj);
                }
                else {
                    // Ensure Id is not set explicitly
                     // or set it to default value
                    _unitOfWork.GameRepository.Update(obj);
                }

                using (var file1 = new FileStream(Path.Combine(ModelPath, name), FileMode.Create)) {
                    file.CopyTo(file1);
                }
                obj.ImageUrl = @"\images\games\" + name;
            }

            _unitOfWork.Save();
            TempData["success"] = "Game created or updated successfully";
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id) {
            if (id == null || id == 0) {
                return NotFound();
            }

            Game? game = _unitOfWork.GameRepository.Get(u => u.Id == id);
            //Game? game1 = _db.catergories.FirstOrDefault(u =>u.Id == id);
            //Game? game2 = _db.catergories.Where(u => u.Id ==id).FirstOrDefault()  ; 
            if (game == null) {
                return NotFound() ;
            }


            return View(game);



        }

        [HttpPost, ActionName("Delete")]
        public IActionResult deletePOST(int? id) {
            Game game = _unitOfWork.GameRepository.Get(u => u.Id == id);
            if (game == null) {
                return NotFound();
            }
            if(game.ImageUrl != null) {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, game.ImageUrl.TrimStart('\\')
                );
                if (System.IO.File.Exists(oldImagePath)) {
                    System.IO.File.Delete(oldImagePath);
                }
            }
           
                ;
         

            _unitOfWork.GameRepository.Remove(game);
            _unitOfWork.Save();
            TempData["success"] = "game deleted successfully";
            return RedirectToAction("Index");


        }
    }

}
    
    
    
    
    
    
    
    
    
    
    
    
    
    





















