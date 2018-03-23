namespace GitFetcher
{
    using System.Threading.Tasks;

    public class MainProgram
    {
        private readonly Config config;

        private readonly Fetcher fetcher;

        private readonly Logger logger;
    
        public MainProgram(Fetcher fetcher, Config config, Logger logger)
        {
            this.config = config;
            this.logger = logger;
            this.fetcher = fetcher;
        }

        public async Task GoAsync()
        {
            this.LogConfigurationSettings();

            do
            {
                this.logger.Log("doing a fetch");
                this.fetcher.DoAFetch();
                this.logger.Log("fetch finished");
                await this.WaitForTheNextPoll();
            }
            while (true);
        }


        private void LogConfigurationSettings()
        {
            this.logger.Log($"Path - {this.config.RepoPath}");
            this.logger.Log($"Polling frequency - {this.config.PollFrequency}");
            this.logger.Log(string.Empty);
        }

        private async Task WaitForTheNextPoll() => await Task.Delay(this.config.PollFrequency);
    }
}