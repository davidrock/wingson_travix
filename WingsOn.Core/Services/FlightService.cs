using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Dal;
using WingsOn.Dal.Interfaces;
using WingsOn.Domain;

namespace WingsOn.Core.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IBookingRepository _bookingRepository;

        public FlightService(IFlightRepository flightRepository, IBookingRepository bookingRepository)
        {
            _flightRepository = flightRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<List<Person>> GetFlightPassengers(string flightNumber)
        {
            if (String.IsNullOrEmpty(flightNumber))
                throw new Exception("Flight Number is required");

            //var flightRep = new FlightRepository();
            //var bookingRep = new BookingRepository();

            var f = _flightRepository.GetFlightByNumber(flightNumber);

            if (f == null)
                throw new Exception("Flight not found");

            var booking = _bookingRepository.GetBookingByFlightId(f.Id);
            var passengers = booking.Passengers;

            return passengers.ToList();
        }
    }
}
