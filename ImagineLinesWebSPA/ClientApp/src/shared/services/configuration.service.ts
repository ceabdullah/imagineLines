import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { IConfiguration } from '../models/configuration.model';
import { StorageService } from './storage.service';

import { Observable, Subject } from 'rxjs';

@Injectable()
export class ConfigurationService {
  serverSettings: IConfiguration;
  // observable that is fired when settings are loaded from server
  private settingsLoadedSource = new Subject();
  settingsLoaded$ = this.settingsLoadedSource.asObservable();
  isReady: boolean = false;

  constructor(private http: HttpClient, private storageService: StorageService) { }

  load() {
    const baseURI = document.baseURI.indexOf('/') > 0 ? document.baseURI : `${document.baseURI}/`;
    let url = `${baseURI}Home/Configuration`;
    this.http.get(url).subscribe((response) => {
      this.serverSettings = response as IConfiguration;
      this.storageService.store('bookingUrl', this.serverSettings.bookingUrl);
      this.isReady = true;
      this.settingsLoadedSource.next();
    });
  }
}
