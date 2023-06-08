using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LumiSoft.Net.FTP.Client;

public class FTP_Client : IDisposable
{
	private SocketEx m_pSocket = null;

	private bool m_Connected = false;

	private bool m_Authenticated = false;

	private bool m_Passive = true;

	public bool Connected => m_Connected;

	public bool Authenticated => m_Authenticated;

	public bool PassiveMode
	{
		get
		{
			return m_Passive;
		}
		set
		{
			m_Passive = value;
		}
	}

	public void Dispose()
	{
		Disconnect();
	}

	public void Connect(string host, int port)
	{
		m_pSocket = new SocketEx();
		m_pSocket.Connect(host, port);
		string text = m_pSocket.ReadLine();
		while (!text.StartsWith("220 "))
		{
			text = m_pSocket.ReadLine();
		}
		m_Connected = true;
	}

	public void Disconnect()
	{
		if (m_pSocket != null)
		{
			if (m_pSocket.Connected)
			{
				m_pSocket.WriteLine("QUIT");
			}
			m_pSocket = null;
		}
		m_Connected = false;
		m_Authenticated = false;
	}

	public void Authenticate(string userName, string password)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (m_Authenticated)
		{
			throw new Exception("You are already authenticated !");
		}
		m_pSocket.WriteLine("USER " + userName);
		string text = m_pSocket.ReadLine();
		if (text.StartsWith("331"))
		{
			m_pSocket.WriteLine("PASS " + password);
			text = m_pSocket.ReadLine();
			while (!text.StartsWith("230 "))
			{
				if (!text.StartsWith("230"))
				{
					throw new Exception(text);
				}
				text = m_pSocket.ReadLine();
			}
			m_Authenticated = true;
			return;
		}
		throw new Exception(text);
	}

	public void SetCurrentDir(string dir)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("CWD " + dir);
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("250"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public DataSet GetList()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		SetTransferMode(TransferMode.Ascii);
		Socket socket = null;
		MemoryStream memoryStream = new MemoryStream();
		string text = "";
		try
		{
			if (m_Passive)
			{
				socket = GetDataConnection(-1);
				m_pSocket.WriteLine("LIST");
				text = m_pSocket.ReadLine();
				if (!text.StartsWith("125") && !text.StartsWith("150"))
				{
					throw new Exception(text);
				}
			}
			else
			{
				int portA = Port();
				m_pSocket.WriteLine("LIST");
				text = m_pSocket.ReadLine();
				if (!text.StartsWith("125") && !text.StartsWith("150"))
				{
					throw new Exception(text);
				}
				socket = GetDataConnection(portA);
			}
			int num = 1;
			while (num > 0)
			{
				byte[] array = new byte[4000];
				num = socket.Receive(array, array.Length, SocketFlags.None);
				memoryStream.Write(array, 0, num);
			}
			if (socket != null)
			{
				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			}
		}
		catch (Exception ex)
		{
			if (socket != null)
			{
				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			}
			throw ex;
		}
		text = m_pSocket.ReadLine();
		while (!text.StartsWith("226 "))
		{
			if (!text.StartsWith("226"))
			{
				throw new Exception(text);
			}
			text = m_pSocket.ReadLine();
		}
		return ParseDirListing(Encoding.Default.GetString(memoryStream.ToArray()));
	}

	public void CreateDir(string dir)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("MKD " + dir);
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("257"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public void RenameDir(string oldDir, string newDir)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("RNFR " + oldDir);
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("350"))
		{
			throw new Exception("Server returned:" + text);
		}
		m_pSocket.WriteLine("RNTO " + newDir);
		text = m_pSocket.ReadLine();
		if (!text.StartsWith("250"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public void DeleteDir(string dir)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("RMD " + dir);
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("250"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public void ReceiveFile(string fileName, string putFileName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		using FileStream storeStream = File.Create(putFileName);
		ReceiveFile(fileName, storeStream);
	}

	public void ReceiveFile(string fileName, Stream storeStream)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		SetTransferMode(TransferMode.Binary);
		Socket socket = null;
		string text = "";
		try
		{
			if (m_Passive)
			{
				socket = GetDataConnection(-1);
				m_pSocket.WriteLine("RETR " + fileName);
				text = m_pSocket.ReadLine();
				if (!text.StartsWith("125") && !text.StartsWith("150"))
				{
					throw new Exception(text);
				}
			}
			else
			{
				int portA = Port();
				m_pSocket.WriteLine("RETR " + fileName);
				text = m_pSocket.ReadLine();
				if (!text.StartsWith("125") && !text.StartsWith("150"))
				{
					throw new Exception(text);
				}
				socket = GetDataConnection(portA);
			}
			int num = 1;
			while (num > 0)
			{
				byte[] array = new byte[4000];
				num = socket.Receive(array, array.Length, SocketFlags.None);
				storeStream.Write(array, 0, num);
			}
			if (socket != null)
			{
				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			}
		}
		catch (Exception ex)
		{
			if (socket != null)
			{
				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			}
			throw ex;
		}
		text = m_pSocket.ReadLine();
		while (!text.StartsWith("226 "))
		{
			if (!text.StartsWith("226"))
			{
				throw new Exception(text);
			}
			text = m_pSocket.ReadLine();
		}
	}

	public void StoreFile(string getFileName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		using FileStream getStream = File.OpenRead(getFileName);
		StoreFile(getStream, Path.GetFileName(getFileName));
	}

	public void StoreFile(Stream getStream, string fileName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		SetTransferMode(TransferMode.Binary);
		Socket socket = null;
		string text = "";
		try
		{
			if (m_Passive)
			{
				socket = GetDataConnection(-1);
				m_pSocket.WriteLine("STOR " + fileName);
				text = m_pSocket.ReadLine();
				if (!text.StartsWith("125") && !text.StartsWith("150"))
				{
					throw new Exception(text);
				}
			}
			else
			{
				int portA = Port();
				m_pSocket.WriteLine("STOR " + fileName);
				text = m_pSocket.ReadLine();
				if (!text.StartsWith("125") && !text.StartsWith("150"))
				{
					throw new Exception(text);
				}
				socket = GetDataConnection(portA);
			}
			int num = 1;
			while (num > 0)
			{
				byte[] array = new byte[4000];
				num = getStream.Read(array, 0, array.Length);
				socket.Send(array, 0, num, SocketFlags.None);
			}
			if (socket != null)
			{
				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			}
		}
		catch (Exception ex)
		{
			if (socket != null)
			{
				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			}
			throw ex;
		}
		text = m_pSocket.ReadLine();
		while (!text.StartsWith("226 "))
		{
			if (!text.StartsWith("226"))
			{
				throw new Exception(text);
			}
			text = m_pSocket.ReadLine();
		}
	}

	public void DeleteFile(string file)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("DELE " + file);
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("250"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	public void RenameFile(string oldFileName, string newFileName)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		m_pSocket.WriteLine("RNFR " + oldFileName);
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("350"))
		{
			throw new Exception("Server returned:" + text);
		}
		m_pSocket.WriteLine("RNTO " + newFileName);
		text = m_pSocket.ReadLine();
		if (!text.StartsWith("250"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	private int Port()
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		IPHostEntry hostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
		Random random = new Random();
		int result = 0;
		bool flag = false;
		int num = 0;
		while (!flag && num < 20)
		{
			for (int i = 0; i < hostEntry.AddressList.Length; i++)
			{
				string text = hostEntry.AddressList[i].ToString().Replace(".", ",");
				int num2 = random.Next(100);
				int num3 = random.Next(100);
				result = (num2 << 8) | num3;
				m_pSocket.WriteLine("PORT " + text + "," + num2 + "," + num3);
				string text2 = m_pSocket.ReadLine();
				if (text2.StartsWith("200"))
				{
					flag = true;
					break;
				}
			}
			num++;
		}
		if (!flag)
		{
			throw new Exception("No suitable port found");
		}
		return result;
	}

	private void SetTransferMode(TransferMode mode)
	{
		if (!m_Connected)
		{
			throw new Exception("You must connect first !");
		}
		if (!m_Authenticated)
		{
			throw new Exception("You must authenticate first !");
		}
		switch (mode)
		{
		case TransferMode.Ascii:
			m_pSocket.WriteLine("TYPE A");
			break;
		case TransferMode.Binary:
			m_pSocket.WriteLine("TYPE I");
			break;
		}
		string text = m_pSocket.ReadLine();
		if (!text.StartsWith("200"))
		{
			throw new Exception("Server returned:" + text);
		}
	}

	private DataSet ParseDirListing(string list)
	{
		DataSet dataSet = new DataSet();
		DataTable dataTable = dataSet.Tables.Add("DirInfo");
		dataTable.Columns.Add("Name");
		dataTable.Columns.Add("Date", typeof(DateTime));
		dataTable.Columns.Add("Size", typeof(long));
		dataTable.Columns.Add("IsDirectory", typeof(bool));
		while (list.IndexOf("  ") > -1)
		{
			list = list.Replace("  ", " ");
		}
		string[] array = list.Replace("\r\n", "\n").Split('\n');
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.Length <= 0)
			{
				continue;
			}
			string[] array3 = text.Split(' ');
			DateTime today = DateTime.Today;
			long num = 0L;
			bool flag = false;
			string text2 = "";
			bool flag2 = false;
			try
			{
				string[] formats = new string[2] { "MM-dd-yy hh:mmtt", "M-d-yy h:mmtt" };
				today = DateTime.ParseExact(array3[0] + " " + array3[1], formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
				flag2 = true;
			}
			catch
			{
			}
			if (flag2)
			{
				string[] formats = new string[4] { "MM-dd-yy hh:mmtt", "M-d-yy h:mmtt", "MM-dd-yy hh:mm", "M-d-yy h:mm" };
				today = DateTime.ParseExact(array3[0] + " " + array3[1], formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
				if (array3[2].ToUpper().IndexOf("DIR") > -1)
				{
					flag = true;
				}
				else
				{
					num = Convert.ToInt64(array3[2]);
				}
				for (int j = 3; j < array3.Length; j++)
				{
					text2 = text2 + array3[j] + " ";
				}
				text2 = text2.Trim();
			}
			else
			{
				string[] formats = new string[6] { "MMM dd HH:mm", "MMM dd H:mm", "MMM d HH:mm", "MMM d H:mm", "MMM dd yyyy", "MMM d yyyy" };
				today = DateTime.ParseExact(array3[5] + " " + array3[6] + " " + array3[7], formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
				if (array3[0].ToUpper().StartsWith("D"))
				{
					flag = true;
				}
				num = Convert.ToInt64(array3[4]);
				for (int j = 8; j < array3.Length; j++)
				{
					text2 = text2 + array3[j] + " ";
				}
				text2 = text2.Trim();
			}
			dataTable.Rows.Add(text2, today, num, flag);
		}
		return dataSet;
	}

	private Socket GetDataConnection(int portA)
	{
		if (m_Passive)
		{
			m_pSocket.WriteLine("PASV");
			string text = m_pSocket.ReadLine();
			if (!text.StartsWith("227"))
			{
				throw new Exception(text);
			}
			text = text.Substring(text.IndexOf("(") + 1, text.IndexOf(")") - text.IndexOf("(") - 1);
			string[] array = text.Split(',');
			string ipString = array[0] + "." + array[1] + "." + array[2] + "." + array[3];
			int port = (Convert.ToInt32(array[4]) << 8) | Convert.ToInt32(array[5]);
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(new IPEndPoint(IPAddress.Parse(ipString), port));
			return socket;
		}
		TcpListener tcpListener = new TcpListener(IPAddress.Any, portA);
		tcpListener.Start();
		long ticks = DateTime.Now.Ticks;
		while (!tcpListener.Pending())
		{
			Thread.Sleep(50);
			if ((DateTime.Now.Ticks - ticks) / 10000 > 20000)
			{
				throw new Exception("Ftp server didn't respond !");
			}
		}
		Socket result = tcpListener.AcceptSocket();
		tcpListener.Stop();
		return result;
	}
}
