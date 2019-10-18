/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CreateEventCardComponent } from './create-event-card.component';

let component: CreateEventCardComponent;
let fixture: ComponentFixture<CreateEventCardComponent>;

describe('create-event-card component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CreateEventCardComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CreateEventCardComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});