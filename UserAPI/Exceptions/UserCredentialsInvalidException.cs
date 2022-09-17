using System;

namespace UserAPI.Exceptions
{
    public class UserCredentialsInvalidException : ApplicationException
    {
        public UserCredentialsInvalidException()
        {

        }
        public UserCredentialsInvalidException(string message) : base(message)
        {

        }
    }
}
