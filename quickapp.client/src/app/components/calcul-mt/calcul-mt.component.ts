import { Component } from '@angular/core';
import { BillCalculationResult } from './bill-calculation-result.model';
import { trigger, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-calcul-mt',
  templateUrl: './calcul-mt.component.html',
  styleUrls: ['./calcul-mt.component.scss'],
  animations: [
    trigger('fadeInOut', [
      transition(':enter', [
        style({ opacity: 0 }),
        animate('0.5s ease-in-out', style({ opacity: 1 }))
      ]),
      transition(':leave', [
        animate('0.5s ease-in-out', style({ opacity: 0 }))
      ])
    ])
  ]
})


  export class CalculMtComponent {
    billCalculationResult: any = {};
  
    bill = {
      ancienIndexJour: 0,
    nouveauIndexJour: 0,
    perteVideJour: 0,
    perteChargeJour: 0,
    coefficientMultiplicateurJour: 0,
    ancienIndexNuit: 0,
    nouveauIndexNuit: 0,
    perteVideNuit: 0,
    perteChargeNuit: 0,
    coefficientMultiplicateurNuit: 0,
    ancienIndexPointe: 0,
    nouveauIndexPointe: 0,
    perteVidePointe: 0,
    perteChargePointe: 0,
    coefficientMultiplicateurPointe: 0,
    contributionGMG: 0, 
    surtaxeMunicipale: 0,
    contributionRTT:0,
    tvaRedevance:0,
    tvaConsommation:0,
    fraisRetard:0,
    fraisRelance:0,
    fraisIntervention:0,
    locationMateriel:0,
    primePuissance:0,
    montantPayerPhasePointe:0,
    prixUnitairePointe:0,
    total1:0,
    penalite:0,
    bonification:0,
    montantPayerTotal:0,
    montantPayerPhaseNuit:0,
    prixUnitaireNuit:0,
    montantPayerPhaseJour:0,
    prixUnitaireJour:0,
    consommationFacturerTotal:0,
    consommationFacturerPhasePointe:0,
    consommationFacturerPhaseNuit:0,
    consommationFacturerPhaseJour:0,

    };
  
    total2: number = 0;
    total3: number = 0;
  
    constructor() { }
  
    calculateBill(billCalculationResult: any): void {
      // Logique de calcul ici
      console.log("Résultats du calcul :", billCalculationResult);
      // Autres opérations selon vos besoins
    }
  
  }
  

 


