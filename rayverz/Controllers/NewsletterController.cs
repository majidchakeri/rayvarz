using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rayverz.Data.DTOs.Newsletters;
using rayverz.Services.Newsletters;

namespace rayverz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterServices _newsletterServices;

        public NewsletterController(INewsletterServices newsletterServices)
        {
            _newsletterServices = newsletterServices;
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddNewsLetter([FromBody] NewsletterAddDTO newsletterAddDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _newsletterServices.Create(newsletterAddDTO);

            return CreatedAtAction(nameof(GetNewsLetter), new {Id = id}, id);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetNewsLetter([FromQuery] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newsLetter = await _newsletterServices.Read(id);
            if (newsLetter == null) return NotFound();

            return Ok(newsLetter);
        }

        [HttpPost, Route("send"),Authorize]
        public async Task<IActionResult> GetNewsLetter([FromBody] SendNewsletterDTO sendNewsletterDTO)
        {
            await _newsletterServices.SendNewsletter(sendNewsletterDTO.NewsletterId, sendNewsletterDTO.UserIds);
            
            return Ok();
        }
    }
}
