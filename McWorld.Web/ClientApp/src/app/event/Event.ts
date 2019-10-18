import Route from '../route/Models/Route';
export default interface Event {
  eventID: number;
  headline: string
  description: string;
  startDate: string;
  startTime: string;
  endDate: string
  endTime: string;
  registrationCount: number;
  created: string
  userID: number;
  route: Route
}
