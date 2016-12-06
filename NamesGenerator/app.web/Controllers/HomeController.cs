using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.domain;
using Microsoft.AspNetCore.Mvc;
using webapp.ViewModels.Home;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace webapp
{
    public class HomeController : Controller
    {
        private IRepository<DogName> _dogNameRepository;

        public HomeController(IRepository<DogName> dogNameRepository)
        {
            _dogNameRepository = dogNameRepository;
        }

        public IActionResult Index()
        {
            var dogName = _dogNameRepository.GetAll();
            var homeIndexViewModels = new HomeIndexViewModelClass()
            {
                DogNames = dogName
            };

            return View(homeIndexViewModels);
        }

        private DogName CreateAndAddNewDogNameToDatabase()
        {
            var dogName = new DogName()
            {
                Name = "Rufus"
            };
            _dogNameRepository.Add(dogName);
            var dogName1 = new DogName()
            {
                Name = "Jack",
                Id = 2
            };
            _dogNameRepository.Add(dogName1);
            var dogName2 = new DogName()
            {
                Name = "TiOui"
            };
            _dogNameRepository.Add(dogName2);
            var dogName3 = new DogName()
            {
                Name = "Rantamplan"
            };
            _dogNameRepository.Add(dogName3);
            return dogName;
        }
    }
}
