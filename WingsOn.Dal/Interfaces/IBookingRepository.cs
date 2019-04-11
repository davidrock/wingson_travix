using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain;

namespace WingsOn.Dal.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Booking GetBookingByFlightId(int flightId);
    }
}
