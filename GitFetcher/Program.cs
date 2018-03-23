namespace GitFetcher
{
    using System.Threading.Tasks;

    public class Program
    {
        public static async Task Main()
        {
            var config = new Config();
            var logger = new Logger();
            var fetcher = new Fetcher(config, logger);

            await new MainProgram(fetcher, config, logger).GoAsync();
        }
    }
}