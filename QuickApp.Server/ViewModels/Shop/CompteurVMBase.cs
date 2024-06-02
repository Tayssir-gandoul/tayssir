using QuickApp.Core.Models.Shop;
// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------
namespace QuickApp.Server.ViewModels.Shop
{
    public class CompteurVMBase
    {
        public required string Adresse { get; set; }
        public int AncienIndex { get; set; }
        public ICollection<BillCalculationModel> BillCalculations { get; set; }
        public DateTime DateInstallation { get; set; }
        public required string District { get; set; }
        public int Id { get; set; }
        public int NouveauIndex { get; set; }
        public int Reference { get; set; }
    }
}