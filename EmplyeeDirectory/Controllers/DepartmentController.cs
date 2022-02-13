using EmplyeeDirectory.Services.Interfaces;
using EmplyeeDirectory.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmplyeeDirectory.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _departmentService.GetAllAsync());
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.AddAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department); 
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.GetByIdAsync(id.GetValueOrDefault());
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, DepartmentViewModel department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.UpdateAsync(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _departmentService.GetByIdAsync(department.DepartmentId) == null)
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
            return View(department);
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.GetByIdAsync(id.GetValueOrDefault());
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _departmentService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _departmentService.GetByIdAsync(id.GetValueOrDefault());
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

    }
}
