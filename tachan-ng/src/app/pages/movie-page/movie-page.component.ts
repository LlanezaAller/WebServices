import {Component, OnInit, OnDestroy} from '@angular/core';
import {TachanService} from '../../services/tachan.service';
import {ActivatedRoute} from '@angular/router';
import {Movie} from '../../model/movie.model';

@Component({selector: 'tcn-movie-page', templateUrl: './movie-page.component.html', styleUrls: ['./movie-page.component.scss']})
export class MoviePageComponent implements OnInit,
OnDestroy {
  private routeSub : any;
  movie : Movie;
  constructor(private route : ActivatedRoute, private moviesService : TachanService) {}

  ngOnInit() {
    this.routeSub = this
      .route
      .params
      .subscribe(params => this.moviesService.findFullMovie(params.id).subscribe((movie) => this.movie = movie));
  }
  ngOnDestroy() {
    if (this.routeSub) {
      this
        .routeSub
        .unsubscribe();
    }
  }

}