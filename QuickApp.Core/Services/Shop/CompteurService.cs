// QuickApp.Core/Services/Shop/CompteurService.cs
using QuickApp.Core.Infrastructure;
using QuickApp.Core.Models.Shop;
using QuickApp.Core.Services.Shop.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace QuickApp.Core.Services.Shop
{
    public class CompteurService : ICompteurService
    {
        private readonly ApplicationDbContext _context;

        public CompteurService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Compteur> GetAllCompteurs()
        {
            return _context.Compteurs.ToList();
        }

        public Compteur GetCompteurById(int id)
        {
            return _context.Compteurs.Find(id);
        }

        public void AddCompteur(Compteur compteur)
        {
            _context.Compteurs.Add(compteur);
            _context.SaveChanges();
        }

        public void UpdateCompteur(Compteur compteur)
        {
            _context.Compteurs.Update(compteur);
            _context.SaveChanges();
        }

        public void DeleteCompteur(int id)
        {
            var compteur = _context.Compteurs.Find(id);
            if (compteur != null)
            {
                _context.Compteurs.Remove(compteur);
                _context.SaveChanges();
            }
        }
    }
}
