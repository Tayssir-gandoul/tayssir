import { Injectable } from '@angular/core';
import { BillCalculationModel } from '../components/calcul-mt/bill-calculation.model';
import { BillCalculationResult } from '../components/calcul-mt/bill-calculation-result.model';

@Injectable({
  providedIn: 'root',
})
export class BillCalculationService {
  calculateBill(result: BillCalculationResult): BillCalculationModel {
    const bill = new BillCalculationModel();

    bill.numeroFacture = result.numeroFacture;
    bill.reference = result.reference;
    bill.periode = result.periode;
    bill.consommationFacturerPhaseJour = result.consommationFacturerPhaseJour;
    bill.consommationFacturerPhaseNuit = result.consommationFacturerPhaseNuit;
    bill.consommationFacturerPhasePointe = result.consommationFacturerPhasePointe;
    bill.consommationFacturerTotal = result.consommationFacturerTotal;
    bill.montantPayerPhaseJour = result.montantPayerPhaseJour;
    bill.montantPayerPhaseNuit = result.montantPayerPhaseNuit;
    bill.montantPayerPhasePointe = result.montantPayerPhasePointe;
    bill.montantPayerTotal = result.montantPayerTotal;
    bill.total1 = result.total1;
    bill.total2 = result.total2;
    bill.total3 = result.total3;
    bill.netAPayer = result.netAPayer;

    // Ensure all properties are correctly assigned
  

    return bill;
  }
}
