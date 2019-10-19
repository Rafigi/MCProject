/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { EditInformationModalComponent } from './edit-information-modal.component';

let component: EditInformationModalComponent;
let fixture: ComponentFixture<EditInformationModalComponent>;

describe('Edit-Information-Modal component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ EditInformationModalComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(EditInformationModalComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});