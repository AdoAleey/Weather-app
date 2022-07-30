using Library.WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VremenskaPrognozaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<VremenskaPrognozaController> _logic;

        public VremenskaPrognozaController(ILogger<VremenskaPrognozaController> log)
        {
            _logic = log;
        }

        [HttpGet(Name = "DohvatiVremenskuPrognozu")]
        public IEnumerable<VremenskaPrognoza> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new VremenskaPrognoza
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}