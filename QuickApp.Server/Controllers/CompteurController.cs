// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickApp.Core.Models.Shop;
using QuickApp.Core.Services;
using QuickApp.Core.Services.Shop;
using QuickApp.Server.Services.Email;
using QuickApp.Server.ViewModels.Shop;

namespace QuickApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteurController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CompteursController : ControllerBase
        {
            private static List<Compteur> _compteurs = new List<Compteur>
        {
            new Compteur { Id = 1, Reference = 100, NouveauIndex = 100, AncienIndex = 50, DateInstallation = DateTime.Now, Adresse = "Adresse 1", District = "District 1" }
        };

            [HttpGet]
            public ActionResult<IEnumerable<Compteur>> Get()
            {
                return _compteurs;
            }

            [HttpPost]
            public ActionResult<Compteur> Post(Compteur compteur)
            {
                compteur.Id = _compteurs.Count + 1;
                _compteurs.Add(compteur);
                return compteur;
            }

            [HttpPut("{id}")]
            public ActionResult<Compteur> Put(int id, Compteur compteur)
            {
                var index = _compteurs.FindIndex(c => c.Id == id);
                if (index < 0)
                {
                    return NotFound();
                }
                _compteurs[index] = compteur;
                return compteur;
            }

            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                var compteur = _compteurs.Find(c => c.Id == id);
                if (compteur == null)
                {
                    return NotFound();
                }
                _compteurs.Remove(compteur);
                return NoContent();
            }
        }
    }
}
