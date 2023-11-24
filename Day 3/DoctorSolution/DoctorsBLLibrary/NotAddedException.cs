﻿using System.Runtime.Serialization;

namespace DoctorsBLLibrary
{
    [Serializable]
    public class NotAddedException : Exception
    {
        string message;
        public NotAddedException()
        {
            message = "Product was not addedd.";
        }
        public override string Message => message;

    }
}