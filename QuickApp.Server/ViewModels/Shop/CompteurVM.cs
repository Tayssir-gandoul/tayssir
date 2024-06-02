// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------
using FluentValidation;
using QuickApp.Core.Models.Shop;
using System;
using System.Collections.Generic;

namespace QuickApp.Server.ViewModels.Shop
{
    public class CompteurVM : CompteurVMBase
    {
    }

    public class CompteurVMValidator : AbstractValidator<CompteurVM>
    {
        public CompteurVMValidator()
        {
            RuleFor(compteur => compteur.Id).NotEmpty().WithMessage("L'identifiant est obligatoire.");
            RuleFor(compteur => compteur.Reference).NotEmpty().WithMessage("La référence est obligatoire.");
            RuleFor(compteur => compteur.NouveauIndex).NotEmpty().WithMessage("Le nouveau index est obligatoire.");
            RuleFor(compteur => compteur.AncienIndex).NotEmpty().WithMessage("L'ancien index est obligatoire.");
            RuleFor(compteur => compteur.DateInstallation).NotEmpty().WithMessage("La date d'installation est obligatoire.");
            RuleFor(compteur => compteur.Adresse).NotEmpty().WithMessage("L'adresse est obligatoire.");
            RuleFor(compteur => compteur.District).NotEmpty().WithMessage("Le district est obligatoire.");
        }
    }
}
