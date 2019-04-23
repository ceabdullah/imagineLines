import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { BookingDetailDialogData } from './booking-detail-dialog-data';

@Component({
  selector: 'booking-detail-dialog',
  templateUrl: './booking-detail-dialog.component.html',
  styleUrls: ['./booking-detail-dialog.component.css']
})
export class BookingModalComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<BookingModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: BookingDetailDialogData) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
  }

}
