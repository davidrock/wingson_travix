using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Core.ViewModels;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Core.Services
{
    public class PersonService : IPersonService
    {
        public async Task<Person> GetPersonById(int id)
        {
            if (id <= 0)
                throw new Exception("The Id param should be greater than 0");

            var rep = new PersonRepository();
            var p = rep.Get(id);

            if (p != null)
                return p;

            throw new Exception("Person not found");
        }

        public async Task<List<Person>> FilterPersons(PersonFilterViewModel filters)
        {
            if (filters.Gender == null)
                return new List<Person>();

            if (Enum.IsDefined(typeof(GenderType), filters.Gender))
            {
                var gender = (GenderType)filters.Gender;

                var rep = new PersonRepository();
                return rep.GetAll().Where(x => x.Gender == gender).ToList();
            }
            else
            {
                throw new Exception("Gender not recognized");
            }


        }
    }
}
