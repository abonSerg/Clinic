using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medicine.Clinic.DataAccess.EntitiesException.SpecimenException
{
    class SpecimenMandatoryFieldsException : SpecimenException 
    {
        public SpecimenMandatoryFieldsException()
            :base("Fill mandatory fields!")
        {
        }
    }
}
