using ElementsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElementsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeriodicElementsController : ControllerBase
    {
        private readonly ILogger<PeriodicElementsController> _logger;
        private static readonly List<PeriodicElement> _elements = new()
        {
            new() { Position = 1, Name = "Hydrogen", Weight = 1.0079, Symbol = "H" },
            new() { Position = 2, Name = "Helium", Weight = 4.0026, Symbol = "He" },
            new() { Position = 3, Name = "Lithium", Weight = 6.941, Symbol = "Li" },
            new() { Position = 4, Name = "Beryllium", Weight = 9.0122, Symbol = "Be" },
            new() { Position = 5, Name = "Boron", Weight = 10.811, Symbol = "B" },
            new() { Position = 6, Name = "Carbon", Weight = 12.0107, Symbol = "C" },
            new() { Position = 7, Name = "Nitrogen", Weight = 14.0067, Symbol = "N" },
            new() { Position = 8, Name = "Oxygen", Weight = 15.9994, Symbol = "O" },
            new() { Position = 9, Name = "Fluorine", Weight = 18.9984, Symbol = "F" },
            new() { Position = 10, Name = "Neon", Weight = 20.1797, Symbol = "Ne" }
        };

        public PeriodicElementsController(ILogger<PeriodicElementsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PeriodicElement>> GetAll()
        {
            _logger.LogInformation("Retrieving all periodic elements");
            var activeElements = _elements.Where(e => e.IsArchived == false);
            return Ok(activeElements);
        }

        [HttpGet("{position}")]
        public ActionResult<PeriodicElement> Get(int position)
        {
            _logger.LogInformation("Retrieving element with position: {Position}", position);
            var element = _elements.FirstOrDefault(e => e.Position == position);

            if (element == null || element.IsArchived == true)
            {
                return NotFound();
            }

            return Ok(element);
        }

        [HttpPost]
        public ActionResult<PeriodicElement> Create(PeriodicElement element)
        {
            _logger.LogInformation("Creating new element: {Symbol}", element.Symbol);

            if (_elements.Any(e => e.Position == element.Position))
            {
                return Conflict("An element with this position already exists");
            }

            element.IsArchived = false;
            _elements.Add(element);
            return Ok(element);
        }

        [HttpPut("{position}")]
        public ActionResult<PeriodicElement> Update(int position, PeriodicElement element)
        {
            _logger.LogInformation("Updating element at position: {Position}", position);

            var existingElement = _elements.FirstOrDefault(e => e.Position == position);
            if (existingElement == null)
            {
                return NotFound();
            }

            var index = _elements.IndexOf(existingElement);
            element.Position = position; // Ensure position matches route
            _elements[index] = element;

            return Ok(element);
        }

        [HttpDelete("{position}")]
        public IActionResult Delete(int position)
        {
            _logger.LogInformation("Deleting element at position: {Position}", position);

            var element = _elements.FirstOrDefault(e => e.Position == position);
            if (element == null)
            {
                return NotFound();
            }

            var index = _elements.IndexOf(element);
            element.IsArchived = true;
            _elements[index] = element;
            return NoContent();
        }
    }
}