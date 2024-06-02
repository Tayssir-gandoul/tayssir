

import { NgModule, Injectable } from '@angular/core';
import { RouterModule, Routes, DefaultUrlSerializer, UrlSerializer, UrlTree, TitleStrategy } from '@angular/router';

import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { ProductsComponent } from './components/products/products.component';
import { OrdersComponent } from './components/orders/orders.component';
import { SettingsComponent } from './components/settings/settings.component';

import { NotFoundComponent } from './components/not-found/not-found.component';
import { AppTitleService } from './services/app-title.service';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard';
import { Utilities } from './services/utilities';
import { CompteursComponent } from './components/compteurs/compteurs.component';
import { FactureMoyenneTensionComponent } from './components/facture-moyenne-tension/facture-moyenne-tension.component';
import { FactureBaseTensionComponent } from './components/facture-base-tension/facture-base-tension.component';
import { CalculMtComponent } from './components/calcul-mt/calcul-mt.component';

@Injectable()
export class LowerCaseUrlSerializer extends DefaultUrlSerializer {
  override parse(url: string): UrlTree {
    const possibleSeparators = /[?;#]/;
    const indexOfSeparator = url.search(possibleSeparators);
    let processedUrl: string;

    if (indexOfSeparator > -1) {
      const separator = url.charAt(indexOfSeparator);
      const urlParts = Utilities.splitInTwo(url, separator);
      urlParts.firstPart = urlParts.firstPart.toLowerCase();

      processedUrl = urlParts.firstPart + separator + urlParts.secondPart;
    } else {
      processedUrl = url.toLowerCase();
    }

    return super.parse(processedUrl);
  }
}

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard], title: 'Home' },
  { path: 'login', component: LoginComponent, title: 'Login' },
  {path:'facture-moyenne-tension',component:FactureMoyenneTensionComponent,canActivate:[AuthGuard], title:'Gestion Facture Moyenne Tension'},
  {path:'facture-base-tension',component:FactureBaseTensionComponent,canActivate:[AuthGuard], title:'Facture Base Tension'},
  {path:'calcul-mt',component:CalculMtComponent,canActivate:[AuthGuard], title:'Calcul Facture Moyenne Tension '},
  { path: 'compteurs', component: CompteursComponent, canActivate: [AuthGuard], title: 'Compteures' },
  { path: 'products', component: ProductsComponent, canActivate: [AuthGuard], title: 'Products' },
  { path: 'orders', component: OrdersComponent, canActivate: [AuthGuard], title: 'Orders' },
  { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard], title: 'Settings' },
  { path: 'home', redirectTo: '/', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent, title: 'Page Not Found' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [
    AuthService,
    { provide: TitleStrategy, useClass: AppTitleService },
    { provide: UrlSerializer, useClass: LowerCaseUrlSerializer }]
})
export class AppRoutingModule { }
