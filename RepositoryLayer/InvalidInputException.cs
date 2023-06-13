using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class InvalidInputException:Exception
    {
        public enum ExceptionType
        {
            ENTERED_DUPLICATE_ADMIN, ENTERED_DUPLICATE_USER, ENTERED_INVALID_EMAIL
        }

        public ExceptionType type;

        public InvalidInputException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
