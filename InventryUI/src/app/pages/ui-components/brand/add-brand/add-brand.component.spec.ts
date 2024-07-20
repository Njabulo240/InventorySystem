/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddBrandComponent } from './add-brand.component';

describe('AddBrandComponent', () => {
  let component: AddBrandComponent;
  let fixture: ComponentFixture<AddBrandComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddBrandComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBrandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
