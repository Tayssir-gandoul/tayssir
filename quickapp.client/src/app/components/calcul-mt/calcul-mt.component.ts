import { Component } from '@angular/core';
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
   
  
  }
  

 


