using System;

namespace Billy.Exceptions
{
    public class ErrorLongPollException : Exception
    {
        public ErrorLongPollException() :base ("Возникла ошибка при работе LongPoll")
        {

        }
    }
}
