export class BillCalculationResult {
    numeroFacture: string = '';
    reference: number = 0;
    periode: string = '';
    consommationFacturerPhaseJour: number = 0;
    consommationFacturerPhaseNuit: number = 0;
    consommationFacturerPhasePointe: number = 0;
    consommationFacturerTotal: number = 0;
    montantPayerPhaseJour: number = 0;
    montantPayerPhaseNuit: number = 0;
    montantPayerPhasePointe: number = 0;
    montantPayerTotal: number = 0;
    total1: number = 0;
    total2: number = 0;
    total3: number = 0;
    netAPayer: number = 0;
  
    consommationJour: number = 0;  // Add this if it's a required property
    // Add any other properties as necessary
  }
  