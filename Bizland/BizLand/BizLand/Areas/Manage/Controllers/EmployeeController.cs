using BizLand.DAL;
using BizLand.Models;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class EmployeeController : Controller
    {
        readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Employees.ToList());

        }

        public IActionResult Delete(int id)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Update(int? id, Employee employee)
        {
            if (id is null || id != employee.Id) return BadRequest();
            Employee existemployee = _context.Employees.Find(id);
            if (employee is null) return NotFound();
            existemployee.FullName = employee.FullName;
            existemployee.Position = employee.Position;
            existemployee.ImgUrl = employee.ImgUrl;
            existemployee.Position = employee.Position;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            Employee employee = _context.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            return View(employee);

        }
    }
}
