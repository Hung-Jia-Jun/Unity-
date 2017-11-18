using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;
public class SocketTest : MonoBehaviour 
{
	void Start()
	{
		Thread t1 = new Thread(StartSocket);
		t1.Start();
	}
	byte[] bytes = new Byte[1024];
	string data=null;
	Socket listener;

	// Use this for initialization
	void StartSocket () 
	{
		


		// Data buffer for incoming data.
		byte[] bytes = new Byte[1024];

		// Establish the local endpoint for the socket.
		// Dns.GetHostName returns the name of the 
		// host running the application.
		//IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
		//IPAddress ipAddress = ipHostInfo.AddressList[0];
		IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 10000);

		// Create a TCP/IP socket.
		Socket listener = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp );

		// Bind the socket to the local endpoint and 
		// listen for incoming connections.
		listener.Bind(localEndPoint);
		listener.Listen(10);

		// Start listening for connections.
		while (true) {
			print ("Wait for client");
			Socket handler = listener.Accept ();
			data = null;

			// An incoming connection needs to be processed.
			while (true) {
				bytes = new byte[1024];
				int bytesRec = handler.Receive (bytes);
				data += Encoding.ASCII.GetString (bytes, 0, bytesRec);
				print (data);
			}


			// Echo the data back to the client.
			byte[] msg = Encoding.ASCII.GetBytes (data);

			handler.Send (msg);
			handler.Shutdown (SocketShutdown.Both);
			handler.Close ();
		}
	}
	

}
