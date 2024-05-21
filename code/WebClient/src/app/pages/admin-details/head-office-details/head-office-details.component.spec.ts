import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HeadOfficeDetailsComponent } from './head-office-details.component';

describe('HeadOfficeDetailsComponent', () => {
  let component: HeadOfficeDetailsComponent;
  let fixture: ComponentFixture<HeadOfficeDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HeadOfficeDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HeadOfficeDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
