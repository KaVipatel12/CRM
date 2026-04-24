import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminChecklistComponent } from './admin-checklist.component';

describe('AdminChecklistComponent', () => {
  let component: AdminChecklistComponent;
  let fixture: ComponentFixture<AdminChecklistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminChecklistComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminChecklistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
