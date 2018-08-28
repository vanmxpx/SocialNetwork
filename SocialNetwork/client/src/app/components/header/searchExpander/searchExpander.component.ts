import { Component, OnInit, Input } from '@angular/core';
import { ThemePalette } from '@angular/material/core';

@Component({
    selector: 'app-search-expander',
    templateUrl: './searchExpander.component.html',
    styleUrls: ['./searchExpander.component.scss']
})

export class SearchExpanderComponent {
    value: string;
    @Input() private color: ThemePalette;
    constructor() { }
}
