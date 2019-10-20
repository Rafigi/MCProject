// <reference path="../../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { BtnMcWorldComponent } from './btn-mc-world.component';

let component: BtnMcWorldComponent;
let fixture: ComponentFixture<BtnMcWorldComponent>;

describe('BtnMcWorld component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ BtnMcWorldComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(BtnMcWorldComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
