using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LumiSoft.Net.FTP.Server;

public class FTP_Session : ISocketServerSession
{
	private SocketEx m_pSocket = null;

	private FTP_Server m_pServer = null;

	private string m_SessionID = "";

	private string m_UserName = "";

	private string m_CurrentDir = "/";

	private string m_RenameFrom = "";

	private bool m_PassiveMode = false;

	private TcpListener m_pPassiveListener = null;

	private IPEndPoint m_pDataConEndPoint = null;

	private bool m_Authenticated = false;

	private int m_BadCmdCount = 0;

	private DateTime m_SessionStartTime;

	private object m_Tag = null;

	public string SessionID => m_SessionID;

	public DateTime SessionStartTime => m_SessionStartTime;

	public DateTime SessionLastDataTime => m_pSocket.LastActivity;

	public string UserName => m_UserName;

	public IPEndPoint LocalEndPoint => (IPEndPoint)m_pSocket.LocalEndPoint;

	public IPEndPoint RemoteEndPoint => (IPEndPoint)m_pSocket.RemoteEndPoint;

	public bool PassiveMode => m_PassiveMode;

	public object Tag
	{
		get
		{
			return m_Tag;
		}
		set
		{
			m_Tag = value;
		}
	}

	public FTP_Session(Socket clientSocket, FTP_Server server, string sessionID, SocketLogger logWriter)
	{
		m_pSocket = new SocketEx(clientSocket);
		m_pServer = server;
		m_SessionID = sessionID;
		m_SessionStartTime = DateTime.Now;
		StartSession();
	}

	private void StartSession()
	{
		m_pServer.AddSession(this);
		if (m_pServer.OnValidate_IpAddress(LocalEndPoint, RemoteEndPoint))
		{
			m_pSocket.WriteLine("220 " + m_pServer.HostName + " FTP server ready");
			BeginRecieveCmd();
		}
		else
		{
			EndSession();
		}
	}

	private void EndSession()
	{
		m_pServer.RemoveSession(this);
		if (m_pServer.LogCommands)
		{
			m_pSocket.Logger.Flush();
		}
		if (m_pSocket != null)
		{
			m_pSocket.Shutdown(SocketShutdown.Both);
			m_pSocket.Disconnect();
			m_pSocket = null;
		}
	}

	public void OnSessionTimeout()
	{
		try
		{
			m_pSocket.WriteLine("500 Session timeout, closing transmission channel");
		}
		catch
		{
		}
		EndSession();
	}

	private void OnError(Exception x)
	{
		try
		{
			if (x is SocketException)
			{
				SocketException ex = (SocketException)x;
				if (ex.ErrorCode == 10054 || ex.ErrorCode == 10053)
				{
					if (m_pServer.LogCommands)
					{
						m_pSocket.Logger.AddTextEntry("Client aborted/disconnected");
					}
					EndSession();
					return;
				}
			}
			m_pServer.OnSysError("", x);
		}
		catch (Exception x2)
		{
			m_pServer.OnSysError("", x2);
		}
	}

	private void BeginRecieveCmd()
	{
		MemoryStream memoryStream = new MemoryStream();
		m_pSocket.BeginReadLine(memoryStream, 1024, memoryStream, EndRecieveCmd);
	}

	private void EndRecieveCmd(SocketCallBackResult result, long count, Exception exception, object tag)
	{
		try
		{
			switch (result)
			{
			case SocketCallBackResult.Ok:
			{
				MemoryStream memoryStream = (MemoryStream)tag;
				string @string = Encoding.Default.GetString(memoryStream.ToArray());
				if (SwitchCommand(@string))
				{
					EndSession();
				}
				break;
			}
			case SocketCallBackResult.LengthExceeded:
				m_pSocket.WriteLine("500 Line too long.");
				BeginRecieveCmd();
				break;
			case SocketCallBackResult.SocketClosed:
				EndSession();
				break;
			case SocketCallBackResult.Exception:
				OnError(exception);
				break;
			}
		}
		catch (Exception x)
		{
			OnError(x);
		}
	}

	private bool SwitchCommand(string commandTxt)
	{
		string[] array = commandTxt.TrimStart().Split(' ');
		string text = array[0].ToUpper().Trim();
		string argsText = Core.GetArgsText(commandTxt, text);
		switch (text)
		{
		case "USER":
			USER(argsText);
			break;
		case "PASS":
			PASS(argsText);
			break;
		case "CWD":
			CWD(argsText);
			break;
		case "CDUP":
			CDUP(argsText);
			break;
		case "QUIT":
			QUIT();
			return true;
		case "PORT":
			PORT(argsText);
			break;
		case "PASV":
			PASV(argsText);
			break;
		case "TYPE":
			TYPE(argsText);
			break;
		case "RETR":
			RETR(argsText);
			break;
		case "STOR":
			STOR(argsText);
			break;
		case "APPE":
			APPE(argsText);
			break;
		case "RNFR":
			RNFR(argsText);
			break;
		case "RNTO":
			RNTO(argsText);
			break;
		case "DELE":
			DELE(argsText);
			break;
		case "RMD":
			RMD(argsText);
			break;
		case "MKD":
			MKD(argsText);
			break;
		case "PWD":
			PWD();
			break;
		case "LIST":
			LIST(argsText);
			break;
		case "NLST":
			NLST(argsText);
			break;
		case "SYST":
			SYST();
			break;
		case "NOOP":
			NOOP();
			break;
		default:
			m_pSocket.WriteLine("500 Invalid command " + text);
			if (m_BadCmdCount > m_pServer.MaxBadCommands - 1)
			{
				m_pSocket.WriteLine("421 Too many bad commands, closing transmission channel");
				return true;
			}
			m_BadCmdCount++;
			break;
		case "":
			break;
		}
		BeginRecieveCmd();
		return false;
	}

	private void USER(string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.WriteLine("500 You are already authenticated");
			return;
		}
		if (m_UserName.Length > 0)
		{
			m_pSocket.WriteLine("500 username is already specified, please specify password");
			return;
		}
		string[] array = argsText.Split(' ');
		if (argsText.Length > 0 && array.Length == 1)
		{
			string text = array[0];
			m_pSocket.WriteLine("331 Password required or user:'" + text + "'");
			m_UserName = text;
		}
		else
		{
			m_pSocket.WriteLine("500 Syntax error. Syntax:{USER username}");
		}
	}

	private void PASS(string argsText)
	{
		if (m_Authenticated)
		{
			m_pSocket.WriteLine("500 You are already authenticated");
			return;
		}
		if (m_UserName.Length == 0)
		{
			m_pSocket.WriteLine("503 please specify username first");
			return;
		}
		string[] array = argsText.Split(' ');
		if (array.Length == 1)
		{
			string passwData = array[0];
			if (m_pServer.OnAuthUser(this, m_UserName, passwData, "", AuthType.Plain))
			{
				m_Authenticated = true;
				m_pSocket.WriteLine("230 Password ok");
			}
			else
			{
				m_pSocket.WriteLine("530 UserName or Password is incorrect");
				m_UserName = "";
			}
		}
		else
		{
			m_pSocket.WriteLine("500 Syntax error. Syntax:{PASS userName}");
		}
	}

	private void CWD(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		string andNormailizePath = GetAndNormailizePath(argsText);
		if (m_pServer.OnDirExists(this, andNormailizePath))
		{
			m_CurrentDir = andNormailizePath;
			m_pSocket.WriteLine("250 CDW command successful.");
		}
		else
		{
			m_pSocket.WriteLine("550 System can't find directory '" + andNormailizePath + "'.");
		}
	}

	private void CDUP(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		string[] array = m_CurrentDir.Split('/');
		if (array.Length > 1)
		{
			m_CurrentDir = "";
			for (int i = 0; i < array.Length - 2; i++)
			{
				m_CurrentDir = m_CurrentDir + array[i] + "/";
			}
			if (m_CurrentDir.Length == 0)
			{
				m_CurrentDir = "/";
			}
		}
		m_pSocket.WriteLine("250 CDUP command successful.");
	}

	private void PWD()
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
		}
		else
		{
			m_pSocket.WriteLine("257 \"" + m_CurrentDir + "\" is current directory.");
		}
	}

	private void RETR(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		Stream stream = null;
		try
		{
			string andNormailizePath = GetAndNormailizePath(argsText);
			andNormailizePath = andNormailizePath.Substring(0, andNormailizePath.Length - 1);
			stream = m_pServer.OnGetFile(this, andNormailizePath);
		}
		catch
		{
			m_pSocket.WriteLine("550 Access denied or directory dosen't exist !");
			return;
		}
		Socket dataConnection = GetDataConnection();
		if (dataConnection == null)
		{
			return;
		}
		try
		{
			if (stream != null)
			{
				int num = 1;
				while (num > 0)
				{
					byte[] array = new byte[10000];
					num = stream.Read(array, 0, array.Length);
					dataConnection.Send(array, num, SocketFlags.None);
				}
			}
			dataConnection.Shutdown(SocketShutdown.Both);
			dataConnection.Close();
			m_pSocket.WriteLine("226 Transfer Complete.");
		}
		catch
		{
			m_pSocket.WriteLine("426 Connection closed; transfer aborted.");
		}
		stream.Close();
	}

	private void STOR(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		Stream stream = null;
		try
		{
			string andNormailizePath = GetAndNormailizePath(argsText);
			andNormailizePath = andNormailizePath.Substring(0, andNormailizePath.Length - 1);
			stream = m_pServer.OnStoreFile(this, andNormailizePath);
		}
		catch
		{
			m_pSocket.WriteLine("550 Access denied or directory dosen't exist !");
			return;
		}
		Socket dataConnection = GetDataConnection();
		if (dataConnection == null)
		{
			return;
		}
		try
		{
			string andNormailizePath = GetAndNormailizePath(argsText);
			andNormailizePath = andNormailizePath.Substring(0, andNormailizePath.Length - 1);
			if (stream != null)
			{
				int num = 1;
				while (num > 0)
				{
					byte[] buffer = new byte[10000];
					num = dataConnection.Receive(buffer);
					stream.Write(buffer, 0, num);
				}
			}
			dataConnection.Shutdown(SocketShutdown.Both);
			dataConnection.Close();
			m_pSocket.WriteLine("226 Transfer Complete.");
		}
		catch
		{
			m_pSocket.WriteLine("426 Connection closed; transfer aborted.");
		}
		stream.Close();
	}

	private void DELE(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		string andNormailizePath = GetAndNormailizePath(argsText);
		andNormailizePath = andNormailizePath.Substring(0, andNormailizePath.Length - 1);
		m_pServer.OnDeleteFile(this, andNormailizePath);
		m_pSocket.WriteLine("250 file deleted.");
	}

	private void APPE(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
		}
		else
		{
			m_pSocket.WriteLine("500 unimplemented");
		}
	}

	private void RNFR(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		string andNormailizePath = GetAndNormailizePath(argsText);
		if (m_pServer.OnDirExists(this, andNormailizePath) || m_pServer.OnFileExists(this, andNormailizePath))
		{
			m_pSocket.WriteLine("350 Please specify destination name.");
			m_RenameFrom = andNormailizePath;
		}
		else
		{
			m_pSocket.WriteLine("550 File or directory doesn't exist.");
		}
	}

	private void RNTO(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		if (m_RenameFrom.Length == 0)
		{
			m_pSocket.WriteLine("503 Bad sequence of commands.");
			return;
		}
		string andNormailizePath = GetAndNormailizePath(argsText);
		if (m_pServer.OnRenameDirFile(this, m_RenameFrom, andNormailizePath))
		{
			m_pSocket.WriteLine("250 Directory renamed.");
			m_RenameFrom = "";
		}
		else
		{
			m_pSocket.WriteLine("550 Error renameing directory or file .");
		}
	}

	private void RMD(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		string andNormailizePath = GetAndNormailizePath(argsText);
		if (m_pServer.OnDeleteDir(this, andNormailizePath))
		{
			m_pSocket.WriteLine("250 \"" + andNormailizePath + "\" directory deleted.");
		}
		else
		{
			m_pSocket.WriteLine("550 Directory deletion failed.");
		}
	}

	private void MKD(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		string andNormailizePath = GetAndNormailizePath(argsText);
		if (m_pServer.OnCreateDir(this, andNormailizePath))
		{
			m_pSocket.WriteLine("257 \"" + andNormailizePath + "\" directory created.");
		}
		else
		{
			m_pSocket.WriteLine("550 Directory creation failed.");
		}
	}

	private void LIST(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		FileSysEntry_EventArgs fileSysEntry_EventArgs = m_pServer.OnGetDirInfo(this, GetAndNormailizePath(argsText));
		if (!fileSysEntry_EventArgs.Validated)
		{
			m_pSocket.WriteLine("550 Access denied or directory dosen't exist !");
			return;
		}
		DataSet dirInfo = fileSysEntry_EventArgs.DirInfo;
		Socket dataConnection = GetDataConnection();
		if (dataConnection == null)
		{
			return;
		}
		try
		{
			foreach (DataRow row in dirInfo.Tables["DirInfo"].Rows)
			{
				string text = row["Name"].ToString();
				string text2 = Convert.ToDateTime(row["Date"]).ToString("MM-dd-yy hh:mmtt");
				if (Convert.ToBoolean(row["IsDirectory"]))
				{
					dataConnection.Send(Encoding.Default.GetBytes(text2 + " <DIR> " + text + "\r\n"));
					continue;
				}
				dataConnection.Send(Encoding.Default.GetBytes(text2 + " " + row["Size"].ToString() + " " + text + "\r\n"));
			}
			dataConnection.Shutdown(SocketShutdown.Both);
			dataConnection.Close();
			m_pSocket.WriteLine("226 Transfer Complete.");
		}
		catch
		{
			m_pSocket.WriteLine("426 Connection closed; transfer aborted.");
		}
	}

	private void NLST(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		FileSysEntry_EventArgs fileSysEntry_EventArgs = m_pServer.OnGetDirInfo(this, GetAndNormailizePath(argsText));
		if (!fileSysEntry_EventArgs.Validated)
		{
			m_pSocket.WriteLine("550 Access denied or directory dosen't exist !");
			return;
		}
		DataSet dirInfo = fileSysEntry_EventArgs.DirInfo;
		Socket dataConnection = GetDataConnection();
		if (dataConnection == null)
		{
			return;
		}
		try
		{
			foreach (DataRow row in dirInfo.Tables["DirInfo"].Rows)
			{
				dataConnection.Send(Encoding.Default.GetBytes(row["Name"].ToString() + "\r\n"));
			}
			dataConnection.Send(Encoding.Default.GetBytes("aaa\r\n"));
			dataConnection.Shutdown(SocketShutdown.Both);
			dataConnection.Close();
			m_pSocket.WriteLine("226 Transfer Complete.");
		}
		catch
		{
			m_pSocket.WriteLine("426 Connection closed; transfer aborted.");
		}
	}

	private void TYPE(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
		}
		else if (argsText.Trim().ToUpper() == "A" || argsText.Trim().ToUpper() == "I")
		{
			m_pSocket.WriteLine("200 Type is set to " + argsText + ".");
		}
		else
		{
			m_pSocket.WriteLine("500 Invalid type " + argsText + ".");
		}
	}

	private void PORT(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		string[] array = argsText.Split(',');
		if (array.Length != 6)
		{
			m_pSocket.WriteLine("550 Invalid arguments.");
			return;
		}
		string hostNameOrAddress = array[0] + "." + array[1] + "." + array[2] + "." + array[3];
		int port = (Convert.ToInt32(array[4]) << 8) | Convert.ToInt32(array[5]);
		m_pDataConEndPoint = new IPEndPoint(System.Net.Dns.GetHostEntry(hostNameOrAddress).AddressList[0], port);
		m_pSocket.WriteLine("200 PORT Command successful.");
	}

	private void PASV(string argsText)
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
			return;
		}
		int num = 6000;
		while (true)
		{
			bool flag = true;
			try
			{
				m_pPassiveListener = new TcpListener(IPAddress.Any, num);
				m_pPassiveListener.Start();
			}
			catch
			{
				goto IL_0050;
			}
			break;
			IL_0050:
			num++;
		}
		string text = m_pSocket.LocalEndPoint.ToString();
		text = text.Substring(0, text.IndexOf(":"));
		text = text.Replace(".", ",");
		object obj2 = text;
		text = string.Concat(obj2, ",", num >> 8, ",", num & 0xFF);
		m_pSocket.WriteLine("227 Entering Passive Mode (" + text + ").");
		m_PassiveMode = true;
	}

	private void SYST()
	{
		if (!m_Authenticated)
		{
			m_pSocket.WriteLine("530 Please authenticate firtst !");
		}
		else
		{
			m_pSocket.WriteLine("215 Windows_NT");
		}
	}

	private void NOOP()
	{
		m_pSocket.WriteLine("200 OK");
	}

	private void QUIT()
	{
		m_pSocket.WriteLine("221 FTP server signing off");
	}

	private string GetAndNormailizePath(string path)
	{
		string text = path.Replace("\\", "/");
		if (!text.EndsWith("/"))
		{
			text += "/";
		}
		if (!path.StartsWith("/"))
		{
			text = m_CurrentDir + text;
		}
		ArrayList arrayList = new ArrayList();
		string[] c = text.Split('/');
		arrayList.AddRange(c);
		for (int i = 0; i < arrayList.Count; i++)
		{
			if (arrayList[i].ToString() == "..")
			{
				if (i > 0)
				{
					arrayList.RemoveAt(i - 1);
					i--;
				}
				arrayList.RemoveAt(i);
				i--;
			}
		}
		return text.Replace("//", "/");
	}

	private Socket GetDataConnection()
	{
		Socket socket = null;
		try
		{
			if (m_PassiveMode)
			{
				long ticks = DateTime.Now.Ticks;
				while (!m_pPassiveListener.Pending())
				{
					Thread.Sleep(50);
					if ((DateTime.Now.Ticks - ticks) / 10000 > 20000)
					{
						throw new Exception("Ftp server didn't respond !");
					}
				}
				socket = m_pPassiveListener.AcceptSocket();
				m_pSocket.WriteLine("125 Data connection open, Transfer starting.");
			}
			else
			{
				m_pSocket.WriteLine("150 Opening data connection.");
				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Connect(m_pDataConEndPoint);
			}
		}
		catch
		{
			m_pSocket.WriteLine("425 Can't open data connection.");
			return null;
		}
		m_PassiveMode = false;
		return socket;
	}
}
