import {Component} from '@angular/core';
import {TachanService} from './services/tachan.service';
import {Movie} from './model/movie.model';
import {Observable} from 'rxjs/Observable';

@Component({selector: 'tcn-root', templateUrl: './app.component.html', styleUrls: ['./app.component.scss']})
export class AppComponent {
    movies$: Observable < Movie[] >;
    constructor(private searchService: TachanService) {}

    doSearch(name: string) {
        this.movies$ = this
            .searchService
            .search(name);
    }
}
