import { BattleStatsOutputDto } from '@/interfaces/outputDtos/battle-stats-output-dto';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { Table, TableModule } from "primeng/table";
import { IconField } from "primeng/iconfield";
import { InputIcon } from "primeng/inputicon";
import { MultiSelect } from "primeng/multiselect";
import { Select } from "primeng/select";
import { Slider } from "primeng/slider";
import { DatePipe, DecimalPipe, PercentPipe } from '@angular/common';
import { Tag } from "primeng/tag";
import { ProgressBar } from "primeng/progressbar";

@Component({
	selector: 'app-battle-stats-component',
	imports: [TableModule, IconField, InputIcon, MultiSelect, Select, Slider, DatePipe, Tag, ProgressBar,PercentPipe,DecimalPipe],
	templateUrl: './battle-stats-component.html',
	styleUrl: './battle-stats-component.scss'
})
export class BattleStatsComponent {
	battleStats: BattleStatsOutputDto | undefined;
	loading: boolean = true;
	@ViewChild('filter') filter!: ElementRef;
	onGlobalFilter(table: Table, event: Event) {
		table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
	}
	clear(table: Table) {
		table.clear();
		this.filter.nativeElement.value = '';
	}
}
