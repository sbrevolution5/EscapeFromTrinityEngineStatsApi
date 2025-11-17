import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationsWidget } from './components/notificationswidget';
import { StatsWidget } from './components/statswidget';
import { BestSellingWidget } from './components/bestsellingwidget';
import { DashboardControllerService } from '@/services/dashboard-controller-service';
import { Mostpickedcards } from './components/mostpickedcards/mostpickedcards';
import { DashboardStatsDto } from '@/interfaces/outputDtos/dashboard-stats-dto';
import { map } from 'rxjs';
import { GameVersion } from '@/interfaces/game-version';
import { CharacterPopularityComponent } from "./components/character-popularity-component/character-popularity-component";

@Component({
	selector: 'app-dashboard',
	standalone: true,
	imports: [CommonModule, StatsWidget, BestSellingWidget, NotificationsWidget, Mostpickedcards, CharacterPopularityComponent],
	template: `
		<div class="grid grid-cols-12 gap-8">
			<app-stats-widget *ngIf="dashStats" [dashStats]="dashStats" class="contents"></app-stats-widget>
			<div class="col-span-12 xl:col-span-6">
				@if (currentVersion != null) {
					<app-mostpickedcards  [mostRecentVersionId]="currentVersion" ></app-mostpickedcards>
				}
				<app-best-selling-widget></app-best-selling-widget>
			</div>
			<div class="col-span-12 xl:col-span-6">
				<app-character-popularity-component></app-character-popularity-component>
				<app-notifications-widget></app-notifications-widget>
			</div>
		</div>
	`
})
export class Dashboard {
	currentVersion: number | undefined;
	// Initialize with defaults so the StatsWidget renders immediately if API is slow or unavailable
	dashStats: DashboardStatsDto = {
		gamesPlayed: 0,
		totalChoices: 0,
		currentWinrate: 0,
		currentVersion: 0
	};

	// Default fallback if API call fails or returns nothing
	private readonly DEFAULT_DASH_STATS: DashboardStatsDto = {
		gamesPlayed: 0,
		totalChoices: 0,
		currentWinrate: 0,
		currentVersion: 0
	};

	constructor(private dashboardControllerService: DashboardControllerService) {}

	ngOnInit(): void {
		this.dashboardControllerService
			.getDashboard()
			.pipe(map((ds) => (ds ? ds : undefined)))
			.subscribe({
				next: (raw: any) => {
					const ds = raw;
					// Map API response to DashboardStatsDto (API returns camelCase properties)
					const mapped: DashboardStatsDto = {
						gamesPlayed: Number(ds?.gamesPlayed ?? ds?.GamesPlayed ?? this.DEFAULT_DASH_STATS.gamesPlayed),
						totalChoices: Number(ds?.totalChoices ?? ds?.TotalChoices ?? this.DEFAULT_DASH_STATS.totalChoices),
						currentWinrate: Number(ds?.currentWinrate ?? ds?.CurrentWinrate ?? this.DEFAULT_DASH_STATS.currentWinrate),
						currentVersion: Number(ds?.currentVersion ?? ds?.CurrentVersion ?? this.DEFAULT_DASH_STATS.currentVersion)
					};
					this.currentVersion = mapped.currentVersion;

					this.dashStats = mapped;
					console.log('dashboard data (raw):', ds);
					console.log('dashboard data (mapped):', mapped);
				},
				error: (err) => {
					console.error('Failed to load dashboard, using defaults', err);
					this.dashStats = this.DEFAULT_DASH_STATS;
				}
			});

		// Uncomment and use similar defensive logic if you re-enable current version retrieval
		// this.dashboardControllerService.get().subscribe({
		//     next: (gv) => (this.currentVersion = gv ?? undefined),
		//     error: (err) => console.error(err)
		// });
	}
}
