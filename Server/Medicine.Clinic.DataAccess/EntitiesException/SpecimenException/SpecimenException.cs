using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medicine.Clinic.DataAccess.EntitiesException.SpecimenException
{
    public class SpecimenException : Exception
    {
        public SpecimenException(string message)
            :base(message)
        {

        }
    }
}
