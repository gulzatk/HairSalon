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
      public ActionResult Create(string stylistName, string stylistDescription)
      {
        Stylist newStylist = new Stylist(stylistName, stylistDescription);
        newStylist.Save();

        List<Stylist> allStylists = Stylist.GetAll();
        return View("Index", allStylists);
      }

      [HttpGet("/stylists/{id}")]
      public ActionResult Show(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist selectedStylist = Stylist.Find(id);
        List<Client> stylistClient = selectedStylist.GetClients();
        model.Add("stylist", selectedStylist);
        model.Add("client", stylistClient);
        return View(model);
      }

      [HttpGet("/stylists/{id}/delete")]
       public ActionResult Delete(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist stylist = Stylist.Find(id);
        List<Client> stylistClient = stylist.GetClients();

        foreach(Client client in stylistClient)
        {
          Client.DeleteClient(client.GetId());
        }

        Stylist.DeleteStylist(id);

        model.Add("stylist", stylist);
        model.Add("client", stylistClient);
        return View("Delete", model);

      }

      [HttpPost("/stylists/{stylistId}/client")]
      public ActionResult Create(string clientName, int stylistId)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist foundStylist = Stylist.Find(stylistId);
        Client newClient = new Client(clientName, stylistId);
        newClient.Save();
        List<Client> stylistClients = foundStylist.GetClients();
        model.Add("clients", stylistClients);
        model.Add("stylist", foundStylist);
        return View("Show", model);
      }

      [HttpGet("/stylists/{stylistId}/clients/{clientId}/delete")]
       public ActionResult Delete(int stylistId, int clientId)
       {
         Client client = Client.Find(clientId);
         Client.DeleteClient(client.GetId());
         Dictionary<string, object> model = new Dictionary<string, object>();
         Stylist stylist = Stylist.Find(stylistId);
         List<Client> stylistClients = stylist.GetClients();
         model.Add("stylist", stylist);
         model.Add("clients", stylistClients);
         return View("Show", model);

       }
    }
}
