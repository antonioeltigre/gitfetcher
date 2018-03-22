namespace GitFetcher
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.Out.WriteLine("doing a fetch");

                var processInfo = GetProcessInfo(@"E:\Repo\GitActisure");

                var process = Process.Start(processInfo);

                LogProcessOutput(process);

                Console.Out.WriteLine("fetch finished");
                Wait();
            }
            while (true);
        }

        private static ProcessStartInfo GetProcessInfo(string path)
        {
            return new ProcessStartInfo
                       {
                           UseShellExecute = false,
                           RedirectStandardOutput = true,
                           WorkingDirectory = path,
                           FileName = @"C:\Windows\System32\cmd.exe",
                           Verb = "runas",
                           Arguments = "/c " + "git svn fetch",
                           WindowStyle = ProcessWindowStyle.Hidden
                       };
        }

        private static void Wait() => Thread.Sleep((int)TimeSpan.FromMinutes(1).TotalMilliseconds);

        private static void LogProcessOutput(Process process) => Console.Out.WriteLine(process.StandardOutput.ReadToEnd());
    }
}