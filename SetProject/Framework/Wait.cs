using System;
using System.Threading;

namespace SetProject.Framework
{
    public abstract class Wait
    {
        public static bool WaitFor(Func<bool> func, int timeOut = 250, int interval = 50)
        {
            DateTime start = DateTime.Now;
            do
            {
                if (func())
                    return true;
                Thread.Sleep(interval);
            } while (DateTime.Now - start < TimeSpan.FromMilliseconds(timeOut));

            return false;
        }
    }
}