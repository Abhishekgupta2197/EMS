#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS.Models;

namespace EMS.Controllers
{
    public class AssignTaskController : Controller
    {
        private readonly CompanyDbContext _context;

        public AssignTaskController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: AssignTask
        public async Task<IActionResult> Index()
        {
            var companyDbContext = _context.AssignTasks.Include(a => a.Employee);
            return View(await companyDbContext.ToListAsync());
        }

        // GET: AssignTask/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignTask = await _context.AssignTasks
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AssignTaskId == id);
            if (assignTask == null)
            {
                return NotFound();
            }

            return View(assignTask);
        }

        // GET: AssignTask/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: AssignTask/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignTaskId,AssignTaskName,EmployeeId")] AssignTask assignTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", assignTask.EmployeeId);
            return View(assignTask);
        }

        // GET: AssignTask/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignTask = await _context.AssignTasks.FindAsync(id);
            if (assignTask == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", assignTask.EmployeeId);
            return View(assignTask);
        }

        // POST: AssignTask/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignTaskId,AssignTaskName,EmployeeId")] AssignTask assignTask)
        {
            if (id != assignTask.AssignTaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignTaskExists(assignTask.AssignTaskId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", assignTask.EmployeeId);
            return View(assignTask);
        }

        // GET: AssignTask/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignTask = await _context.AssignTasks
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AssignTaskId == id);
            if (assignTask == null)
            {
                return NotFound();
            }

            return View(assignTask);
        }

        // POST: AssignTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignTask = await _context.AssignTasks.FindAsync(id);
            _context.AssignTasks.Remove(assignTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignTaskExists(int id)
        {
            return _context.AssignTasks.Any(e => e.AssignTaskId == id);
        }
    }
}
