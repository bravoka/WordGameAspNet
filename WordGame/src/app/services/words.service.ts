import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import { IWord } from '../word'; 

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import { WordObject } from '../WordObject';


@Injectable()
export class WordService {
	constructor(private _http: Http) { }

	private dataUrl: string =  'api/WordGame';
	// private dataUrl: string = '../assets/words.json';
	GetGameWords(): Observable<IWord[]> {
		return this._http.get(this.dataUrl).map((response: Response) => <IWord[]>response.json());
	}


	private handleError(error: any): Promise<any> {
		console.error('An error occurred', error);
		return Promise.reject(error.message || error);
	}












	// shuffledSequence: number[] = [];

	// selectionsIteration: number = 0;

	

	getWordsOnline(): Promise<string> {
		const url = this.dataUrl;
		return this._http.get(url).toPromise()
			.then(data => data.text() )
			.catch(this.handleError);
	}

	runLoop(x): WordObject[] {
		let wordObject: WordObject[] = [];
		for (let i = 0; i < x.selections.length; i++) {
			wordObject.push(new WordObject(
			x.selections[i].target, 
			x.selections[i].answer, 
			x.selections[i].words)
			
			);
		return wordObject;
		}

	}

	getWordsObject(): Promise<WordObject[]> {
		
		let wordObject: WordObject[] = [];
		// this.jsonData = JSON.parse(this.mockData); 

		const url = this.dataUrl;
		return this._http.get(url).toPromise()
			.then(res => res.json() )
			.then(x => this.runLoop(x))
			.then(x => wordObject = x);
			// .catch(this.handleError);
		

		// console.log(this.gameData);

/*		for (let i = 0; i < this.jsonData.selections.length; i++) {
			this.shuffledSequence.push(i); // change this to raw sequence later?
		}
		
		// Fisher-Yates
		let n = this.jsonData.selections.length, i, j;
		while (n > 0) {
			j = Math.floor(Math.random() * n);
			n--;
			i = this.shuffledSequence[n];
			this.shuffledSequence[n] = this.shuffledSequence[j];
			this.shuffledSequence[j] = i;
		}*/

		// for (let i = 0; i < this.jsonData.selections.length; i++) {
		// 	wordObject.push(new WordObject(
		// 		this.jsonData.selections[i].target, 
		// 		this.jsonData.selections[i].answer, 
		// 		this.jsonData.selections[i].words)
		// 	);
		// }

		// console.log(wordObject);

		// return Promise.resolve(wordObject);
		// return wordObject;
	}

}