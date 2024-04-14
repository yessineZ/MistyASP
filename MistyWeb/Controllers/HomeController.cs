using Microsoft.AspNetCore.Mvc;
using misty.DataAccess.Repository;
using misty.DataAccess.Repository.IRepository;
using misty.Models;
using System.Diagnostics;

namespace MistyWeb.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork) {
            _logger = logger;
            _unitOfWork = unitOfWork; 
        }



        public IActionResult Index() {
            List<Game> catergories = _unitOfWork.GameRepository.GetAll(includes: "Category").ToList();
            return View(catergories);
        }

        public IActionResult Privacy() {
            return View();
        }
        public IActionResult Details(int id) {
            Game game = _unitOfWork.GameRepository.Get(u => u.Id == id, includes: "Category");  
            return View(game);
        }

        public IActionResult idk() {
            return View(); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
