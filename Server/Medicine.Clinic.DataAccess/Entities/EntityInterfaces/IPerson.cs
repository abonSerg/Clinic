using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medicine.Clinic.DataAccess
{
    public interface IPerson
    {
        string LastName  { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }

    }
}
