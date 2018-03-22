namespace GitFetcher
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            do
            {
                Console.Out.WriteLine("doing a fetch");

                var processInfo = GetProcessInfo(@"E:\Repo\GitActisure");

                var process = Process.Start(processInfo);

                LogProcessOutput(process);

                Console.Out.WriteLine("fetch finished");
                await Wait();
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

        private static async Task Wait() => await Task.Delay(TimeSpan.FromMinutes(1));

        private static void LogProcessOutput(Process process) => Console.Out.WriteLine(process.StandardOutput.ReadToEnd());
    }
}