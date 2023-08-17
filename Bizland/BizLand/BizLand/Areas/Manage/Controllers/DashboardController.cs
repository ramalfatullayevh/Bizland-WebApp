using BizLand.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
        AppDbContext _appDbContext { get; }
        public DashboardController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View(_appDbContext.Employees.ToList());
        }
    }
}
