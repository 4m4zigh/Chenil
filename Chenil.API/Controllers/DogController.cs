using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Chenil.API.Controllers
{
    [ApiController]
    [Route("Dog")]
    public class DogController : ControllerBase
    {
        static List<string> l = new List<string> { "Spike", "Black", "Jinx" };
        // Un controller est juste une classe qui défnit des URLS que je vais pouvoir contacter pour faire des actions côté serveur
        // Ces actions sont définies par des méthodes qui vont retourner un IActionResult

        // Pour être un controller d'API il doit hériter de ControllerBase

        // Il doit aussi avoir un attribut [ApiController]



        [HttpGet]
        public IActionResult Get([FromQuery] char letter) // Paramètre de query
        {
            return Ok(l.Where(c => c.Contains(letter)));
            // Ces informations vont être sérialisées automatiquement en JSON
        }



        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            // Si on trouve pas l'id -> Erreur 404
            try
            {
                return Ok(l[id]);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody][MaxLength(25)] string nom)
        {
            if (l.Contains(nom))
            {
                return BadRequest();
            }
            l.Add(nom);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody][MaxLength(25)] string nom)
        {
            try
            {
                l[id] = nom;
                // On peut retourner l'objet modifié ou on peut retourner juste Ok ou un NoContent
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (l[id] != null)
                {
                    l.RemoveAt(id);
                    // Mais peut se faire que si l'index existe
                }
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
