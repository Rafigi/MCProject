/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { CreateEventComponent } from './create-event.component';

let component: CreateEventComponent;
let fixture: ComponentFixture<CreateEventComponent>;

describe('CreateEvent component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ CreateEventComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(CreateEventComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});