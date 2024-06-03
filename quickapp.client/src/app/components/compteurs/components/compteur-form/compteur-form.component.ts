import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Compteur } from '../../../../models/compteur.model';
import { CompteurService } from '../../../../services/compteur.service';

@Component({
  selector: 'app-compteur-form',
  templateUrl: './compteur-form.component.html',
  styleUrls: ['./compteur-form.component.scss']
})
export class CompteurFormComponent implements OnInit {
  compteur: Compteur = {
    id: 0, reference: 0, adresse: '', district: '',
    dateInstallation: new Date(), ancienIndex: 0, nouveauIndex: 0,
    ancienIndexJour: 0, ancienIndexNuit: 0, ancienIndexPointe: 0,
    nouveauIndexJour: 0, nouveauIndexNuit: 0, nouveauIndexPointe: 0
  };
  isEditMode = false;

  constructor(
    private compteurService: CompteurService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.isEditMode = true;
      this.compteurService.getCompteur(id).subscribe(data => {
        this.compteur = data;
      });
    }
  }

  onSubmit(): void {
    if (this.isEditMode) {
      this.compteurService.updateCompteur(this.compteur.id, this.compteur).subscribe(() => {
        this.router.navigate(['/compteurs']);
      });
    } else {
      this.compteurService.addCompteur(this.compteur).subscribe(() => {
        this.router.navigate(['/compteurs']);
      });
    }
  }
}
