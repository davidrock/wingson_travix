using System;
using System.Globalization;
using System.Linq;
using WingsOn.Dal.Interfaces;
using WingsOn.Domain;

namespace WingsOn.Dal
{
    public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {

        private readonly IPersonRepository _personRepository;
        private readonly IFlightRepository _flightRepository;

        public BookingRepository(PersonRepository personRepository, FlightRepository flightRepository)
        {
            _personRepository = personRepository;
            _flightRepository = flightRepository;

            //PersonRepository _personRepository = new PersonRepository();
            //FlightRepository _flightRepository = new FlightRepository();
            CultureInfo cultureInfo = new CultureInfo("nl-NL");

            Repository.AddRange(new[]
            {
                new Booking
                {
                    Id = 55,
                    Number = "WO-291470",
                    Customer = _personRepository.GetAll().Single(p => p.Name == "Branden Johnston"),
                    DateBooking = DateTime.Parse("03/03/2006 14:30", cultureInfo),
                    Flight = _flightRepository.GetAll().Single(f => f.Number == "BB768"),
                    Passengers = new []
                    {
                        _personRepository.GetAll().Single(p => p.Name == "Branden Johnston")
                    }
                },
                new Booking
                {
                    Id = 83,
                    Number = "WO-151277",
                    Customer = _personRepository.GetAll().Single(p => p.Name == "Debra Lang"),
                    DateBooking = DateTime.Parse("12/02/2000 12:55", cultureInfo),
                    Flight = _flightRepository.GetAll().Single(f => f.Number == "PZ696"),
                    Passengers = new []
                    {
                        _personRepository.GetAll().Single(p => p.Name == "Claire Stephens"),
                        _personRepository.GetAll().Single(p => p.Name == "Kendall Velazquez"),
                        _personRepository.GetAll().Single(p => p.Name == "Zenia Stout")
                    }
                },
                new Booking
                {
                    Id = 34,
                    Number = "WO-694142",
                    Customer = _personRepository.GetAll().Single(p => p.Name == "Kathy Morgan"),
                    DateBooking = DateTime.Parse("13/02/2000 16:37", cultureInfo),
                    Flight = _flightRepository.GetAll().Single(f => f.Number == "PZ696"),
                    Passengers = new []
                    {
                        _personRepository.GetAll().Single(p => p.Name == "Kathy Morgan"),
                        _personRepository.GetAll().Single(p => p.Name == "Melissa Long")
                    }
                },
                new Booking
                {
                    Id = 90,
                    Number = "WO-139716",
                    Customer = _personRepository.GetAll().Single(p => p.Name == "Bonnie Rice"),
                    DateBooking = DateTime.Parse("03/12/2011 16:50", cultureInfo),
                    Flight = _flightRepository.GetAll().Single(f => f.Number == "BB124"),
                    Passengers = new []
                    {
                        _personRepository.GetAll().Single(p => p.Name == "Bonnie Rice"),
                        _personRepository.GetAll().Single(p => p.Name == "Louise Harper")
                    }
                }
            });
        }

        public Booking GetBookingByFlightId(int flightId)
        {
            return Repository.FirstOrDefault(x => x.Flight.Id == flightId);
        }
    }
}
