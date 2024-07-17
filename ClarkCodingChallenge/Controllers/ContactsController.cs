using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using ClarkCodingChallenge.BusinessLogic;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.AddContact(contact);
            return RedirectToAction("ContactValidation", "Contacts");
        }

        public IActionResult AddContact()
        {
            return View();
        }

        public IActionResult ContactValidation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<string> GetContacts() 
        {
            var contacts = _contactService.GetContacts();
            return JsonConvert.SerializeObject(contacts);
        }
    }
}
