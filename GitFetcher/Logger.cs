namespace GitFetcher
{
    using System;

    public class Logger
    {
        public void Log(string message)
        {
            Console.Out.WriteLine(message);
        }

        public void Log(Exception exception)
        {
            Console.Out.WriteLine(exception.Message);
        }
    }
}