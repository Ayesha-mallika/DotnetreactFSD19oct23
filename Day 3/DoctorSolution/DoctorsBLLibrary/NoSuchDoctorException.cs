using System.Runtime.Serialization;

namespace DoctorsBLLibrary
{
    [Serializable]
    public class NoSuchDoctorException : Exception
    {
        string message;
        public NoSuchDoctorException()
        {
            message = "The Doctor with the given id is not present";
        }
        public override string Message => message;


    }
}
