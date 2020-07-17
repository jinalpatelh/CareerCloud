using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class ValidationException : Exception
    {
        public int _code { get; set; }
        public ValidationException(int code, string message) : base(message)
        {
            _code = code;
        }
    }
}
