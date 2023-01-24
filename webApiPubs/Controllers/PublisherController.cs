using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using webApiPubs.Models;
using Publisher = webApiPubs.Models.Publisher;

namespace webApiPubs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PubsContext context;

        public PublisherController(PubsContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> Get()
        {
            return context.Publishers.ToList();
        }

        [HttpGet("{ID}")]
        public ActionResult<Publisher> GetById(string ID)
        {
            Publisher publisher = (from e in context.Publishers
                                         where e.PubId == ID
                                         select e).SingleOrDefault();
            return publisher;
        }

        [HttpPost]
        public ActionResult<Publisher> Post(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Publishers.Add(publisher);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<Publisher> Put(string id, [FromBody] Publisher publisher)
        {
            if (id != publisher.PubId)
            {
                return BadRequest();
            }
            context.Entry(publisher).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Publisher> Delete(string id)
        {
            var publisher = (from c in context.Publishers
                                     where c.PubId == id
                                     select c).SingleOrDefault();

            if (publisher == null)
            {
                return NotFound();
            }
            context.Publishers.Remove(publisher);
            context.SaveChanges();
            return publisher;

        }
    }
}
