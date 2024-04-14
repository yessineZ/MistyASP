using Microsoft.AspNetCore.Mvc;
using misty.Models;
using MistyASP.DataAccess.Data;


namespace MistyASP.Controllers {
    public class EtudiantController : Controller {


        public readonly ApplicationDbContext _db; 
        public EtudiantController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index() {

            List<Etudiant> etudiants = _db.etudiants.ToList(); 

            return View(etudiants);
        }

        public IActionResult Create() {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Etudiant etu) {
        
            if(ModelState.IsValid) {
                _db.etudiants.Add(etu);
				_db.SaveChanges();
				RedirectToAction("Index");
            }

            return View();
        
        }

       

    }
}
