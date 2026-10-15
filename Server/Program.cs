using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Server;


class Program
{
    static async Task Main(string[] args)
    {
        var listener = new Socket(
                addressFamily: AddressFamily.InterNetwork,
                socketType: SocketType.Dgram,
                protocolType: ProtocolType.Udp
            );

        var ip = IPAddress.Parse("127.0.0.1");
        var port = 4567;

        var listenerEp = new IPEndPoint(ip, port);

        listener.Bind(listenerEp);

        var count = 0;
        var msj = string.Empty;
        var buffer = new byte[ushort.MaxValue - 1];

        var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0) as EndPoint;

        Console.WriteLine("Server islek vezyetdedir.....");


        while (true)
        {
            var result = await listener.ReceiveFromAsync(
                    new ArraySegment<byte>(buffer),
                    socketFlags: SocketFlags.None,
                    remoteEndPoint: remoteEndPoint
                );

            count = result.ReceivedBytes;

            msj = Encoding.Default.GetString(buffer, 0, count);

            Console.WriteLine($"RemoteEnd Point: {result.RemoteEndPoint} => {msj}");

        }

    }
}