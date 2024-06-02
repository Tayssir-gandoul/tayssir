import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FactureBaseTensionComponent } from './facture-base-tension.component';

describe('FactureBaseTensionComponent', () => {
  let component: FactureBaseTensionComponent;
  let fixture: ComponentFixture<FactureBaseTensionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FactureBaseTensionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FactureBaseTensionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
