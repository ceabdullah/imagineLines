import { IShip } from './ship.model';

export interface IBooking {
  id: number;
  ship: IShip;
  bookingDate: Date;
  price: number;
}
