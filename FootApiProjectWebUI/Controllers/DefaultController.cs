﻿using Microsoft.AspNetCore.Mvc;

namespace FootApiWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
