using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medicine.Clinic.DataAccess.EntitiesException.SpecimenException
{
    class SpecimenDefaultTubeException : SpecimenException 
    {
        public SpecimenDefaultTubeException()
            :base("Choose default tude!")
        {

        }

    }
}
