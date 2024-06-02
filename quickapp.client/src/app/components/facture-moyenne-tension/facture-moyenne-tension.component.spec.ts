import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FactureMoyenneTensionComponent } from './facture-moyenne-tension.component';

describe('FactureMoyenneTensionComponent', () => {
  let component: FactureMoyenneTensionComponent;
  let fixture: ComponentFixture<FactureMoyenneTensionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FactureMoyenneTensionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FactureMoyenneTensionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
