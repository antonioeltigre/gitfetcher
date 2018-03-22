namespace GitFetcher
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class Program
    {
        private static TimeSpan PollFrequency => TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings["pollFrequencyInMinutes"]));

        private static string RepoPath => ConfigurationManager.AppSettings["path"];

        public static async Task Main()
        {
            LogConfigurationSettings();

            do
            {
                Console.Out.WriteLine("doing a fetch");

                var processInfo = GetProcessInfo();
                var process = Process.Start(processInfo);

                LogProcessOutput(process);

                Console.Out.WriteLine("fetch finished");
                await Wait();
            }
            while (true);
        }

        private static void LogConfigurationSettings()
        {
            Console.Out.WriteLine($"Path - {RepoPath}");
            Console.Out.WriteLine($"Polling frequency - {PollFrequency}");
            Console.Out.WriteLine();
        }

        private static ProcessStartInfo GetProcessInfo()
        {
            return new ProcessStartInfo
                       {
                           UseShellExecute = false,
                           RedirectStandardOutput = true,
                           WorkingDirectory = RepoPath,
                           FileName = @"C:\Windows\System32\cmd.exe",
                           Verb = "runas",
                           Arguments = "/c " + "git svn fetch",
                           WindowStyle = ProcessWindowStyle.Hidden
                       };
        }

        private static async Task Wait() => await Task.Delay(PollFrequency);

        private static void LogProcessOutput(Process process) => Console.Out.WriteLine(process.StandardOutput.ReadToEnd());
    }
}