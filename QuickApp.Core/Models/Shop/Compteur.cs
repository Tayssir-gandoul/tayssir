// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using System.ComponentModel.DataAnnotations;

namespace QuickApp.Core.Models.Shop
{
    public class Compteur
    {
        public int Id { get; set; }
        public int Reference { get; set; }
        public string Adresse { get; set; }
        public string District { get; set; }
        public DateTime DateInstallation { get; set; }
        public int AncienIndex { get; set; }
        public int NouveauIndex { get; set; }
        public int AncienIndexJour { get; set; }
        public int AncienIndexNuit { get; set; }
        public int AncienIndexPointe { get; set; }
        public int NouveauIndexJour { get; set; }
        public int NouveauIndexNuit { get; set; }
        public int NouveauIndexPointe { get; set; }
    }
}

