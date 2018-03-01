using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using System.Collections.Generic;
using System;

namespace LibraryApp.Controllers
{
  public class PatronController : Controller
  {
    [HttpGet("/patron/landing")]
    public ActionResult PatronLanding()
    {
      return View();
    }
  }
}
