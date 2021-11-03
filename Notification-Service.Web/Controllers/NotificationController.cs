using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notification_Service.Data;
using Notification_Service.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notification_Service.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotificationController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<NotificationController>
        [HttpGet]
        public ActionResult<List<NotificationDto>> GetNotifications()
        {
            var convertedlist = _context.Notification.Select(x => NotificationDto.FromEntity(x)).ToList();


            return StatusCode(200, convertedlist);
        }

        // GET api/<NotificationController>/2ef23f2f-23fr2fe2-4cf2f2f
        [HttpGet("{id}")]
        public ActionResult<Notification> Get(Guid id)
        {
            return StatusCode(200, _context.Notification.Find(id));
        }

        // POST api/<NotificationController>
        [HttpPost]
        public ActionResult<Notification> Post([FromBody] NotificationDto Notificationdto)
        {
            _context.Notification.Add(Notificationdto.ToEntity());
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
                //return StatusCode(500);

            }
            return StatusCode(201, Notificationdto);
        }

        // TODO: implement patch service
        // PUT api/<NotificationController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] NotificationDto value)
        {
        }
        // TODO: implement delete sequence using rabitmq.
        // DELETE api/<NotificationController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
        
    }
}
