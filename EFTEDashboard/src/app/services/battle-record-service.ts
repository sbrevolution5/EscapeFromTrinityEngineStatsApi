import { BattleRecord } from '@/interfaces/battle-record';
import { BattleStatsOutputDto } from '@/interfaces/outputDtos/battle-stats-output-dto';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class BattleRecordService {
	private readonly baseUrl = (environment.apiUrl ?? '').replace(/\/$/, '');

	constructor(private http: HttpClient) {}

	// GET /GameResult
	getAll(): Observable<BattleStatsOutputDto> {
		return this.http.get<BattleStatsOutputDto>(`${this.baseUrl}/Battle`).pipe(map((list) => (list ?? [])));
	}
}
