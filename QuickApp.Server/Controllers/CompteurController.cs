// QuickApp.Server/Controllers/CompteurController.cs
using Microsoft.AspNetCore.Mvc;
using QuickApp.Core.Models.Shop;
using QuickApp.Core.Services.Shop;
using QuickApp.Core.Services.Shop.Interfaces;
using System.Collections.Generic;

namespace QuickApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteurController : ControllerBase
    {
        private readonly ICompteurService _compteurService;

        public CompteurController(ICompteurService compteurService)
        {
            _compteurService = compteurService;
        }

        [HttpGet]
        public IEnumerable<Compteur> GetCompteurs()
        {
            return _compteurService.GetAllCompteurs();
        }

        [HttpGet("{id}")]
        public ActionResult<Compteur> GetCompteur(int id)
        {
            var compteur = _compteurService.GetCompteurById(id);
            if (compteur == null)
            {
                return NotFound();
            }
            return compteur;
        }

        [HttpPost]
        public ActionResult<Compteur> AddCompteur(Compteur compteur)
        {
            _compteurService.AddCompteur(compteur);
            return CreatedAtAction(nameof(GetCompteur), new { id = compteur.Id }, compteur);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompteur(int id, Compteur compteur)
        {
            if (id != compteur.Id)
            {
                return BadRequest();
            }

            _compteurService.UpdateCompteur(compteur);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompteur(int id)
        {
            _compteurService.DeleteCompteur(id);
            return NoContent();
        }
    }
}
