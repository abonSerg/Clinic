using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Clinic.Client.Model
{
    public class Validation
    {
        private static Validation instance;

        public static Validation Instance 
        {
            get
            {
                instance = instance ?? new Validation();
                 return instance;
            }
        }

        public bool ValidateCode(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
