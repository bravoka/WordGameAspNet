import { Component, OnInit, OnDestroy } from '@angular/core';
import { WordObject } from '../WordObject';
import { Router } from '@angular/router';
import { WordService } from '../services/words.service';
import { Http } from '@angular/http';



@Component({
	selector: 'playboard',
	templateUrl: './game.component.html',
	styleUrls: [
		'./game.component.css'
	],
	providers: [
		WordService
	]
})
export class GameComponent implements OnInit, OnDestroy {

	constructor(
	  private http: Http,
		private wordService: WordService,
		private router: Router) { }

	shuffledSequence: number[] = [];

	selectionsIteration: number = 0;

	jsonData: any;

	wordTarget: string;

	correctWord: string;

	playerPoints: number = 0;

	roundsPlayed: number = 0;

	wordObject: WordObject[] = [];

	rawJson: string;

	currentWord: WordObject;

	isClickedArray: boolean[] = [ false, false, false, false];

	buttonClass: string[] = [ "choiceButtonOpen", "choiceButtonOpen", "choiceButtonOpen", "choiceButtonOpen" ]

	resultMessage: string;

	resultIcon: string ;

	testWord: string;




  ngOnInit(): void {
    // this.getWordsObject();
    // this.currentWord = this.wordObject[0];
    // console.log(this.currentWord);

    let wordObject: WordObject[] = [];
    // new test
    this.getWordsObjectHere().then(result => this.rawJson = result)
      .then(() => this.jsonData = JSON.parse(this.rawJson))
      .then( () => console.log(this.jsonData))
      .then(() => this.testWord = this.jsonData.selections[0].target);
  }


  runLoop(x): void {
    for (let i = 0; i < x.selections.length; i++) {
      this.wordObject.push(new WordObject(
        x.selections[i].target,
        x.selections[i].answer,
        x.selections[i].words)
      );
      return;
    }
  }



	getWordsObject(): void {
		// this.wordObject = this.wordService.getWordsObject();
		this.wordService.getWordsObject().then(w => this.wordObject = w);
	}

	/// TODO: Make wordArray into a wordObject so that it can have word.Text and word.AlreadyClicked
	playerGuess(guess: string, index: number): void {
		if (guess == this.currentWord.Solution) {
			this.resultIcon = "https://openclipart.org/download/257462/Checkmark.svg";
			this.resultMessage = "You guessed right!";
			this.playerPoints++;
			this.roundsPlayed++;
			this.selectionsIteration++;
			if (this.selectionsIteration == this.wordObject.length) {

				this.ResultsView("Good job!");
			}
			else {

				this.newRound();
				return;
				// Need to reset everything or go to a new page after this.
			}
		}
		else {
			// this.resultIcon = "http://www.iconsdb.com/icons/preview/soylent-red/x-mark-xxl.png";
			this.resultIcon = "../assets/x-mark-512.png"
			this.roundsPlayed++;
			console.log("Incorrect guess: " + guess);
			this.isClickedArray[index] = true;
			this.buttonClass[index]='choiceButtonClosed';
			this.resultMessage = `${guess} was incorrect`;
			if (this.selectionsIteration == this.wordObject.length) {
				alert("Game over");
				this.ResultsView("Nice try!");
				return;
			}

			return;
		}
	}

	ResultsView(message: string): void {
		alert("Game over. " + message);
		// WRITE RESULTS TO SERVER
		// Time elapsed, correct answers, incorrect answers
		// Write words played, and whether they were correct or incorrect
		this.router.navigate(['/view-results']);

	}

	newRound(): void {

		//this.currentWord = this.wordObject[0];

		this.isClickedArray = [ false, false, false, false ];

		this.buttonClass = [ "choiceButtonOpen", "choiceButtonOpen", "choiceButtonOpen", "choiceButtonOpen" ];

		this.currentWord = this.wordObject[this.selectionsIteration];

	}
	active: boolean = false;
	timeStart: number = 10;
	refresh: number = 1000;
	timeFinish: number = 0;
	resetTime: number = 10;

	_myInterval: any;

	public DoWork(): void {
		this.timeStart--;
		// this.active = true;
	}

	SimpleCountdown(): void {
		console.log(this.wordObject);
		this.active = true;
		// let _myInterval: any;
		this._myInterval = setInterval(() => {
			if (this.timeStart == 0) {
				this.ResultsView("Time Expired");
			}
			this.timeStart > this.timeFinish ? this.timeStart-- : clearInterval(this._myInterval);


		}, 1000);
	}

	Reset(): void {
		this.timeStart = this.resetTime;
		return;
	}

	ngOnDestroy() {
		clearInterval(this._myInterval);
	}

  getWordsObjectHere(): Promise<string> {

    let wordObject: WordObject[] = [];
    // this.jsonData = JSON.parse(this.mockData);
    let a: string;
    return Promise.resolve(this.http.get("api/WordGame").toPromise()
      .then(res => res.text()));
	}

}
