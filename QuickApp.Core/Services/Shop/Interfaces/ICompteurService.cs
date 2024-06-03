// QuickApp.Core/Services/Shop/Interfaces/ICompteurService.cs
using QuickApp.Core.Models.Shop;
using System.Collections.Generic;

namespace QuickApp.Core.Services.Shop.Interfaces
{
    public interface ICompteurService
    {
        IEnumerable<Compteur> GetAllCompteurs();
        Compteur GetCompteurById(int id);
        void AddCompteur(Compteur compteur);
        void UpdateCompteur(Compteur compteur);
        void DeleteCompteur(int id);
    }
}
