using QuickApp.Core.Infrastructure;
using QuickApp.Core.Models.Shop;
using QuickApp.Core.Services.Shop.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace QuickApp.Core.Services.Shop
{
    public class BillCalculationService : IBillCalculationService
    {
        private readonly ApplicationDbContext _context;

        public BillCalculationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public BillCalculationResult BillCalculation (BillCalculationModel model, int count)
        {
            var topCompteurs = GetTopActiveCompteurs(count);

            foreach (var compteur in topCompteurs)
            {
                var consommationJour = CalculateConsumption(compteur.AncienIndexJour, model.NouveauIndexJour, model.PerteVideJour, model.PerteChargeJour, model.CoefficientMultiplicateurJour);
                var consommationNuit = CalculateConsumption(compteur.AncienIndexNuit, model.NouveauIndexNuit, model.PerteVideNuit, model.PerteChargeNuit, model.CoefficientMultiplicateurNuit);
                var consommationPointe = CalculateConsumption(compteur.AncienIndexPointe, model.NouveauIndexPointe, model.PerteVidePointe, model.PerteChargePointe, model.CoefficientMultiplicateurPointe);

                var montantJour = CalculateMontantPayer(consommationJour, model.PrixUnitaireJour);
                var montantNuit = CalculateMontantPayer(consommationNuit, model.PrixUnitaireNuit);
                var montantPointe = CalculateMontantPayer(consommationPointe, model.PrixUnitairePointe);

                var montantTotal = montantJour + montantNuit + montantPointe;

                var total1 = CalculateTotal1(montantTotal, model.Bonification, model.Penalite);
                var total2 = CalculateTotal2(model.PrimePuissance, model.LocationMateriel, model.FraisIntervention, model.FraisRelance, model.FraisRetard);
                var total3 = CalculateTotal3(model.TvaConsommation, model.TvaRedevance, model.ContributionRTT, model.SurtaxeMunicipale);

                var netAPayer = CalculateNetAPayer(total1, total2, total3, model.ContributionGMG);

                return new BillCalculationResult
                {
                    ConsommationJour = consommationJour,
                    ConsommationNuit = consommationNuit,
                    ConsommationPointe = consommationPointe,
                    MontantJour = montantJour,
                    MontantNuit = montantNuit,
                    MontantPointe = montantPointe,
                    MontantTotal = montantTotal,
                    Total1 = total1,
                    Total2 = total2,
                    Total3 = total3,
                    NetAPayer = netAPayer
                };
            }

            return null; // Gérer ce cas en conséquence
        }

        private IEnumerable<Compteur> GetTopActiveCompteurs(int count)
        {
            return _context.Compteurs
                .OrderByDescending(c => c.Orders.Count)
                .Take(count)
                .ToList();
        }

        private decimal CalculateConsumption(int ancienIndex, int nouveauIndex, int perteVide, int perteCharge, int coefficientMultiplicateur)
        {
            return (nouveauIndex - ancienIndex + perteVide + perteCharge) * coefficientMultiplicateur;
        }

        private decimal CalculateMontantPayer(decimal consommation, decimal prixUnitaire)
        {
            return consommation * prixUnitaire;
        }

        private decimal CalculateTotal1(decimal montantTotal, decimal bonification, decimal penalite)
        {
            return montantTotal + bonification - penalite;
        }

        private decimal CalculateTotal2(decimal primePuissance, decimal locationMateriel, decimal fraisIntervention, decimal fraisRelance, decimal fraisRetard)
        {
            return primePuissance + locationMateriel + fraisIntervention + fraisRelance + fraisRetard;
        }

        private decimal CalculateTotal3(decimal tvaConsommation, decimal tvaRedevance, decimal contributionRTT, decimal surtaxeMunicipale)
        {
            return tvaConsommation + tvaRedevance + contributionRTT + surtaxeMunicipale;
        }

        private decimal CalculateNetAPayer(decimal total1, decimal total2, decimal total3, decimal contributionGMG)
        {
            return total1 + total2 + total3 + contributionGMG;
        }

        public decimal CalculateNetAPayer(decimal total1, decimal total2, decimal total3, object contributionGMG)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotal3(object tvaConsommation, object tvaRedevance, object contributionRTT, object surtaxeMunicipale)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotal1(decimal montantTotal, object bonification, object penalite)
        {
            throw new NotImplementedException();
        }
    }
}






