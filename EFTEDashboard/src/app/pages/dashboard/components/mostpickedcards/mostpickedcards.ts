import { Component, Input, OnInit } from '@angular/core';
import { Menu } from 'primeng/menu';
import { CardPickRateDto } from '../../../../interfaces/outputDtos/card-pick-rate-dto';
import { Pickedcardrow } from './pickedcardrow/pickedcardrow';
import { GameResultService } from '@/services/game-result-service';
import { PickRateService } from '@/services/pick-rate-service';
import { map } from 'rxjs';
import { DataView } from 'primeng/dataview';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { Select } from 'primeng/select';
import { MostPickedCardsDisplay } from '@/interfaces/display/most-picked-cards-display';

@Component({
	standalone: true,
	selector: 'app-mostpickedcards',
	imports: [Pickedcardrow, DataView, CommonModule, TableModule, Select],
	templateUrl: './mostpickedcards.html',
	styleUrl: './mostpickedcards.scss'
})
export class Mostpickedcards implements OnInit {
	@Input()
	mostRecentVersionId!: number | undefined;
	cardResults: any;

	constructor(private pickRateService: PickRateService) {}

	ngOnInit() {
		if (this.mostRecentVersionId != null) {
			this.cardResults = this.pickRateService
				.getMostPickedCards(this.mostRecentVersionId)
				.pipe(map((pr) => (pr ? pr : undefined)))
				.subscribe({
					next: (raw: any) => {
						// Map API response array to CardPickRateDto[] (API returns camelCase properties)
						const mapped: MostPickedCardsDisplay[] = Array.isArray(raw)
							? raw.map((pr: any) => ({
									versionId: Number(pr?.versionId ?? pr?.VersionId ?? 0),
									versionName: String(pr?.versionName ?? pr?.VersionName ?? ''),
									cardInstanceId: Number(pr?.cardInstanceId ?? pr?.CardInstanceId ?? 0),
									cardName: String(pr?.cardName ?? pr?.CardName ?? ''),
									availableCount: Number(pr?.availableCount ?? pr?.AvailableCount ?? 0),
									pickedCount: Number(pr?.pickedCount ?? pr?.PickedCount ?? 0),
									characterName: String(pr?.characterName ?? pr?.CharacterName ?? ''),
									pickrate: Number(pr?.availableCount ?? pr?.AvailableCount ?? 0) > 0 ? Number(pr?.pickedCount ?? pr?.PickedCount ?? 0) / Number(pr?.availableCount ?? pr?.AvailableCount ?? 1) : 0
								}))
							: [];
						console.log('raw', raw);
						this.cardResults = mapped.filter((cr) => cr.availableCount > 0);
						console.log('mapped', this.cardResults);
					},
					error: (err) => {
						console.error('Could not fetch pick rates from API', err);
						this.cardResults = [];
					}
				});
		}
	}
	getPickrateColorClass(pickrate: number): string {
		if (pickrate >= 0.3 && pickrate <= 0.7) {
			return 'bg-green-500';
		} else if ((pickrate >= 0.2 && pickrate < 0.3) || (pickrate > 0.7 && pickrate <= 0.8)) {
			return 'bg-yellow-500';
		} else {
			return 'bg-red-500';
		}
	}
}
