import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompteurListComponent } from './compteur-list.component';

describe('CompteurListComponent', () => {
  let component: CompteurListComponent;
  let fixture: ComponentFixture<CompteurListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CompteurListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompteurListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
