import { Component, OnInit } from '@angular/core';
import { IWord } from '../../word';
import { WordService } from '../../services/words.service';
import { Router } from '@angular/router';

@Component({
  selector: 'gamerun',
  templateUrl: './game-run.component.html',
  styleUrls: ['./game-run.component.css']
})
export class GameRunComponent implements OnInit 
{
  // <-- Initial Set-Up -->
  words: IWord[];

  errorMessage:string;

  index: number = 0;

  checkBox: number[];
  
  isDisabled: boolean[] = [false,false,false,false];

  resultIcon: string[] = [];

  wrongAnswers: number = 0;

  correctAnswers: number = 0;

  score: number = 0;

  // <-- Timer Stuff
  gameInterval: any;
  timeStart: number = 30;
  timeFinish: number = 0;
  startTimer(): void {
    this.gameInterval = setInterval(() => {
      if (this.timeStart == 0) {
        this.onTimeExpired();
      }
      this.timeStart > this.timeFinish ? this.timeStart-- : clearInterval(this.gameInterval);
    }, 1000);
  }
  // Timer Stuff -->

  constructor(private _wordService: WordService, private _router: Router) { }


  ngOnInit() 
  {
    this.startGame();
  }

  startGame() 
  {
  	this._wordService.GetGameWords().subscribe(x => this.words = x, error => this.errorMessage = <any>error,
      () => this.startTimer()); 
  }

  // <-- Running Game -->

  onTimeExpired(): void {
    console.log("Time Expired");
    
    this._router.navigate(['/view-results']);
  }

  checkDisabled(pos: number): boolean {
    return this.isDisabled[pos];
  }

  guessWord(wrd: string, pos: number): void 
  {

    if (wrd == this.words[this.index].answer) 
    {
      // <-- Correct Guess -->
      this.isDisabled = [true,true,true,true];
      this.correctAnswers++;
      this.score++;
      this.resultIcon[pos] = "../assets/checkmark.svg";
      
      // Wait 500 milliseconds
      setTimeout(() => {
        this.index++;
        this.isDisabled = [false,false,false,false];
        this.resultIcon = [];
        }, 500);
    }
    else 
    {
      // <-- Incorrect Guess -->
      this.isDisabled[pos] = true;  
      this.resultIcon[pos] = "../assets/x-mark-512.png";
      this.wrongAnswers++;
    }
  }
}
