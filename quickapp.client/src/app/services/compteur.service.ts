import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Compteur } from '../models/compteur.model';


@Injectable({
  providedIn: 'root'
})
export class CompteurService {
  private apiUrl = 'http://localhost:5000/api/compteur';

  constructor(private http: HttpClient) { }

  getCompteurs(): Observable<Compteur[]> {
    return this.http.get<Compteur[]>(this.apiUrl);
  }

  getCompteur(id: number): Observable<Compteur> {
    return this.http.get<Compteur>(`${this.apiUrl}/${id}`);
  }

  addCompteur(compteur: Compteur): Observable<Compteur> {
    return this.http.post<Compteur>(this.apiUrl, compteur);
  }

  updateCompteur(id: number, compteur: Compteur): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, compteur);
  }

  deleteCompteur(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
