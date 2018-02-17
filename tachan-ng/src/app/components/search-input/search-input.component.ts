import {Component, OnInit, EventEmitter, Output, Input} from '@angular/core';
import {FormControl} from '@angular/forms';
import {debounceTime} from 'rxjs/operators/debounceTime';

@Component({selector: 'tcn-search-input', templateUrl: './search-input.component.html', styleUrls: ['./search-input.component.scss']})
export class SearchInputComponent implements OnInit {
  @Output() userInput: EventEmitter <string>;
  @Input() searching: boolean;
  searchInput: FormControl;
  constructor() {
    this.searchInput = new FormControl();
    this.userInput = new EventEmitter<string>();
    this.searching = false;
  }

  ngOnInit() {
    this.searchInput.valueChanges
      .pipe(debounceTime(400))
      .subscribe((query: string) => {
        console.log('[SearchInputComponent] User input debounced: ', query);
        this.userInput.emit(query);
      });
  }

}
