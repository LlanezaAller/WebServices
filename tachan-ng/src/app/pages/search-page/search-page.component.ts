import {Component} from '@angular/core';
import {TachanService} from '../../services/tachan.service';
import {Movie} from '../../model/movie.model';
import {Observable} from 'rxjs/Observable';
import {tap, delay} from 'rxjs/operators';
import {Router} from '@angular/router';

@Component({selector: 'tcn-search-page', templateUrl: './search-page.component.html', styleUrls: ['./search-page.component.scss']})
export class SearchPageComponent {

  movies$ : Observable < Movie[] >;
  searching : boolean;
  constructor(private searchService : TachanService, private router : Router) {}

  doSearch(name : string) {
    this.searching = true;
    this.movies$ = this
      .searchService
      .search(name)
      .pipe(delay(150), tap(() => this.searching = false), tap((movies) => console.log(movies)));
  }

  navigateToMovie(id : string) {
    this
      .router
      .navigate(['/movie', id]);
  }
}
