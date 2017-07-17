import { Injectable } from '@angular/core';

import { WordObject } from '../WordObject';


@Injectable()
export class WordService {

	jsonData: any;

	// shuffledSequence: number[] = [];

	// selectionsIteration: number = 0;

	private mockData: string = `
	{
		"difficulty": "beginner",
		"selections": [
			{
				"target": "relentless",
				"answer": "persisting",
				"words": [
					"hopeless",
					"brave",
					"persisting",
					"rushed" 
				]
			},
			{
				"target": "amsterdam",
				"answer": "holland",
				"words": [
					"holland",
					"germany",
					"slovakia",
					"prague"
				]
			},
			{
				"target": "ag",
				"answer": "silver",
				"words": [
					"gold",
					"argon",
					"silver",
					"arsenic"
				]
			},
			{
				"target": "candid",
				"answer": "frank",
				"words": [
					"hidden",
					"elusive",
					"obtrusive",
					"frank"
				]
			}
		]
	}`

	getWordsObject(): WordObject[] {
		let wordObject: WordObject[] = [];

		this.jsonData = JSON.parse(this.mockData); 

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

		for (let i = 0; i < this.jsonData.selections.length; i++) {
			wordObject.push(new WordObject(
				this.jsonData.selections[i].target, 
				this.jsonData.selections[i].answer, 
				this.jsonData.selections[i].words)
			);
		}

		console.log(wordObject);

		return wordObject;
	}

}