using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static int count = 0;
        private static List<Event> events = new List<Event> { new Event { Id = count++, Title = "אירוע 1", Start = new DateOnly(2023,9,20), End = new DateOnly() },
            new Event{ Id = count++, Title = "אירוע 2", Start = new DateOnly(2023,9,21), End = new DateOnly() },
            new Event{ Id = count++, Title = "אירוע 3", Start = new DateOnly(2023,9,21), End = new DateOnly() }};


        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event eve)
        {
            events.Add(new Event { Id = count++, Title = eve.Title, Start = eve.Start, End = eve.End });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eve)
        {
            var a = events.FindIndex(x => x.Id == id);
            events[a].Start = eve.Start;
            events[a].End = eve.End;
            events[a].Title = eve.Title;

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(x => x.Id == id);
            events.Remove(eve);
        }
    }
}
