import { CharacterPopularityDto } from '@/interfaces/outputDtos/character-popularity-dto';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class CharacterPopularityService {
	private readonly baseUrl = (environment.apiUrl ?? '').replace(/\/$/, '');

	constructor(private http: HttpClient) {}

	// GET /GameResult
	getAll(): Observable<CharacterPopularityDto> {
		return this.http.get<CharacterPopularityDto>(`${this.baseUrl}/Character`).pipe(map((c) => c ?? null));
	}
}
