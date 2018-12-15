using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Core.ViewModels;
using WingsOn.Domain;

namespace WingsOn.Core.Services
{
    public interface IPersonService
    {
        Task<Person> GetPersonById(int id);
        Task<List<Person>> FilterPersons(PersonFilterViewModel filters);
    }
}
