using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain;

namespace WingsOn.Core.Services
{
    public interface IFlightService
    {
        List<Person> GetFlightPassengers(string flightId);
    }
}
