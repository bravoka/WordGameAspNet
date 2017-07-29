import { Component, OnInit } from '@angular/core';
import { IWord } from '../../word';
import { WordService } from '../../services/words.service';

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

  wrongAnswers: number = 0;

  correctAnswers: number = 0;

  score: number = 0;

  constructor(private wordService: WordService) { }

  ngOnInit() 
  {
  	this.getWords();
  }

  getWords() 
  {
  	this.wordService.GetGameWords().subscribe(x => this.words = x, error => this.errorMessage = <any>error);    
  }

  // <-- Running Game -->

  checkDisabled(pos: number): boolean {
    return this.isDisabled[pos];
  }

  guessWord(wrd: string, pos: number): void 
  {
    if (wrd == this.words[this.index].answer) 
    {
      // <-- Correct Guess -->
      this.correctAnswers++;
      this.score++;
      this.isDisabled = [false,false,false,false];
      this.index++;
    }
    else 
    {
      // <-- Incorrect Guess -->
      this.isDisabled[pos] = true;
      this.wrongAnswers++;
    }
  }
}
