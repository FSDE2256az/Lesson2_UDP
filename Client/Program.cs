using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Client;


class Program
{
    static void Main(string[] args)
    {
        var client = new Socket(
                addressFamily: AddressFamily.InterNetwork,
                socketType: SocketType.Dgram,
                protocolType: ProtocolType.Udp
            );

        var ip = IPAddress.Parse("127.0.0.1");
        var port = 4567;

        var remoteEp = new IPEndPoint(ip, port);


        var msj = string.Empty;
        var buffer = Array.Empty<byte>();
        var count = 0;

        while (true)
        {
            msj = Console.ReadLine() ?? "";
            buffer = Encoding.Default.GetBytes(msj);
            client.SendTo(buffer, remoteEp);

            Console.WriteLine($"Servere melumat gonderildi: {msj}");

        }
    }
}