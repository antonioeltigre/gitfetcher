namespace GitFetcher
{
    using System;
    using System.Configuration;

    public class Config
    {
        public TimeSpan PollFrequency => TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings["pollFrequencyInMinutes"]));

        public string RepoPath => ConfigurationManager.AppSettings["path"];
    }
}