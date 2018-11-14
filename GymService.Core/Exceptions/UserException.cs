using System;
using System.Collections.Generic;
using System.Text;

namespace GymService.Core.Exceptions
{
    public class UserException : Exception
    {
        public string Code { get; }

        protected UserException()
        {
        }

        protected UserException(string code)
        {
            Code = code;
        }

        protected UserException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected UserException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected UserException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected UserException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
