import { PickrateColorBar } from '@/services/pickrate-color-bar';
import { PercentPipe } from '@angular/common';
import { Component } from '@angular/core';
import { TableModule } from "primeng/table";

@Component({
	selector: 'app-passive-stats',
	imports: [TableModule, PercentPipe],
	templateUrl: './passive-stats.html',
	styleUrl: './passive-stats.scss'
})
export class PassiveStats {
	passiveResults: any[] = [];
	constructor(private pickrateColorBar: PickrateColorBar) {}
	getPickrateColorClass(pickrate: number): string {
		return this.pickrateColorBar.getPickrateColorClass(pickrate);
	}
}
