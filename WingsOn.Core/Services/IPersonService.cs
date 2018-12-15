using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Core.ViewModels;
using WingsOn.Domain;

namespace WingsOn.Core.Services
{
    public interface IPersonService
    {
        Person GetPersonById(int id);
        List<Person> FilterPersons(PersonFilterViewModel filters);
    }
}
