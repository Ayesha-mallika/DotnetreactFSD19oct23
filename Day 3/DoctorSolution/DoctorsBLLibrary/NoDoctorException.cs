using System.Runtime.Serialization;

namespace DoctorsBLLibrary
{
    [Serializable]
    public class NoDoctorException : Exception
    {
        string message;
        public NoDoctorException()
        {
            message = "No doctors are available currently";
        }

        public override string Message => message;
    }
}