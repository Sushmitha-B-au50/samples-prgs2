using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraansportManagementBLLibrary
{
    public class UnableToAddEmployeeException : ApplicationException
    {
        string _message;
        public UnableToAddEmployeeException()
        {
            _message = "unable to add employee cos of ID duplication . Try again";
        }

        public override string Message => _message;
    }
}
