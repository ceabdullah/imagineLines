import { OnInit, Component } from '@angular/core';
import { BookingService } from './booking.service';
import { ConfigurationService } from '../../shared/services/configuration.service';
import { MatDialog, MatDatepickerInputEvent } from '@angular/material';
import { ISalesUnit } from './sales-unit.model';
import { BookingModalComponent } from './booking-detail-dialog.component';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'booking',
  styleUrls: ['./booking.component.css'],
  templateUrl: './booking.component.html'
})
export class BookingComponent implements OnInit {

  bookings: ISalesUnit[];
  startDate: FormControl;
  endDate: FormControl;

  minDate: Date;
  maxDate: Date;

  bookingId: FormControl;
  shipName: FormControl;

  constructor(private bookingService: BookingService, private configurationService: ConfigurationService, public dialog: MatDialog) {

  }

  ngOnInit(): void {

    this.minDate = new Date(2015, 3, 21);
    this.maxDate = new Date(2017, 2, 20);

    this.startDate = new FormControl(new Date(2015, 4, 1));
    this.endDate = new FormControl(new Date(2015, 10, 1));

    this.bookingId = new FormControl();
    this.shipName = new FormControl();

    // Configuration Settings:
    if (this.configurationService.isReady) {
      this.getBookings(
        new Date(2015, 4, 1).toISOString(),
        new Date(2015, 10, 1).toISOString(),
        this.bookingId.value,
        this.shipName.value
      );
    }
    else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.getBookings(
          new Date(2015, 4, 1).toISOString(),
          new Date(2015, 10, 1).toISOString(),
          this.bookingId.value,
          this.shipName.value
        );
      });
    }
  }

  getBookings(minDate: string, maxDate: string, bookingId: number, shipName: string) {
    this.bookingService.getBookings(minDate, maxDate, bookingId, shipName).subscribe(bookings => {
      this.bookings = bookings;
    }, error => console.error(error));
  }

  openBookingDetail(bookings: string, currency: string): void {
    const dialogRef = this.dialog.open(BookingModalComponent, {
      width: '100%',
      data: { bookings: bookings, currency: currency }
    });

    dialogRef.afterClosed().subscribe(result => { });
  }

  startDateEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    this.getBookings(
      this.startDate.value.toISOString(),
      this.endDate.value.toISOString(),
      this.bookingId.value,
      this.shipName.value
    );
  }

  endDateEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    this.getBookings(
      this.startDate.value.toISOString(),
      this.endDate.value.toISOString(),
      this.bookingId.value,
      this.shipName.value
    );
  }


  searchEvent() {
    this.getBookings(
      this.startDate.value.toISOString(),
      this.endDate.value.toISOString(),
      this.bookingId.value,
      this.shipName.value
    );
  }
}
