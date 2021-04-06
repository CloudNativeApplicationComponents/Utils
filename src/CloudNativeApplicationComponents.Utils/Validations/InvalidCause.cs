using System;

namespace CloudNativeApplicationComponents.Utils
{
    public class InvalidCause
    {
        public const int DefaultErrorCode = -1;

        public InvalidCause(ValidationLevel level, string message, int code)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            Message = message;
            Level = level;
            Code = code;
        }

        public InvalidCause(ValidationLevel level, string message)
            : this(level, message, DefaultErrorCode)
        {

        }

        public string Message { get; }
        public ValidationLevel Level { get; }
        public int Code { get; }
    }
}
