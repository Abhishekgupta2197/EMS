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
    public class EmployeeController : Controller
    {
        private readonly CompanyDbContext _context;

        public EmployeeController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {

            var companyDbContext = _context.Employees.Include(e => e.City).Include(e => e.Department).Include(e => e.Country).Include(e => e.Position).Include(e => e.State);
           
            return View(await companyDbContext.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.City)
                .Include(e => e.Department)
                .Include(e => e.Country)
                .Include(e => e.Position)
                .Include(e => e.State)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            //ViewBag.cities = new SelectList(_context.Cities, "CityId", "CityName");
            ViewBag.Depts = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Countries = new SelectList(_context.Countries, "CountryId", "CountryName");
            ViewBag.Positions = new SelectList(_context.Positions, "PositionId", "PositionName");
            //ViewBag.States = new SelectList(_context.States, "StateId", "StateName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,BirthDate,Gender,Profile,EmailId,Password,Address,DepartmentId,PositionId,CountryId,StateId,CityId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", employee.CityId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Countries, "CountryId", "CountryId", employee.EmployeeId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionId", employee.PositionId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", employee.StateId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.Depts = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.Countries = new SelectList(_context.Countries, "CountryId", "CountryName");
            ViewBag.Positions = new SelectList(_context.Positions, "PositionId", "PositionName");
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,BirthDate,Gender,Profile,EmailId,Password,Address,DepartmentId,PositionId,CountryId,StateId,CityId")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "CityId", "CityId", employee.CityId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", employee.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Countries, "CountryId", "CountryId", employee.EmployeeId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionId", employee.PositionId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateId", employee.StateId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.City)
                .Include(e => e.Department)
                .Include(e => e.Country)
                .Include(e => e.Position)
                .Include(e => e.State)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        public JsonResult LoadState(int Id)
        {
            var state = _context.States.Where(e => e.StateCountryId == Id).ToList();
            return Json(new SelectList(state, "StateId", "StateName"));

        }

        // Loading cities of State(here Id = StateId)
        public JsonResult LoadCity(int Id)
        {
            var city = _context.Cities.Where(e => e.CityStateId == Id).ToList();
            return Json(new SelectList(city, "CityId", "CityName"));
        }
        //Loading Department as a dropdrown List here by Id  
        public JsonResult LoadDepartment(int Id)
        {
            var dept = _context.Departments.Where(e => e.DepartmentId == Id).ToList();
            return Json(new SelectList(dept, "Department_Id", "Department_Name"));
        }

        //Loading Department as a dropdrown List here by Id
        public JsonResult LoadPosition(int Id)
        {
            var position = _context.Positions.Where(e => e.PositionId == Id).ToList();
            return Json(new SelectList(position, "Position_Id", "Position_Name"));
        }
    }
}
