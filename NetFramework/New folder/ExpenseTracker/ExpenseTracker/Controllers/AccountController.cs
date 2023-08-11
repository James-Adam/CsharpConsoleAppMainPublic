﻿using ExpenseTracker.Models;
using ExpenseTracker.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public async Task<IActionResult> Users()
    {
        var users = await _context.Users.ToListAsync();
        return View(users);
    }

    public IActionResult Login()
    {
        return View(new LoginVM());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        if (!ModelState.IsValid) return View(loginVM);

        var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
        if (user != null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if (passwordCheck)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded) return RedirectToAction("Index", "Dashboard");
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }

        TempData["Error"] = "Wrong credentials. Please, try again!";
        return View(loginVM);
    }

    public IActionResult Register()
    {
        return View(new RegisterVM());
    }

    [HttpPost]
    public IActionResult Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid) return View(registerVM);

        //var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
        //if (user != null)
        //{
        //    TempData["Error"] = "This email address is already in use";
        return View(registerVM);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }

    public IActionResult AccessDenied(string ReturnUrl)
    {
        return View();
    }
}