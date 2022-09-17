using System;

namespace AirlineAPI.Exceptions
{
    public class CourseNotFoundException : ApplicationException
    {
        public CourseNotFoundException()
        {

        }
        public CourseNotFoundException(String message) : base(message)
        {

        }
    }
}
