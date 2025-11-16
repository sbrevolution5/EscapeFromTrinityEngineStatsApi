import { Component, Input, OnInit } from '@angular/core';
import { Menu } from 'primeng/menu';
import { CardPickRateDto } from '../../../../interfaces/outputDtos/card-pick-rate-dto';
import { Pickedcardrow } from './pickedcardrow/pickedcardrow';
import { GameResultService } from '@/services/game-result-service';
import { PickRateService } from '@/services/pick-rate-service';
import { map } from 'rxjs';

@Component({
	standalone: true,
	selector: 'app-mostpickedcards',
	imports: [Pickedcardrow],
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
						const pr = raw;
						// Map API response to CardPickRate (API returns camelCase properties)
						const mapped: CardPickRateDto = {
							versionId: Number(pr?.versionId ?? pr?.VersionId ?? 0),
							versionName: String(pr?.versionName ?? pr?.VersionName ?? ''),
							cardInstanceId: Number(pr?.cardInstanceId ?? pr?.CardInstanceId ?? 0),
							cardName: String(pr?.cardName ?? pr?.CardName ?? ''),
							availableCount: Number(pr?.availableCount ?? pr?.AvailableCount ?? 0),
							pickedCount: Number(pr?.pickedCount ?? pr?.PickedCount ?? 0)
						};
						this.cardResults = mapped;
						console.log('raw', raw);
						console.log('mapped', this.cardResults);
					},
					error: (err) => {
						console.error('Could not fetch pick rates from API', err);
						this.cardResults = [];
					}
				});
		}
	}
}
