export interface Compteur {
    id: number;
    reference: number;
    adresse: string;
    district: string;
    dateInstallation: Date;
    ancienIndex: number;
    nouveauIndex: number;
    ancienIndexJour: number;
    ancienIndexNuit: number;
    ancienIndexPointe: number;
    nouveauIndexJour: number;
    nouveauIndexNuit: number;
    nouveauIndexPointe: number;
  }
  