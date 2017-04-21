using System;
using System.Threading;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    public static class DelegateExtensions
    {
        public static void Execute(this Action action)            
        {
            Execute<Exception>(action, 4, TimeSpan.FromSeconds(2));
        }

        public static void Execute<TException>(this Action action)
            where TException : Exception
        {
            Execute<TException>(action, 4, TimeSpan.FromSeconds(2));
        }

        public static TResult ExecuteWithResult<TException, TResult>(this Func<TResult> func)
            where TException : Exception
        {
            return ExecuteWithResult<TException, TResult>(func, 4, TimeSpan.FromSeconds(2));
        }

        public static void Execute<TException>(this Action action, int numberOfRetries, TimeSpan waitingInterval)
            where TException : Exception
        {
            TException lastException = null;
            for (int i = 0; i < numberOfRetries; i++)
            {
                try
                {
                    action();
                    return;
                }
                catch (TException ex)
                {
                    lastException = ex;
                    Thread.Sleep(waitingInterval);
                }
            }
            if (lastException != null)
            {
                throw lastException;
            }
        }

        public static TResult ExecuteWithResult<TException, TResult>(this Func<TResult> func, int numberOfRetries, TimeSpan waitingInterval)
            where TException : Exception
        {
            TException lastException = null;
            for (int i = 0; i < numberOfRetries; i++)
            {
                try
                {
                    return func();
                }
                catch (TException ex)
                {
                    lastException = ex;
                    Thread.Sleep(waitingInterval);
                }
            }
            if (lastException != null)
            {
                throw lastException;
            }
            return default(TResult);
        }
    }
}