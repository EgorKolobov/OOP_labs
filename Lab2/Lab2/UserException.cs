using System;
using System.Linq;
namespace Lab2
{
    public class UserException: ApplicationException
    {
        public UserException() { }
        public UserException(string message) : base(message) { }
        public UserException(string message, Exception inner) : base(message, inner) { }
    }
}