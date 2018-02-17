import {Component} from '@angular/core';
import {TachanService} from './services/tachan.service';
import {Movie} from './model/movie.model';
import {Observable} from 'rxjs/Observable';
import {tap, delay} from 'rxjs/operators';
@Component({selector: 'tcn-root', templateUrl: './app.component.html', styleUrls: ['./app.component.scss']})
export class AppComponent {
    movies$: Observable < Movie[] >;
    searching: boolean;
    constructor(private searchService: TachanService) {}

    doSearch(name: string) {
        this.searching = true;
        this.movies$ = this.searchService
            .search(name)
            .pipe(
                delay(150),
                tap(() => this.searching = false),
            );
    }
}
