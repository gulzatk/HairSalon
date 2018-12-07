using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
      [HttpGet("/stylists")]
      public ActionResult Index()
      {
        List<Stylist> allStylists  = Stylist.GetAll();
        return View(allStylists);
      }

      [HttpGet("/stylists/new")]
      public ActionResult New()
      {
        return View();
      }

      [HttpPost("stylists")]
      public ActionResult Create(strign stylistName)
      {
        Stylist newStylist = new Stylist(stylistName);
        newStylist.Save();

        List<Stylist> allStylists = Stylist.GetAll();
        return View("Index", allStylists);
      }
    }
}