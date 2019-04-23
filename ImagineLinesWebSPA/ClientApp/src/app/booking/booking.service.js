//import { Injectable } from "@angular/core";
//import { Http, Response } from '@angular/http';
//import { ConfigurationService } from "../../shared/services/configuration.service";
//import { Observable } from "rxjs";
//@Injectable()
//export class BookingService {
//  private bookingUrl: string = '';
//  constructor(private _http: Http, private configurationService: ConfigurationService) {
//    this.configurationService.settingsLoaded$.subscribe(x => {
//      this.bookingUrl = this.configurationService.serverSettings.bookingUrl + '/api/booking';
//    });
//  }
//  getBookings(minDate: string, maxDate: string) {
//    return this._http.get(this.bookingUrl + "/" + minDate + "/" + maxDate)
//      .map((response: Response) => response.json())
//      .catch(this.errorHandler)
//  }
//  errorHandler(error: Response) {
//    console.log(error);
//    return Observable.throw(error);
//  }
//}
//# sourceMappingURL=booking.service.js.map