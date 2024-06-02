export class BillCalculationModel {
  [x: string]: any;
    numeroFacture: string;
    reference: number;
    periode: string;
    consommationFacturerPhaseJour: number;
    consommationFacturerPhaseNuit: number;
    consommationFacturerPhasePointe: number;
    consommationFacturerTotal: number;
    montantPayerPhaseJour: number;
    montantPayerPhaseNuit: number;
    montantPayerPhasePointe: number;
    montantPayerTotal: number;
    total1: number;
    total2: number;
    total3: number;
    netAPayer: number;


    constructor() {
      this.numeroFacture = '';
      this.reference = 0;
      this.periode = '';
      this.consommationFacturerPhaseJour = 0;
      this.consommationFacturerPhaseNuit = 0;
      this.consommationFacturerPhasePointe = 0;
      this.consommationFacturerTotal = 0;
      this.montantPayerPhaseJour = 0;
      this.montantPayerPhaseNuit = 0;
      this.montantPayerPhasePointe = 0;
      this.montantPayerTotal = 0;
      this.total1 = 0;
      this.total2 = 0;
      this.total3 = 0;
      this.netAPayer = 0;
    }
  }
  
 