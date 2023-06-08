using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Richfit.Garnet.Common.Email;

/// <summary>
///
/// </summary>
public class POP3
{
	/// <summary>
	///
	/// </summary>
	public string POPServer { get; set; }

	/// <summary>
	///
	/// </summary>
	public string User { get; set; }

	/// <summary>
	///
	/// </summary>
	private string Pwd { get; set; }

	/// <summary>
	///
	/// </summary>
	public POP3()
	{
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="server"></param>
	/// <param name="_user"></param>
	/// <param name="_pwd"></param>
	public POP3(string server, string _user, string _pwd)
	{
		POPServer = server;
		User = _user;
		Pwd = _pwd;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="isOK"></param>
	/// <returns></returns>
	private NetworkStream Connect(out bool isOK)
	{
		isOK = true;
		TcpClient sender = new TcpClient(POPServer, 110);
		NetworkStream ns = null;
		try
		{
			ns = sender.GetStream();
			StreamReader sr = new StreamReader(ns);
			Console.WriteLine(sr.ReadLine());
			string input = "user " + User + "\r\n";
			byte[] outbytes = Encoding.ASCII.GetBytes(input.ToCharArray());
			ns.Write(outbytes, 0, outbytes.Length);
			string back = sr.ReadLine();
			Console.WriteLine(back);
			input = "pass " + Pwd + "\r\n";
			outbytes = Encoding.ASCII.GetBytes(input.ToCharArray());
			ns.Write(outbytes, 0, outbytes.Length);
			back = sr.ReadLine();
			Console.WriteLine(back);
			if (back.StartsWith("-ERR"))
			{
				isOK = false;
			}
			return ns;
		}
		catch
		{
			return ns;
		}
	}

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
	public int GetMailCount()
	{
		try
		{
			bool ok;
			NetworkStream ns = Connect(out ok);
			if (!ok)
			{
				return -1;
			}
			StreamReader sr = new StreamReader(ns);
			string input = "stat\r\n";
			byte[] outbytes = Encoding.ASCII.GetBytes(input.ToCharArray());
			ns.Write(outbytes, 0, outbytes.Length);
			string resp = sr.ReadLine();
			Console.WriteLine(resp);
			string[] tokens = resp.Split(' ');
			input = "quit\r\n";
			outbytes = Encoding.ASCII.GetBytes(input.ToCharArray());
			ns.Write(outbytes, 0, outbytes.Length);
			Console.WriteLine(sr.ReadLine());
			sr.Close();
			ns.Close();
			return Convert.ToInt32(tokens[1]);
		}
		catch
		{
			return 0;
		}
	}
}
