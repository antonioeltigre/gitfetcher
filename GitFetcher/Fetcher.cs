namespace GitFetcher
{
    using System;
    using System.Diagnostics;
    using System.IO;

    public class Fetcher
    {
        private readonly Config config;

        private readonly Logger logger;

        public Fetcher(Config config, Logger logger)
        {
            this.config = config;
            this.logger = logger;
        }

        public void DoAFetch()
        {
            var processInfo = this.GetProcessInfo();
            var process = Process.Start(processInfo);

            if (process == null)
            {
                this.logger.Log($"Unable to start process {processInfo.FileName}");
                return;
            }

            process.WaitForExit();
        }

        private ProcessStartInfo GetProcessInfo()
        {
            return new ProcessStartInfo
                       {
                           UseShellExecute = false,
                           WorkingDirectory = this.config.RepoPath,
                           FileName = Path.Combine(Environment.SystemDirectory, "cmd.exe"),
                           Verb = "runas",
                           Arguments = "/c " + "git svn fetch",
                           WindowStyle = ProcessWindowStyle.Hidden
                       };
        }
    }
}