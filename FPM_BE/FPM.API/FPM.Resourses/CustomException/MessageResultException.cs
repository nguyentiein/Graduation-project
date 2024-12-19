using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPM.Resourses.CustomException
{
    public sealed class MessageResultException : Exception
    {
        #region Constructor
        public MessageResultException()
        {
        }

        public MessageResultException(string message)
            : base(message)
        {
        }

        public MessageResultException(string message, Exception inner)
            : base(message, inner)
        {
        }
        #endregion
    }
}
