using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using System.Collections.Generic;
using System;

namespace LibraryApp.Controllers
{
  public class AdminController : Controller
  {
    [HttpGet("/admin/landing")]
    public ActionResult AdminLanding()
    {
      return View();
    }

    [HttpGet("/admin/directory")]
    public ActionResult AdminDirectory()
    {
      return View();
    }

    [HttpGet("/admin/books/add")]
    public ActionResult AddBooks()
    {
      return View();
    }

  }
}
