namespace GitFetcher
{
    using System.Reflection;
    using System.Threading.Tasks;

    using Stashbox;

    public class Program
    {
        public static async Task Main() => await MainProgram().GoAsync();

        private static MainProgram MainProgram() => Container().Resolve<MainProgram>();

        private static IStashboxContainer Container() => new StashboxContainer().RegisterAssembly(Assembly.GetExecutingAssembly());
    }
}