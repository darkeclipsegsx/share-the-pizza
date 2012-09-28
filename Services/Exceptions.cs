/* Exceptions.cs
 * Last Modified: Sept. 20, 2012
 * Nicole Reed
 * 
 * Contains all the homegrown exceptions related to Share the Pizza's backend
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareThePizza
{
    [Serializable]
    public class Exceptions : Exception
    {
        public string ErrorMessage
        {
            get
            {
                return base.Message.ToString();
            }
        }
        public Exceptions(string errorMessage) : base(errorMessage) { }
        public Exceptions(string errorMessage, Exception innerEx) : base(errorMessage, innerEx) { }

    }

    public class InvalidPasswordException : Exceptions
    {
        public InvalidPasswordException(string errorMessage) : base(errorMessage) { }
        public InvalidPasswordException(string errorMessage, Exception innerEx) : base(errorMessage, innerEx) { }

    }
    public class InvalidUserException : Exceptions
    {
        public InvalidUserException(string errorMessage) : base(errorMessage) { }
        public InvalidUserException(string errorMessage, Exception innerEx) : base(errorMessage, innerEx) { }

    }
}
