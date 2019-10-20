// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CreateRouteCardComponent } from './create-route-card.component';

let component: CreateRouteCardComponent;
let fixture: ComponentFixture<CreateRouteCardComponent>;

describe('create-route-card component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CreateRouteCardComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CreateRouteCardComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
