// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Infrastructure;
using QuickApp.Core.Models.Shop;

namespace QuickApp.Core.Services.Shop
{
    public class CompteurService : ICompteurService
    {
        ApplicationDbContext _context;

        // Constructor
        public CompteurService(ApplicationDbContext dbContext, ApplicationDbContext context)
        {
            _context = dbContext;
            _context = context;
        }

        // Here is your missing method .. you need to implement it
        public IEnumerable<Compteur> GetTopActiveCompteurs(int count)
        {
            // You must replace the implementation here with our own logic
            throw new NotImplementedException();
        }

        public IEnumerable<Compteur> GetAllCompteursData()
        {
            return _context.Compteurs
               
                .AsSingleQuery()
                .OrderBy(c => c.Reference)
                .ToList();
        }
    }
}