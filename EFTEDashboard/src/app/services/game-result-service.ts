import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { GameResult } from '../interfaces/game-result';
import { environment } from '../../environments/environment';
import { CardPickRateDto } from '@/interfaces/outputDtos/card-pick-rate-dto';

@Injectable({
	providedIn: 'root'
})
export class GameResultService {
	private readonly baseUrl = (environment.apiUrl ?? '').replace(/\/$/, '');

	constructor(private http: HttpClient) {}

	// GET /GameResult
	getAll(): Observable<GameResult[]> {
		return this.http.get<GameResult[]>(`${this.baseUrl}/GameResult`).pipe(map((list) => (list ?? []).map(this.normalizeGameResult)));
	}

	// GET /GameResult?version=...
	// (controller must accept query param; still safe to send)
	getByVersion(version: string): Observable<GameResult[]> {
		const params = new HttpParams().set('version', version);
		return this.http.get<GameResult[]>(`${this.baseUrl}/GameResult`, { params }).pipe(map((list) => (list ?? []).map(this.normalizeGameResult)));
	}

	// GET /GameResult/{id}
	getById(id: number): Observable<GameResult | null> {
		return this.http.get<GameResult>(`${this.baseUrl}/GameResult/${id}`).pipe(map((gr) => (gr ? this.normalizeGameResult(gr) : null)));
	}
	getMostPickedCards(versionId: number): Observable<CardPickRateDto[]> {
        return this.http.get<CardPickRateDto[]>(`${this.baseUrl}/GameResult/MostPickedCards/${versionId}`).pipe(map((list) => (list ?? [])));
    }
	// Ensure arrays are present to simplify component code
	private normalizeGameResult = (gr: GameResult): GameResult => ({
		...gr,
		rooms: gr.rooms ?? [],
		characters: gr.characters ?? [],
		passives: gr.passives ?? []
		// any other normalization (dates, ids) can go here
	});
}
