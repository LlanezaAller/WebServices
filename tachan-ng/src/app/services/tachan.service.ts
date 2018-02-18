import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {Movie, MOVIES_MOCK} from '../model/movie.model';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/observable/of';

@Injectable()
export class TachanService {
  readonly apiUrl = environment.tachanApi;
  constructor(private httpClient : HttpClient) {}

  public search(title : string) : Observable < Movie[] > {
    console.log('[TachanService] Searching for ', title);
    return this.httpClient.get < Movie[] > (`${this.apiUrl}/movie?title=${title}`);
    //return Observable.of(MOVIES_MOCK.sort((a, b) => Math.random() - 0.5));
  }

  public findFullMovie(id : string) : Observable < Movie > {
    return this.httpClient.get < Movie > (`${this.apiUrl}/movie?id=${id}`);
  }

}
