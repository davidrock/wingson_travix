using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain;

namespace WingsOn.Dal.Interfaces
{
    public interface IFlightRepository : IRepository<Flight>
    {
        Flight GetFlightByNumber(string number);
    }
}
