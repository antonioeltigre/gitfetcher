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
            try
            {
                this.StartProcess();
            }
            catch (Exception e)
            {
                this.logger.Log(e);
            }
        }

        private void StartProcess()
        {
            var process = new Process { StartInfo = this.GetProcessInfo() };

            process.OutputDataReceived += (o, args) => this.logger.Log(args.Data);
            process.Start();
            process.BeginOutputReadLine();
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
                           WindowStyle = ProcessWindowStyle.Hidden,
                           RedirectStandardOutput = true
        };
        }
    }
}