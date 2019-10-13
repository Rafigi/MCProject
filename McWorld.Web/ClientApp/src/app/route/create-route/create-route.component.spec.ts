/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CreateRouteComponent } from './create-route.component';

let component: CreateRouteComponent;
let fixture: ComponentFixture<CreateRouteComponent>;

describe('CreateRoute component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CreateRouteComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CreateRouteComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});