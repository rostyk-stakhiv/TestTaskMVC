using System;
using System.Runtime.Serialization;

namespace BLL.Validations
{
    public class TestTaskException : Exception
    {
        public TestTaskException()
        {
        }

        public TestTaskException(string message) : base(message)
        {
        }

        public TestTaskException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TestTaskException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
