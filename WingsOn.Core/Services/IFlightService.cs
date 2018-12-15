using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Domain;

namespace WingsOn.Core.Services
{
    public interface IFlightService
    {
        Task<List<Person>> GetFlightPassengers(string flightId);
    }
}
