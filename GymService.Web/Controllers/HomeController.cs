﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymService.Infrastructure.Exceptions;
using GymService.Infrastructure.Services.Repositories;
using GymService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GymService.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            string message = "hello, it's me !";

            ViewBag.Message = message.Split('\n');
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginCredentials credentials)
        {
            try
            {
                await _userService.LoginAsync(credentials.Email, credentials.Password);

                ViewBag.Message = "LoginSucced";

                //TODO login token
            }
            catch (ServiceException ex)
            {
                if (ex.Code == ErrorCodes.InvalidCredentials)
                {
                    ViewBag.Message = ErrorCodes.InvalidCredentials;
                }

                //TODO invalid password credential
            }

            return View("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
