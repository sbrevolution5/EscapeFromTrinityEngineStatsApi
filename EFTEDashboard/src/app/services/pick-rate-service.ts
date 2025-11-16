import { CardPickRateDto } from '@/interfaces/outputDtos/card-pick-rate-dto';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class PickRateService {
	private readonly baseUrl = (environment.apiUrl ?? '').replace(/\/$/, '');

	constructor(private http: HttpClient) {}
	// GET /PickRate/{versionId}
	getMostPickedCards(versionId: number): Observable<CardPickRateDto[]> {
		return this.http.get<CardPickRateDto[]>(`${this.baseUrl}//PickRate/${versionId}`).pipe(map((list) => list ?? []));
	}
}
