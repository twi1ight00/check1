using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

namespace LumiSoft.Net.NNTP.Client;

public class NNTP_Client : IDisposable
{
	private SocketEx m_pSocket = null;

	private bool m_Connected = false;

	public bool Connected => m_Connected;

	public void Dispose()
	{
		Disconnect();
	}

	public void Connect(string server, int port)
	{
		if (m_Connected)
		{
			throw new Exception("NNTP client is already connected, Disconnect first before calling Connect !");
		}
		m_pSocket = new SocketEx();
		m_pSocket.Connect(server, port);
		m_Connected = true;
		string text = m_pSocket.ReadLine(1000);
		if (!text.StartsWith("200"))
		{
			throw new Exception(text);
		}
	}

	public void Disconnect()
	{
		try
		{
			if (m_Connected)
			{
				m_pSocket.WriteLine("QUIT");
				m_pSocket.Shutdown(SocketShutdown.Both);
			}
		}
		catch
		{
		}
		m_Connected = false;
		m_pSocket = null;
	}

	public string[] GetNewsGroups()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		m_pSocket.WriteLine("LIST");
		string text = m_pSocket.ReadLine(1000);
		if (!text.StartsWith("215"))
		{
			throw new Exception(text);
		}
		List<string> list = new List<string>();
		text = m_pSocket.ReadLine(1000);
		while (text != ".")
		{
			list.Add(text.Split(' ')[0]);
			text = m_pSocket.ReadLine(1000);
		}
		return list.ToArray();
	}

	public void PostMessage(string newsgroup, Stream message)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first");
		}
		m_pSocket.WriteLine("POST");
		string text = m_pSocket.ReadLine(1000);
		if (!text.StartsWith("340"))
		{
			throw new Exception(text);
		}
		m_pSocket.WritePeriodTerminated(message);
		text = m_pSocket.ReadLine(1000);
		if (!text.StartsWith("240"))
		{
			throw new Exception(text);
		}
	}
}
