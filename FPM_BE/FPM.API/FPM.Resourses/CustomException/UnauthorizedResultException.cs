using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.CustomException
{
    public sealed class UnauthorizedResultException : Exception
    {
        #region Constructor
        public UnauthorizedResultException()
        {
        }

        public UnauthorizedResultException(string message)
            : base(message)
        {
        }

        public UnauthorizedResultException(string message, Exception inner)
            : base(message, inner)
        {
        }
        #endregion
    }
}
