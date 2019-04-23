import { IBooking } from './booking.model';

export interface ISalesUnit {
  id: number;
  name: string;
  country: string;
  currency: string;

  totalPrice: number;

  bookings: IBooking[];
}
