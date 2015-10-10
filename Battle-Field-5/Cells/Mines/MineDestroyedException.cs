namespace MineFieldApp.Cells.Mines
{
    using System;
    using System.Runtime.Serialization;

    public class MineDestroyedException : SystemException
    {
        public MineDestroyedException()
            : base()
        {
        }

        public MineDestroyedException(string message)
            : base(message)
        {
        }

        public MineDestroyedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MineDestroyedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}