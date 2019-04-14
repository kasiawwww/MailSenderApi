using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailSenderApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailSenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly MailContext db;

        public MailController (MailContext db)
        {
            this.db = db;
        }
        // GET api/values
        [HttpGet]
        public IActionResult GetMails()
        {
            try
            {
                return Ok(db.Mails.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetMails(int id)
        {
            try
            {
                var mail = db.Mails.SingleOrDefault(a => a.Id == id);
                if (mail == null)
                {
                    return NotFound("Nie znaleziono.");
                }
                return Ok(mail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // POST api/values
        [HttpPost]
        public IActionResult AddMails(Mail mail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Mails.Add(mail);
                    db.SaveChanges();
                    return CreatedAtAction(nameof(GetMails), new { id = mail.Id }, mail); 
                }
                return BadRequest("Błedne dane wejsciowe");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
