import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl} from '@core';
import { Profile } from '../models';

@Injectable({
  providedIn: 'root'
})
export class ProfileService  {

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }


  public get(): Observable<Profile[]> {
    return this._client.get<{ profiles: Profile[] }>(`${this._baseUrl}api/profile`)
      .pipe(
        map(x => x.profiles)
      );
  }

  public getById(options: { profileId: string }): Observable<Profile> {
    return this._client.get<{ profile: Profile }>(`${this._baseUrl}api/profile/${options.profileId}`)
      .pipe(
        map(x => x.profile)
      );
  }

  public remove(options: { profile: Profile }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/profile/${options.profile.profileId}`);
  }

  public create(options: { profile: Profile }): Observable<{ profile: Profile }> {
    return this._client.post<{ profile: Profile }>(`${this._baseUrl}api/profile`, { profile: options.profile });
  }

  public update(options: { profile: Profile }): Observable<{ profile: Profile }> {
    return this._client.put<{ profile: Profile }>(`${this._baseUrl}api/profile`, { profile: options.profile });
  }

  public updateProfileImage(options: { profile: Profile, file: FormData }): Observable<{ profile: Profile }> {
    return this._client.put<{ profile: Profile, file: FormData }>(`${this._baseUrl}api/profile/image`, options);
  }

  public updateCompanyProfileImage(options: { profile: Profile, file: FormData }): Observable<{ profile: Profile }> {
    return this._client.put<{ profile: Profile, file: FormData }>(`${this._baseUrl}api/profile/company-image`, options);
  }
}
