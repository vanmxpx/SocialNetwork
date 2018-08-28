
import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SearchExpanderComponent } from './searchExpander.component';

describe('HeaderComponent', () => {
  let component: SearchExpanderComponent;
  let fixture: ComponentFixture<SearchExpanderComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      imports: [MatSidenavModule],
      declarations: [SearchExpanderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchExpanderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
