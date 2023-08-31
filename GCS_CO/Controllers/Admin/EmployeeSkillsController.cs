using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GCS_CO.Data;
using GCS_CO.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace GCS_CO.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class EmployeeSkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeSkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeSkills
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeSkills.Include(e => e.Employee).Include(e => e.Skill);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeSkills == null)
            {
                return NotFound();
            }

            var employeeSkill = await _context.EmployeeSkills
                .Include(e => e.Employee)
                .Include(e => e.Skill)
                .FirstOrDefaultAsync(m => m.EmployeeSkillId == id);
            if (employeeSkill == null)
            {
                return NotFound();
            }

            return View(employeeSkill);
        }

        // GET: EmployeeSkills/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["SkillName"] = new SelectList(_context.Skills, "SkillName", "SkillName");
            return View();
        }

        // POST: EmployeeSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeSkillId,EmployeeId,FirstName,LastName,SkillName,SkillDescription,SkillPayRate")] EmployeeSkill employeeSkill)
        {
            var skill = await _context.Skills.SingleOrDefaultAsync(s => s.SkillName == employeeSkill.SkillName);
            if (skill == null)
            {
                // Handle the case where the skill is not found
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(employeeSkill.EmployeeId);
            if (employee == null)
            {
                // Handle the case where the skill is not found
                return NotFound();
            }
            var newEmployeeSkill = new EmployeeSkill
            {
                EmployeeId = employeeSkill.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                SkillName = skill.SkillName,
                SkillDescription = skill.SkillDescription,
                SkillPayRate = skill.SkillPayRate
            };
            if (ModelState.IsValid)
            {
                _context.Add(newEmployeeSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeeSkill.EmployeeId);
            ViewData["SkillName"] = new SelectList(_context.Skills, "SkillName", "SkillName", employeeSkill.SkillName);
            return View(employeeSkill);
        }

        // GET: EmployeeSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeSkills == null)
            {
                return NotFound();
            }

            var employeeSkill = await _context.EmployeeSkills.FindAsync(id);
            if (employeeSkill == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "RegionAbbrev", employeeSkill.EmployeeId);
            ViewData["SkillName"] = new SelectList(_context.Skills, "SkillName", "SkillName", employeeSkill.SkillName);
            return View(employeeSkill);
        }

        // POST: EmployeeSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeSkillId,EmployeeId,FirstName,LastName,SkillName,SkillDescription,SkillPayRate")] EmployeeSkill employeeSkill)
        {
            if (id != employeeSkill.EmployeeSkillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeSkillExists(employeeSkill.EmployeeSkillId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "RegionAbbrev", employeeSkill.EmployeeId);
            ViewData["SkillName"] = new SelectList(_context.Skills, "SkillName", "SkillName", employeeSkill.SkillName);
            return View(employeeSkill);
        }

        // GET: EmployeeSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeSkills == null)
            {
                return NotFound();
            }

            var employeeSkill = await _context.EmployeeSkills
                .Include(e => e.Employee)
                .Include(e => e.Skill)
                .FirstOrDefaultAsync(m => m.EmployeeSkillId == id);
            if (employeeSkill == null)
            {
                return NotFound();
            }

            return View(employeeSkill);
        }

        // POST: EmployeeSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeSkills == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EmployeeSkills'  is null.");
            }
            var employeeSkill = await _context.EmployeeSkills.FindAsync(id);
            if (employeeSkill != null)
            {
                _context.EmployeeSkills.Remove(employeeSkill);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeSkillExists(int id)
        {
          return (_context.EmployeeSkills?.Any(e => e.EmployeeSkillId == id)).GetValueOrDefault();
        }
    }
}
