using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain;

namespace WingsOn.Core.Services
{
    public interface IPersonService
    {
        Person GetPersonById(int id);
    }
}
