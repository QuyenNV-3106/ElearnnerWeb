using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELearnerApi.Models;

namespace WebApplication1.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ElearnnerDBContext _context;

        public AccountsController(ElearnnerDBContext context)
        {
            _context = context;
        }

        private List<Role> GenerateRoleName()
        {
            List<Role> roles = new List<Role>();
            roles.Add(new Role()
            {
                Id = 1,
                RoleName = "user"
            });

            roles.Add(new Role()
            {
                Id = 2,
                RoleName = "admin"
            });

            roles.Add(new Role()
            {
                Id = 3,
                RoleName = "teacher"
            });

            return roles;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var elearnnerDBContext = _context.Accounts.Include(a => a.Topic);
            return View(await elearnnerDBContext.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            ViewData["Role"] = new SelectList(GenerateRoleName(), "Id", "RoleName");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,Password,PhoneNumber,Address,TopicId,Role")] Account account)
        {
            if (ModelState.IsValid)
            {
                if (account.Role.Contains("1"))
                {
                    account.Role = "user";
                }
                if (account.Role.Contains("2"))
                {
                    account.Role = "admin";
                }
                if (account.Role.Contains("3"))
                {
                    account.Role = "teacher";
                }

                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Role"] = new SelectList(GenerateRoleName(), "RoleName", "RoleName");
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["Role"] = new SelectList(GenerateRoleName(), "RoleName", "RoleName");
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,Password,PhoneNumber,Address,TopicId,Role")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
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
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "ImgUrl", account.TopicId);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
