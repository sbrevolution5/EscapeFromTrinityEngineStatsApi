import { Component, Input, OnInit } from '@angular/core';
import { Menu } from 'primeng/menu';
import { CardPickRateDto } from '../../../../interfaces/outputDtos/card-pick-rate-dto';
import { Pickedcardrow } from './pickedcardrow/pickedcardrow';
import { GameResultService } from '@/services/game-result-service';

@Component({
	selector: 'app-mostpickedcards',
	imports: [Pickedcardrow],
	templateUrl: './mostpickedcards.html',
	styleUrl: './mostpickedcards.scss'
})
export class Mostpickedcards implements OnInit {
	@Input()
	mostRecentVersionId!: number;
	results: any;
	cardResults: any;

	constructor(private gameResultService: GameResultService) {}

	ngOnInit() {
		this.results = this.gameResultService.getAll();
		this.cardResults = this.gameResultService.getMostPickedCards(this.mostRecentVersionId);
	}
}
