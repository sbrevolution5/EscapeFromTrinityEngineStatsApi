import { CharacterPopularityDto } from '@/interfaces/outputDtos/character-popularity-dto';
import { LayoutService } from '@/layout/service/layout.service';
import { CharacterPopularityService } from '@/services/character-popularity-service';
import { Component } from '@angular/core';
import { UIChart } from 'primeng/chart';
import { debounceTime, map, Subscription } from 'rxjs';

@Component({
	selector: 'app-character-popularity-component',
	imports: [UIChart],
	templateUrl: './character-popularity-component.html',
	styleUrl: './character-popularity-component.scss'
})
export class CharacterPopularityComponent {
	pieData: any;
	characterPopularityData: CharacterPopularityDto | undefined;
	pieOptions: any;

	subscription!: Subscription;

	constructor(
		public layoutService: LayoutService,
		public characterPopularityService: CharacterPopularityService
	) {
		this.subscription = this.layoutService.configUpdate$.pipe(debounceTime(25)).subscribe(() => {
			this.initChart();
		});
	}

	ngOnInit() {
		this.characterPopularityService
			.getAll()
			.pipe(map((cp) => (cp ? cp : undefined)))
			.subscribe({
				next: (raw: any) => {
					const mapped: CharacterPopularityDto = {
						versionId: Number(raw?.versionId ?? raw?.VersionId ?? 0),
						specificVersion: Boolean(raw?.versionName ?? raw?.VersionName ?? ''),
						characters: Array.isArray(raw.characters)
							? raw.characters.map((charRecord: any) => ({
									name: String(charRecord?.name ?? charRecord?.Name ?? ''),
									plays: Number(charRecord?.plays ?? charRecord?.Plays ?? 0),
									wins: Number(charRecord?.wins ?? charRecord?.Wins ?? 0)
								}))
							: [],
						totalGames: Number(raw?.totalGames ?? raw?.TotalGames ?? 0)
					};

					this.characterPopularityData = mapped;
					console.log('mapped', this.characterPopularityData);
					this.initChart();
				},
				error: (err) => {
					console.error('Could not fetch pick rates from API', err);
					this.characterPopularityData = undefined;
				}
			});
	}

	initChart() {
		const documentStyle = getComputedStyle(document.documentElement);
		const textColor = documentStyle.getPropertyValue('--text-color');

		this.pieData = {
			labels: this.characterPopularityData?.characters.map((c) => c.name) ?? ['Character A', 'Character B', 'Character C'],
			datasets: [
				{
					data: this.characterPopularityData?.characters.map((c) => c.plays) ?? [300, 500, 200],
					backgroundColor: [documentStyle.getPropertyValue('--p-indigo-500'), documentStyle.getPropertyValue('--p-purple-500'), documentStyle.getPropertyValue('--p-teal-500')],
					hoverBackgroundColor: [documentStyle.getPropertyValue('--p-indigo-400'), documentStyle.getPropertyValue('--p-purple-400'), documentStyle.getPropertyValue('--p-teal-400')]
				}
			]
		};

		this.pieOptions = {
			plugins: {
				legend: {
					labels: {
						usePointStyle: true,
						color: textColor
					}
				}
			}
		};
	}

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}
}
