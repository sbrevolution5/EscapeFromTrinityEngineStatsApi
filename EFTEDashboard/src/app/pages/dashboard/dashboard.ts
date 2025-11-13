import { Component } from '@angular/core';
import { NotificationsWidget } from './components/notificationswidget';
import { StatsWidget } from './components/statswidget';
import { RecentSalesWidget } from './components/recentsaleswidget';
import { BestSellingWidget } from './components/bestsellingwidget';
import { RevenueStreamWidget } from './components/revenuestreamwidget';
import { DashboardControllerService } from '@/services/dashboard-controller-service';
import { Mostpickedcards } from './components/mostpickedcards/mostpickedcards';
import { DashboardStatsDto } from '@/interfaces/outputDtos/dashboard-stats-dto';

@Component({
	selector: 'app-dashboard',
	imports: [StatsWidget, BestSellingWidget, RevenueStreamWidget, NotificationsWidget, Mostpickedcards],
	template: `
		<div class="grid grid-cols-12 gap-8">
            @if (this.dashStats != null){

                <app-stats-widget [dashStats]="this.dashStats" class="contents" />
            }
			<div class="col-span-12 xl:col-span-6">
				@if (currentVersion != null) {
					<app-mostpickedcards [mostRecentVersionId]="this.currentVersion" />
				}
				<app-best-selling-widget />
			</div>
			<div class="col-span-12 xl:col-span-6">
				<app-revenue-stream-widget />
				<app-notifications-widget />
			</div>
		</div>
	`
})
export class Dashboard {
	currentVersion: number | undefined;
    dashStats: DashboardStatsDto | undefined;
	constructor(private dashboardControllerService: DashboardControllerService) {}
	ngOnInit() {
        this.dashboardControllerService.getDashboard().subscribe();
		this.dashboardControllerService.get().subscribe((gv) => {
			this.currentVersion = gv?.id;
		});
	}
}
