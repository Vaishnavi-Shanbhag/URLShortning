using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShortning.Data;
using URLShortning.Models;
using System.Text;

namespace URLShortning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UrlController(AppDbContext context)
        {
            _context = context;
        }

        // POST: /api/url/shorten
        [HttpPost("shorten")]
        public IActionResult ShortenUrl([FromBody] UrlRequest request)
        {
            if (!Uri.IsWellFormedUriString(request.OriginalUrl, UriKind.Absolute))
                return BadRequest("Invalid URL");

            var shortCode = GenerateShortCode();
            var urlMap = new UrlMapping
            {
                OriginalUrl = request.OriginalUrl,
                ShortCode = shortCode
            };

            _context.UrlMappings.Add(urlMap);
            _context.SaveChanges();

            var shortUrl = $"{Request.Scheme}://{Request.Host}/r/{shortCode}";
            return Ok(new { shortUrl });
        }

        // GET: /r/{shortCode}
        [HttpGet("/r/{shortCode}")]
        public IActionResult RedirectToOriginal(string shortCode)
        {
            var entry = _context.UrlMappings.FirstOrDefault(x => x.ShortCode == shortCode);
            if (entry == null)
                return NotFound("Short URL not found");

            return Redirect(entry.OriginalUrl);
        }

        private string GenerateShortCode()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public class UrlRequest
    {
        public string OriginalUrl { get; set; }
    }
}

