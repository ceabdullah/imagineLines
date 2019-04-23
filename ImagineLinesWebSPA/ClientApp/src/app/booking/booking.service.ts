import { Injectable } from "@angular/core";
import { Http, Response } from '@angular/http';
import { ConfigurationService } from "../../shared/services/configuration.service";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { ISalesUnit } from "./sales-unit.model";

@Injectable()
export class BookingService {
  private bookingUrl: string = '';

  constructor(private _http: Http, private configurationService: ConfigurationService) {
    this.configurationService.settingsLoaded$.subscribe(x => {
      this.bookingUrl = this.configurationService.serverSettings.bookingUrl + '/api/booking';
    });
  }

  getBookings(minDate: string, maxDate: string, bookingId: number, shipName: string): Observable<ISalesUnit[]> {
    return this._http.get(encodeURI(this.bookingUrl + "/" + minDate + "/" + maxDate
      +
      (bookingId != null || shipName != null ? "?" : "")
      +
      (bookingId == null ? "" : ("bookingId=" + bookingId))
      +
      (shipName == null ? "" : ("&shipName=" + shipName))
    ))
      .pipe(
        map((response: any) => {
          return response;
        })
      );
  }
}
