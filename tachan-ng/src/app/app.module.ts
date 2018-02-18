import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {RouterModule, Routes} from '@angular/router';
import {AppComponent} from './app.component';
import {SearchInputComponent} from './components/search-input/search-input.component';
import {MovieResultComponent} from './components/movie-result/movie-result.component';
import {HttpClientModule} from '@angular/common/http';
import {TachanService} from './services/tachan.service';
import {MoviePageComponent} from './pages/movie-page/movie-page.component';
import {SearchPageComponent} from './pages/search-page/search-page.component';
import { SanitizePipe } from './sanitize.pipe';

const routes : Routes = [
  {
    path: '',
    redirectTo: 'search',
    pathMatch: 'full'
  }, {
    path: 'search',
    component: SearchPageComponent
  }, {
    path: 'movie/:id',
    component: MoviePageComponent
  }
];
@NgModule({
  declarations: [
    AppComponent, SearchInputComponent, MovieResultComponent, MoviePageComponent, SearchPageComponent, SanitizePipe
  ],
  imports: [
    BrowserModule, FormsModule, ReactiveFormsModule, HttpClientModule, RouterModule.forRoot(routes)
  ],
  providers: [TachanService],
  bootstrap: [AppComponent]
})
export class AppModule {}