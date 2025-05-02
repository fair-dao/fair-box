using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace FairBox.H5
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            return builder.RunFairHost(
                new fairdao.extensions.shared.Extender("Fair Box","Fair Dao","1.0"),
                 new FairBox.Wallet.Extender(),
                new FairBox.SuperHost.Extender());
        }
    }
}
