using System.Security.Claims;
using System.Threading.Tasks;
using MeetingApp.Data;
using MeetingApp.Data.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingApp.Controllers;

public class AccountController : Controller
{
    private readonly DataContext _Context;
    public AccountController(DataContext dataContext)
    {
        _Context = dataContext;
    }

    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(User user)
    {
        await _Context.Users.AddAsync(user);
        await _Context.SaveChangesAsync();

        var UserInfo = _Context.Users.FirstOrDefault(u => u.Email == user.Email );
        var Claim = new List<Claim>();
        Claim.Add(new Claim(ClaimTypes.NameIdentifier, UserInfo.Id.ToString()));
        var ClaimsIdentity = new ClaimsIdentity(Claim, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

        return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(User user)
    {
        var UserInfo = await _Context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
        if (UserInfo != null)
        {
            var userClaim = new List<Claim>();
            userClaim.Add(new Claim(ClaimTypes.NameIdentifier, UserInfo.Id.ToString()));
            var claimsIdentity = new ClaimsIdentity(userClaim, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }
        
        ModelState.AddModelError("", "Email veya şifre hatalı!");
        return View(user);
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}    
