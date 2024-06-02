// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using System.ComponentModel.DataAnnotations;

namespace QuickApp.Core.Models.Shop
{
    public class Compteur : BaseEntity
    {
        [Required(ErrorMessage = "L'identifiant est obligatoire.")]
        public new int Id { get; set; }

        [Required(ErrorMessage = "La référence est obligatoire.")]
        public int  Reference { get; set; }

        [Required(ErrorMessage = "Le nouveau index est obligatoire.")]
        public int NouveauIndex { get; set; }

        [Required(ErrorMessage = "L'ancien index est obligatoire.")]
        public int AncienIndex { get; set; }

        [Required(ErrorMessage = "La date d'installation est obligatoire.")]
        public DateTime DateInstallation { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Le district est obligatoire.")]
        public string District { get; set; }
        public int AncienIndexJour { get; set; }
        public int AncienIndexNuit { get; set; }
        public int AncienIndexPointe { get; set; }
        public ICollection<BillCalculationModel> BillCalculations { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
