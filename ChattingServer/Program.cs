using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using ChattingLibrary;
namespace ChattingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            EnkripsiDekripsi coba = new EnkripsiDekripsi();
            string enkripsi = coba.Enkripsi("Saya lagi menonton bola");
            Console.WriteLine(enkripsi);
            string dekripsi = coba.Dekripsi(enkripsi);
            Console.WriteLine(dekripsi);

            TcpChannel tcpChannel = new TcpChannel(1234);
            
            ChannelServices.RegisterChannel(tcpChannel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Chatting), "RemoteChatting", WellKnownObjectMode.SingleCall);

            Console.WriteLine("\r\nServer Chatting Running");
            Console.WriteLine("\r\nPress enter to exit");
            Console.ReadLine();
            
        }
    }
}
