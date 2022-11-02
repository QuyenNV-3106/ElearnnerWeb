using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ELearnerApi.Models;
using ElearnerApi.Models;

namespace ElearnerWebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ElearnnerDBContext _context;

        public LoginModel(ElearnnerDBContext context)
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

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("admin"))
                {
                    if (User.IsInRole("teacher")) { return RedirectToPage("/TopicsTeacher/TopicTeacher"); }
                    else
                    {
                        return RedirectToPage("/Index");
                    }

                }
            }
            ViewData["TopicId"] = new SelectList(_context.Topics, "Id", "ImgUrl");
            return Page();
        }

        [BindProperty]
        public ELearnerApi.Models.Accounts Account { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = _context.Accounts.Where(acc => acc.Email == Account.Email && acc.Password == Account.Password).FirstOrDefault();
            if (user != null)
            {
                if (user.Status != "disable")
                {
                    Role.RoleNameCheck = user.Role;
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Account.Email),
                    new Claim(ClaimTypes.Role, user.Role),

                };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var authProperties = new AuthenticationProperties
                    {

                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), authProperties);

                    if (user.Role == "admin")
                    {
                        return RedirectToPage("/Topics/Index");
                    }
                    if (user.Role == "user")
                    {
                        return RedirectToPage("/Index");
                    }
                    if (user.Role == "teacher")
                    {
                        return RedirectToPage("/TopicsTeacher/TopicTeacher");
                    }
                }
                else
                {
                    ViewData["Message"] = "Wrong email or password";
                    return Page();
                }

            }
            else
            {
                ViewData["Message"] = "Wrong email or password";
                return Page();
            }


            return RedirectToPage("/Index");
        }
    }
}
