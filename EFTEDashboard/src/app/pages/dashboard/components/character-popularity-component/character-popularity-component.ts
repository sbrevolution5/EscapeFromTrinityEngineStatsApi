import { LayoutService } from '@/layout/service/layout.service';
import { Component } from '@angular/core';
import { UIChart } from "primeng/chart";
import { debounceTime, Subscription } from 'rxjs';

@Component({
  selector: 'app-character-popularity-component',
  imports: [UIChart],
  templateUrl: './character-popularity-component.html',
  styleUrl: './character-popularity-component.scss'
})
export class CharacterPopularityComponent {
pieData: any;

    pieOptions: any;

    subscription!: Subscription;

    constructor(public layoutService: LayoutService) {
        this.subscription = this.layoutService.configUpdate$.pipe(debounceTime(25)).subscribe(() => {
            this.initChart();
        });
    }

    ngOnInit() {
        
        this.initChart();
    }

    initChart() {
        const documentStyle = getComputedStyle(document.documentElement);
        const textColor = documentStyle.getPropertyValue('--text-color');

        this.pieData = {
			labels: ['A', 'B', 'C'],
			datasets: [
				{
					data: [540, 325, 702],
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
