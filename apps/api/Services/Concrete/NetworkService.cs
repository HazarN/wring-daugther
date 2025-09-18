using System.Net.NetworkInformation;
using System.Net.Sockets;
using api.Services;

namespace api.Services
{
    public class NetworkService : INetworkService
    {
        private readonly string?[] _envIps;

        public NetworkService(IConfiguration config)
        {
            _envIps = [
                config["IP_MAIN"],
                config["IP_ANK"],
                config["IP_FO"]
            ];
        }

        public string? GetActiveIp()
        {
            var localIps = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(i => i.OperationalStatus == OperationalStatus.Up)
                .SelectMany(i => i.GetIPProperties().UnicastAddresses)
                .Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
                .Select(a => a.Address.ToString())
                .ToList();

            return localIps.FirstOrDefault(ip => _envIps.Contains(ip));
        }
    }
}
