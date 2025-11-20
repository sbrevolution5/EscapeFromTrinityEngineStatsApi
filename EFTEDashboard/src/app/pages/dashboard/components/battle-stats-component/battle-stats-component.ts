import { BattleStatsOutputDto } from '@/interfaces/outputDtos/battle-stats-output-dto';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { Table, TableModule } from 'primeng/table';
import { IconField } from 'primeng/iconfield';
import { InputIcon } from 'primeng/inputicon';
import { MultiSelect } from 'primeng/multiselect';
import { Select } from 'primeng/select';
import { Slider } from 'primeng/slider';
import { DatePipe, DecimalPipe, PercentPipe } from '@angular/common';
import { Tag } from 'primeng/tag';
import { ProgressBar } from 'primeng/progressbar';
import { LayoutService } from '@/layout/service/layout.service';
import { BattleRecordService } from '@/services/battle-record-service';

@Component({
	selector: 'app-battle-stats-component',
	imports: [TableModule,  PercentPipe, DecimalPipe],
	templateUrl: './battle-stats-component.html',
	styleUrl: './battle-stats-component.scss'
})
export class BattleStatsComponent {
	battleStats: BattleStatsOutputDto | undefined;
	loading: boolean = true;
	@ViewChild('filter') filter!: ElementRef;
	constructor(
		public layoutService: LayoutService,
		public battleRecordService: BattleRecordService
	) {}
	ngOnInit() {
		this.battleRecordService.getAll().subscribe({
			next: (data) => {
				console.log('battle stats data received', data);
				this.battleStats = data;
				console.log('mapped battle stats', this.battleStats);
				this.loading = false;
			},
			error: (err) => {
				console.error('Could not fetch battle stats from API', err);
			}
		});
	}
	onGlobalFilter(table: Table, event: Event) {
		table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
	}
	clear(table: Table) {
		table.clear();
		this.filter.nativeElement.value = '';
	}
}
