﻿
namespace Library.BLL.Validation
{
    
        public class ValidationException : Exception
        {
            public ValidationException(string message) : base(message)
            {

            }
            public class NotFoundException : Exception
            {
                public NotFoundException(string message) : base(message)
                {
                }
            }
        }
    
}
