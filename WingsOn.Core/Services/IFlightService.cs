using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain;

namespace WingsOn.Core.Services
{
    public interface IFlightService
    {
        Person GetFlightPassengers(int flightId);
    }
}
