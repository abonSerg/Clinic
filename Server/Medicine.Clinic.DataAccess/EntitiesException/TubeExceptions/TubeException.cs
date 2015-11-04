using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medicine.Clinic.DataAccess.EntitiesException.TubeExceptions
{
    class TubeException : Exception
    {
        public TubeException(string message)
            : base(message)
        {
        }
    }
}
