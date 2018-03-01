using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using System.Collections.Generic;
using System;

namespace LibraryApp.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
