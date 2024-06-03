import { Component, OnInit } from '@angular/core';

import { Compteur } from '../../../../models/compteur.model';
import { CompteurService } from '../../../../services/compteur.service';



@Component({
  selector: 'app-compteur-list',
  templateUrl: './compteur-list.component.html',
  styleUrls: ['./compteur-list.component.scss']
})
export class CompteurListComponent implements OnInit {
  compteurs: Compteur[] = []; // Initialiser en tant que tableau vide

  constructor(private compteurService: CompteurService) { }

  ngOnInit(): void {
    this.compteurService.getCompteurs().subscribe(data => {
      this.compteurs = data;
    });
  }

  deleteCompteur(id: number): void {
    this.compteurService.deleteCompteur(id).subscribe(() => {
      this.compteurs = this.compteurs.filter(c => c.id !== id);
    });
  }
}
