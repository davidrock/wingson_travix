using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Core.Services
{
    public class FlightService : IFlightService
    {
        public FlightService()
        {
        }

        public List<Person> GetFlightPassengers(string flightNumber)
        {
            if (String.IsNullOrEmpty(flightNumber))
                throw new Exception("Flight Number is required");

            var flightRep = new FlightRepository();
            var bookingRep = new BookingRepository();

            var f = flightRep.GetFlightByNumber(flightNumber);

            if (f == null)
                throw new Exception("Flight not found");

            var booking = bookingRep.GetBookingByFlightId(f.Id);
            var passengers = booking.Passengers;

            return passengers.ToList();
        }
    }
}
