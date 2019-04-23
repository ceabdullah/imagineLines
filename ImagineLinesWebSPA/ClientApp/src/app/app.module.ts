import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { BookingComponent } from './booking/booking.component';
import { BookingService } from './booking/booking.service';
import { ConfigurationService } from '../shared/services/configuration.service';
import { HttpModule } from '@angular/http';
import { StorageService } from '../shared/services/storage.service';
import { MatIconModule, MatNativeDateModule, MatDatepickerModule, MatTableModule, MatDialogModule, MatFormFieldModule, MatButtonModule, MatInputModule, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BookingModalComponent } from './booking/booking-detail-dialog.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    BookingComponent,
    BookingModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    MatTableModule,
    MatDialogModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    MatNativeDateModule,
    MatIconModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'booking', component: BookingComponent },
    ])
  ],
  providers: [BookingService, ConfigurationService, StorageService, { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: true, direction: 'ltr' } }],
  bootstrap: [AppComponent],
  entryComponents: [BookingModalComponent]
})
export class AppModule { }
