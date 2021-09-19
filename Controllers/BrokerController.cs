using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate_with_efcore.Data;
using RealEstate_with_efcore.Dtos;
using RealEstate_with_efcore.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstate_with_efcore.Controllers
{
    public class BrokerController : Controller
    {
        private readonly DataContext _context;

        public BrokerController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var brokerDtos = new List<BrokerWithCompanyName>();

            var brokers = _context.Brokers.Include(b => b.CompanyBroker).ThenInclude(cb => cb.Company).ToList();

            foreach (var broker in brokers)
            {
                var companyNames = broker.CompanyBroker.Select(c => c.Company).Select(c => c.CompanyName);

                brokerDtos.Add(new BrokerWithCompanyName()
                {
                    Broker = broker,
                    CompaniesNames = string.Join(",", companyNames)

                });
            }
            return View(brokerDtos);
        }

        public IActionResult Add()
        {
            var broker = new CreateBroker()
            {
                Companies = _context.Companies.ToList()
            };
            return View(broker);
        }

        [HttpPost]
        public IActionResult Add(CreateBroker createbroker)
        {
            var broker = new Broker()
            {
                Name = createbroker.Broker.Name,
                Surname = createbroker.Broker.Surname
            }; //mapping
            _context.Brokers.Add(broker);
            _context.SaveChanges();

            var companyBroker = new List<CompanyBroker>();
            if (createbroker.CompanyIds != null)
            {
                foreach (var companyId in createbroker.CompanyIds)
                {
                    _context.CompanyBrokers.Add(new CompanyBroker()
                    {
                        Broker = broker,
                        CompanyId = companyId
                    });
                }

            }
            //if (createbroker.CompanyId.HasValue)
            //{

            //    var companyBroker = new CompanyBroker()
            //    {
            //        BrokerId = broker.Id,
            //        CompanyId = createbroker.CompanyId.Value
            //    };
            //    _context.CompanyBrokers.Add(companyBroker);

                _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var createbroker = new CreateBroker();
            createbroker.Broker = _context.Brokers.FirstOrDefault(s => s.Id == id);
            createbroker.Companies = _context.Companies.ToList();
            return View(createbroker);
        }
        [HttpPost]
        public IActionResult Edit(CreateBroker createbroker)
        {
            var tmpRng = _context.CompanyBrokers.Where(b => b.BrokerId == createbroker.Broker.Id);
            _context.CompanyBrokers.RemoveRange(tmpRng);
            if (createbroker.CompanyIds != null)
            {
                foreach (var companyId in createbroker.CompanyIds)
                {
                    var companyBroker = new CompanyBroker()
                    {
                        Broker = createbroker.Broker,
                        CompanyId = companyId
                    };
                    _context.CompanyBrokers.Add(companyBroker);
                }
            }
            _context.Brokers.Update(createbroker.Broker);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var broker = _context.Brokers.FirstOrDefault(s => s.Id == id);
            _context.Remove(broker);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
