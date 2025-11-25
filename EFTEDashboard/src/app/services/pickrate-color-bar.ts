import { Injectable } from '@angular/core';

@Injectable({
	providedIn: 'root'
})
export class PickrateColorBar {
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
