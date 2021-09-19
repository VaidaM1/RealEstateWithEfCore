using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate_with_efcore.Data;
using RealEstate_with_efcore.Dtos;
using RealEstate_with_efcore.Models;
using System.Linq;

namespace RealEstate_with_efcore.Controllers
{
    public class HouseController : Controller
    {
        private readonly DataContext _context;

        public HouseController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var house = new HouseIndex()
            {
                Houses = _context.Houses.Include(a => a.Company).ToList()
            };
            return View(house); 

        }
        public IActionResult Add()
        {
            var house = new CreateHouse();
            house.House = new House();// tuscias house
            house.Companies = _context.Companies.ToList();// kompaniju sarasas dropdownui
            return View(house);
        }

        [HttpPost]
        public IActionResult Add(CreateHouse createHouse)
        {
            //var house = createHouse.House;

            _context.Houses.Add(createHouse.House);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var house = _context.Houses.Include(c => c.Company).FirstOrDefault(a => a.Id == id);

            var houseEditDto = new CreateHouse()
            {
                House = house,
                Companies = _context.Companies.ToList(),
                Brokers = _context.Brokers.ToList()
            }; //mappinimas iš dtos
            return View(houseEditDto);
        }
    
        [HttpPost]
        public IActionResult Edit(CreateHouse houseEditDto)
        {
            _context.Houses.Update(houseEditDto.House);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var house = _context.Houses.FirstOrDefault(s => s.Id == id);
            _context.Remove(house);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
