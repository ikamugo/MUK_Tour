import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MapServiceProvidersComponent } from './map-service-providers.component';

describe('MapServiceProvidersComponent', () => {
  let component: MapServiceProvidersComponent;
  let fixture: ComponentFixture<MapServiceProvidersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MapServiceProvidersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MapServiceProvidersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
