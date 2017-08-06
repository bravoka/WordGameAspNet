export class WordObject {
	WordTarget: string;
	WordsList: string[];
	Options: { Words: string[], Clicked: boolean };
	Solution: string;
	IsClicked: boolean = false;
	Class: string = "choiceButtonOpen";
	Category: string;
	
	constructor(target:string, solution: string, wordsList: string[]) {
		this.WordTarget = target;
		this.Solution = solution;
		this.WordsList = wordsList; // TO DELETE
		this.Options = { Words: wordsList, Clicked: false}		
	}
}