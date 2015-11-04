using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medicine.Clinic.DataAccess.EntitiesException.TubeExceptions
{
    class TubeVolumeException : TubeException
    {
        public TubeVolumeException()
            : base("Volume must be <= 1000")
        {
        }
    }
}
