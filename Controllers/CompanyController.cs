using Microsoft.AspNetCore.Mvc;
using RealEstate_with_efcore.Data;
using RealEstate_with_efcore.Models;
using System.Linq;

namespace RealEstate_with_efcore.Controllers
{
    public class CompanyController : Controller
    {
        private readonly DataContext _context;

        public CompanyController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var companies = _context.Companies.ToList();

            return View(companies);
        }
        public IActionResult Add()
        {
            var company = new Company();
            company.Brokers = _context.Brokers.ToList();
            return View(company);
        }
        [HttpPost]
        public IActionResult Add(Company company)
        {
            //company.Brokers = _context.Brokers.Where(b => company.BrokerIds.Contains(b.Id)).ToList();
            _context.Companies.Add(company);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var company = _context.Companies.FirstOrDefault(s => s.Id == id);

            return View(company);
        }
        [HttpPost]
        public IActionResult Edit(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var company = _context.Companies.FirstOrDefault(s => s.Id == id);
            _context.Remove(company);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
