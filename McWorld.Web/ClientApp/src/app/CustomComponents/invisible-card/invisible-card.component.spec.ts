/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { InvisibleCardComponent } from './invisible-card.component';

let component: InvisibleCardComponent;
let fixture: ComponentFixture<InvisibleCardComponent>;

describe('InvisibleCard component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ InvisibleCardComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(InvisibleCardComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});