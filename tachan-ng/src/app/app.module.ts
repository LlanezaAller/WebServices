import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import {AppComponent} from './app.component';
import {SearchInputComponent} from './components/search-input/search-input.component';
import {MovieResultComponent} from './components/movie-result/movie-result.component';
import {HttpClientModule} from '@angular/common/http';
import {TachanService} from './services/tachan.service';

@NgModule({
  declarations: [
    AppComponent, SearchInputComponent, MovieResultComponent
  ],
  imports: [
    BrowserModule, FormsModule, ReactiveFormsModule, HttpClientModule
  ],
  providers: [TachanService],
  bootstrap: [AppComponent]
})
export class AppModule {}
