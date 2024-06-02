import { Component } from '@angular/core';
import { trigger, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-compteurs',
  templateUrl: './compteurs.component.html',
  styleUrls: ['./compteurs.component.scss'],
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
export class CompteursComponent {
  compteurs: any[] = [];
  compteursFiltres: any[] = [];
  rechercheReference: string = '';
  nouveauCompteur = { reference: 0, nouveauIndex: 0, ancienIndex: 0, dateInstallation: new Date(), adresse: '', district: '' };
  afficherFormulaire: boolean = false;

  constructor() {
    // Initialisation des compteurs pour le test
    this.compteurs = [
      { reference: 123, nouveauIndex: 500, ancienIndex: 450, dateInstallation: new Date(), adresse: '123 Rue A', district: 'District 1' },
      { reference: 456, nouveauIndex: 600, ancienIndex: 550, dateInstallation: new Date(), adresse: '456 Rue B', district: 'District 2' }
    ];
    this.compteursFiltres = this.compteurs;
  }

  ajouterCompteur() {
    this.compteurs.push({ ...this.nouveauCompteur, id: this.compteurs.length + 1 });
    this.compteursFiltres = this.compteurs;
    this.nouveauCompteur = { reference: 0, nouveauIndex: 0, ancienIndex: 0, dateInstallation: new Date(), adresse: '', district: '' };
    this.afficherFormulaire = false;
    alert('Compteur ajouté avec succès !');
  }

  modifierCompteur(compteur: any) {
    this.nouveauCompteur = { ...compteur };
    this.afficherFormulaire = true;
  }

  validerModification() {
    const index = this.compteurs.findIndex(c => c.reference === this.nouveauCompteur.reference);
    if (index !== -1) {
      this.compteurs[index] = { ...this.nouveauCompteur };
    }
    this.nouveauCompteur = { reference: 0, nouveauIndex: 0, ancienIndex: 0, dateInstallation: new Date(), adresse: '', district: '' };
    this.afficherFormulaire = false;
  }

  supprimerCompteur(index: number) {
    this.compteurs.splice(index, 1);
    this.compteursFiltres = this.compteurs;
  }

  afficherTousLesCompteurs() {
    console.log(this.compteurs);
  }

  afficherFormulaireAjout() {
    this.afficherFormulaire = true;
  }

  filtrerCompteurs() {
    this.compteursFiltres = this.compteurs.filter(compteur => 
      compteur.reference.toString().includes(this.rechercheReference)
    );
  }
}



