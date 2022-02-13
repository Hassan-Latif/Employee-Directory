using EmplyeeDirectory.DbContext;
using EmplyeeDirectory.Services.Interfaces;
using EmplyeeDirectory.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmplyeeDirectory.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _context;
        public EmployeeController(IEmployeeService employeeService,ApplicationDbContext context)
        {
            _employeeService=employeeService;
            _context=context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _employeeService.GetAllAsync());
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DepartmentId= _context.Departments.Select(x=> new SelectListItem
            {
                Text= x.DepartmentName,
                Value = x.DepartmentId.ToString()
            }).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetByIdAsync(id.GetValueOrDefault());
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.UpdateAsync(employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _employeeService.GetByIdAsync(employee.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _employeeService.GetByIdAsync(id.GetValueOrDefault());
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _employeeService.GetByIdAsync(id.GetValueOrDefault());
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


    }
}
