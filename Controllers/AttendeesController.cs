using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RepasoPC1SebitasJoaco.Data;
using RepasoPC1SebitasJoaco.DTO;
using RepasoPC1SebitasJoaco.Interfaces;

namespace RepasoPC1SebitasJoaco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly IAttendeesRepository _attendeesRepository;

        public AttendeesController(IAttendeesRepository attendeesRepository)
        {
            _attendeesRepository = attendeesRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var attendees = await _attendeesRepository.GetAll();
            return Ok(attendees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var attendees = await _attendeesRepository.GetOne(id);
            if (attendees == null) return NotFound();
            return Ok(attendees);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Attendees attendees)
        {
           int attendeeId = await _attendeesRepository.Insert(attendees);
            return Ok(attendeeId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _attendeesRepository.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }
    }
}
