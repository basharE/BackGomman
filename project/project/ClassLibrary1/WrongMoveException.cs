using System;
using System.Runtime.Serialization;

namespace Control
{
    [Serializable]
    internal class WrongMoveException : Exception
    {
        public WrongMoveException()
        {
        }     

        protected WrongMoveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}