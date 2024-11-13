import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LargeTabletComponent } from './large-tablet.component';

describe('LargeTabletComponent', () => {
  let component: LargeTabletComponent;
  let fixture: ComponentFixture<LargeTabletComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LargeTabletComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LargeTabletComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
