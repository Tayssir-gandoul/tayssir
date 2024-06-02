using QuickApp.Core.Models.Shop;

namespace QuickApp.Server.ViewModels.Shop
{
    public class BillCalculationMV
    {
        public class BillCalculationModel
        {
            public int Id { get; set; }
            public int NumeroFacture { get; set; }
            public string Reference { get; set; }
            public string Periode { get; set; }

            public int AncienIndexJour { get; set; }
            public int NouveauIndexJour { get; set; }
            public int PerteVideJour { get; set; }
            public int PerteChargeJour { get; set; }
            public int CoefficientMultiplicateurJour { get; set; }

            public int AncienIndexNuit { get; set; }
            public int NouveauIndexNuit { get; set; }
            public int PerteVideNuit { get; set; }
            public int PerteChargeNuit { get; set; }
            public int CoefficientMultiplicateurNuit { get; set; }

            public int AncienIndexPointe { get; set; }
            public int NouveauIndexPointe { get; set; }
            public int PerteVidePointe { get; set; }
            public int PerteChargePointe { get; set; }
            public int CoefficientMultiplicateurPointe { get; set; }

            public decimal PrixUnitaireJour { get; set; }
            public decimal PrixUnitaireNuit { get; set; }
            public decimal PrixUnitairePointe { get; set; }

            public decimal Bonification { get; set; }
            public decimal Penalite { get; set; }
            public decimal PrimePuissance { get; set; }
            public decimal LocationMateriel { get; set; }
            public decimal FraisIntervention { get; set; }
            public decimal FraisRelance { get; set; }
            public decimal FraisRetard { get; set; }
            public decimal TvaConsommation { get; set; }
            public decimal TvaRedevance { get; set; }
            public decimal ContributionRTT { get; set; }
            public decimal SurtaxeMunicipale { get; set; }
            public decimal ContributionGMG { get; set; }
            public int CompteurId { get; set; }
            public Compteur Compteur { get; set; }
        }

        public class BillCalculationResult
        {
            public decimal ConsommationJour { get; set; }
            public decimal ConsommationNuit { get; set; }
            public decimal ConsommationPointe { get; set; }
            public decimal MontantJour { get; set; }
            public decimal MontantNuit { get; set; }
            public decimal MontantPointe { get; set; }
            public decimal MontantTotal { get; set; }
            public decimal Total1 { get; set; }
            public decimal Total2 { get; set; }
            public decimal Total3 { get; set; }
            public decimal NetAPayer { get; set; }
        }
    }
}
