using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Sockets;

namespace MoLIC_WOz_Core.Control
{
    class TcpServer
    {
        int portNumber = 3553;
        private Socket socket;
        private Thread thread;
        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;
        private static TcpServer tcpServerInstance = null;

        public static TcpServer getInstance()
        {
            if (tcpServerInstance == null)
                tcpServerInstance = new TcpServer();
            return tcpServerInstance;
        }

        public TcpServer()
        {
            thread = new Thread(new ThreadStart(RunServer));
            thread.Start();
        }

        public void RunServer()
        {
            TcpListener tcpListener = null;
            IPEndPoint ipEndPoint = null;
            try
            {
                try
                {
                    ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), portNumber);
                }
                catch
                {
                    portNumber++;
                }
                tcpListener = new TcpListener(ipEndPoint);
                tcpListener.Start();
 
                //MessageBox.Show("Servidor habilitado e escutando porta...", "Server App");
 
                socket = tcpListener.AcceptSocket();
                networkStream = new NetworkStream(socket);
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);
 
                //MessageBox.Show("conexão recebida!", "Server App");
                binaryWriter.Write("\nconexão efetuada!");
 
                string messageReceived = "";
                do 
                {
                    messageReceived = binaryReader.ReadString();
                    //MessageBox.Show("Mensagem: " + messageReceived, "Server App");
 
                } while (socket.Connected);
            } 
            catch (Exception ex) 
            {
                //MessageBox.Show(ex.Message);
            } 
            finally 
            {
                binaryReader.Close();
                binaryWriter.Close();
                networkStream.Close();
                socket.Close();
 
                //MessageBox.Show("conexão finalizada", "Server App");
            }
        }
    
        public void sendMsg (string msg)
        {
            try
            {
                binaryWriter.Write(msg);
            }
            catch
            {
                //MessageBox.Show(socketEx.Message, "Erro");
            }
        }
    
    }
}