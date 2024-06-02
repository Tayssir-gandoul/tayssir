

using QuickApp.Core.Models.Shop;

namespace QuickApp.Core.Services.Shop
{
    public interface ICompteurService
    {
        IEnumerable<Compteur> GetTopActiveCompteurs(int count);
        IEnumerable<Compteur> GetAllCompteursData();
    }
}
