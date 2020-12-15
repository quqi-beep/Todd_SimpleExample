using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToddDemo.Application.Extensions
{
    public class KnownException : Exception, IKnownException
    {
        public KnownException()
        {

        }
        public KnownException(int errorCode,string message):base(message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public new string Message { get; private set; }

        public int ErrorCode { get; private set; }

        public object[] ErrorData { get; private set; }

        public readonly static IKnownException UnKnown = new KnownException { Message = "未知的系统异常", ErrorCode = 9999 };

        public static KnownException FromKnownException(IKnownException exception)
        {
            return new KnownException { Message = exception.Message, ErrorCode = exception.ErrorCode, ErrorData = exception.ErrorData };
        }
    }
}
