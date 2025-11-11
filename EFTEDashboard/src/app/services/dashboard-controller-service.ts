import { GameResult } from '@/interfaces/game-result';
import { GameVersion } from '@/interfaces/game-version';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DashboardControllerService {
  private readonly baseUrl = (environment.apiUrl ?? '').replace(/\/$/, '');

    constructor(private http: HttpClient) {}

    // GET /GameResult
    get(): Observable<GameVersion|null> {
        return this.http.get<GameVersion>(`${this.baseUrl}/Dashboard`).pipe(map((gv) => (gv ? gv : null)));
    }
}
