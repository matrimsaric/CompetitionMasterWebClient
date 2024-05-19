import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HdrNavComponent } from './hdr-nav.component';

describe('HdrNavComponent', () => {
  let component: HdrNavComponent;
  let fixture: ComponentFixture<HdrNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HdrNavComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HdrNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
