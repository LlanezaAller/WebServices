import { Component, OnInit, Input } from '@angular/core';
import { Movie } from '../../model/movie.model';

@Component({
  selector: 'tcn-movie-result',
  templateUrl: './movie-result.component.html',
  styleUrls: ['./movie-result.component.scss']
})
export class MovieResultComponent implements OnInit {
  @Input() movie: Movie;

  constructor() { }

  ngOnInit() {
  }

}
