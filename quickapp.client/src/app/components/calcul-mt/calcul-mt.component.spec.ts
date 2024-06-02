import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculMtComponent } from './calcul-mt.component';

describe('CalculMtComponent', () => {
  let component: CalculMtComponent;
  let fixture: ComponentFixture<CalculMtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalculMtComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CalculMtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
