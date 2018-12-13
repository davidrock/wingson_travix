using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Core.Services
{
    public class PersonService : IPersonService
    {
        public Person GetPersonById(int id)
        {
            if (id <= 0)
                throw new Exception("The Id param should be greater than 0");

            var rep = new PersonRepository();
            var p = rep.Get(id);

            if (p != null)
                return p;

            throw new Exception("Person not found");
        }
    }
}
