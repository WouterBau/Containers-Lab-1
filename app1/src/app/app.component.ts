import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { WeatherForecast } from './models/WeatherForecase';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
@Injectable()
export class AppComponent {
  
  title = 'app1';
  forecast : WeatherForecast | undefined;

  constructor(private http: HttpClient){
    this.showForecast();
  }

  getForecastObservable() {
    return this.http.get<WeatherForecast[]>("/api/WeatherForecast");
  }

  showForecast() {
    this.getForecastObservable().subscribe(
      (data: WeatherForecast[]) => this.forecast = data[0]);
  }

}
