using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medicine.Clinic.DataAccess.EntitiesException.TubeExceptions
{
    class TubeMandatoryFieldsException : TubeException
    {
        public TubeMandatoryFieldsException()
            : base("'Code'and 'Name' properties are mandatory!")
        {
        }
    }
}
