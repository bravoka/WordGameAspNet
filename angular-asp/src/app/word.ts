export interface IWord {
	description: string;
	answerIsSynonym: boolean;
	answer: string;
	possibleChoices: string[];
	category: string;
}