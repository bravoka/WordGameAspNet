import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { IGameResult } from '../GameResult';

@Injectable()
export class ResultService {

  constructor(private _http: HttpClient) 
  { 
  }

  GetResult(): Observable<IGameResult> {
  	return this._http.get('/api/WordGame/results');
  }

  PostResult(score: number, incorrectAnswers: number): Observable<IGameResult> {
  	const headers = new HttpHeaders().set('userName', 'lotus989');

  	return this._http.post('/api/WordGame/results', {
  		'score': score, 'incorrectAnswers': incorrectAnswers
  		},
  		{ headers }
  		);
  }

}
