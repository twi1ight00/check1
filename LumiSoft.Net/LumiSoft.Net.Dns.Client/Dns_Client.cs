using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LumiSoft.Net.Dns.Client;

public class Dns_Client
{
	private static string[] m_DnsServers;

	private static bool m_UseDnsCache;

	private static int m_ID;

	public static string[] DnsServers
	{
		get
		{
			return m_DnsServers;
		}
		set
		{
			m_DnsServers = value;
		}
	}

	public static bool UseDnsCache
	{
		get
		{
			return m_UseDnsCache;
		}
		set
		{
			m_UseDnsCache = value;
		}
	}

	internal static int ID
	{
		get
		{
			if (m_ID >= 65535)
			{
				m_ID = 100;
			}
			return m_ID++;
		}
	}

	static Dns_Client()
	{
		m_DnsServers = null;
		m_UseDnsCache = true;
		m_ID = 100;
		try
		{
			string[] array = new string[2] { "", "" };
			Process process = Process.Start(new ProcessStartInfo("ipconfig", "/all")
			{
				RedirectStandardOutput = true,
				UseShellExecute = false,
				CreateNoWindow = true
			});
			StreamReader standardOutput = process.StandardOutput;
			bool flag = false;
			for (string text = standardOutput.ReadLine(); text != null; text = standardOutput.ReadLine())
			{
				if (text.Trim().ToLower().StartsWith("dns servers"))
				{
					array[0] = text.Substring(text.IndexOf(':') + 1).Trim();
					text = standardOutput.ReadLine();
					if (text != null)
					{
						text = standardOutput.ReadLine();
						if (text != null && text.Trim().IndexOf(":") == -1)
						{
							flag = true;
							array[1] = text.Trim();
						}
					}
					break;
				}
			}
			if (flag)
			{
				m_DnsServers = array;
				return;
			}
			m_DnsServers = new string[1] { array[0] };
		}
		catch
		{
		}
	}

	public DnsServerResponse Query(string queryText, QTYPE queryType)
	{
		if (queryType == QTYPE.PTR)
		{
			string text = queryText;
			IPAddress iPAddress = IPAddress.Parse(text);
			queryText = "";
			if (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)
			{
				char[] array = text.Replace(":", "").ToCharArray();
				for (int num = array.Length - 1; num > -1; num--)
				{
					queryText = queryText + array[num] + ".";
				}
				queryText += "IP6.ARPA";
			}
			else
			{
				string[] array2 = text.Split('.');
				for (int num = 3; num > -1; num--)
				{
					queryText = queryText + array2[num] + ".";
				}
				queryText += "in-addr.arpa";
			}
		}
		return QueryServer(queryText, queryType, 1);
	}

	public static IPAddress[] Resolve(string hostName_IP)
	{
		try
		{
			return new IPAddress[1] { IPAddress.Parse(hostName_IP) };
		}
		catch
		{
		}
		if (hostName_IP.IndexOf(".") == -1)
		{
			return System.Net.Dns.GetHostEntry(hostName_IP).AddressList;
		}
		Dns_Client dns_Client = new Dns_Client();
		DnsServerResponse dnsServerResponse = dns_Client.Query(hostName_IP, QTYPE.A);
		if (dnsServerResponse.ResponseCode == RCODE.NO_ERROR)
		{
			A_Record[] aRecords = dnsServerResponse.GetARecords();
			IPAddress[] array = new IPAddress[aRecords.Length];
			for (int i = 0; i < aRecords.Length; i++)
			{
				array[i] = IPAddress.Parse(aRecords[i].IP);
			}
			return array;
		}
		throw new Exception(dnsServerResponse.ResponseCode.ToString());
	}

	private A_Record ParseARecord(byte[] reply, ref int offset, int rdLength, int ttl)
	{
		byte[] array = new byte[rdLength];
		Array.Copy(reply, offset, array, 0, rdLength);
		return new A_Record(array[0] + "." + array[1] + "." + array[2] + "." + array[3], ttl);
	}

	private NS_Record ParseNSRecord(byte[] reply, ref int offset, int rdLength, int ttl)
	{
		string name = "";
		if (GetQName(reply, ref offset, ref name))
		{
			return new NS_Record(name, ttl);
		}
		return null;
	}

	private CNAME_Record ParseCNAMERecord(byte[] reply, ref int offset, int rdLength, int ttl)
	{
		string name = "";
		if (GetQName(reply, ref offset, ref name))
		{
			return new CNAME_Record(name, ttl);
		}
		return null;
	}

	private SOA_Record ParseSOARecord(byte[] reply, ref int offset, int rdLength, int ttl)
	{
		string name = "";
		GetQName(reply, ref offset, ref name);
		string name2 = "";
		GetQName(reply, ref offset, ref name2);
		char[] array = name2.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == '.')
			{
				array[i] = '@';
				break;
			}
		}
		name2 = new string(array);
		long serial = (reply[offset++] << 24) | (reply[offset++] << 16) | (reply[offset++] << 8) | reply[offset++];
		long refresh = (reply[offset++] << 24) | (reply[offset++] << 16) | (reply[offset++] << 8) | reply[offset++];
		long retry = (reply[offset++] << 24) | (reply[offset++] << 16) | (reply[offset++] << 8) | reply[offset++];
		long expire = (reply[offset++] << 24) | (reply[offset++] << 16) | (reply[offset++] << 8) | reply[offset++];
		long minimum = (reply[offset++] << 24) | (reply[offset++] << 16) | (reply[offset++] << 8) | reply[offset++];
		return new SOA_Record(name, name2, serial, refresh, retry, expire, minimum, ttl);
	}

	private PTR_Record ParsePTRRecord(byte[] reply, ref int offset, int rdLength, int ttl)
	{
		string name = "";
		GetQName(reply, ref offset, ref name);
		return new PTR_Record(name, ttl);
	}

	private HINFO_Record ParseHINFORecord(byte[] reply, ref int offset, int rdLength, int ttl)
	{
		string name = "";
		GetQName(reply, ref offset, ref name);
		string name2 = "";
		GetQName(reply, ref offset, ref name2);
		return new HINFO_Record(name, name2, ttl);
	}

	private MX_Record ParseMxRecord(byte[] reply, ref int offset, int ttl)
	{
		int preference = (reply[offset++] << 8) | reply[offset++];
		string name = "";
		if (GetQName(reply, ref offset, ref name))
		{
			return new MX_Record(preference, name, ttl);
		}
		return null;
	}

	private TXT_Record ParseTXTRecord(byte[] reply, ref int offset, int rdLength, int ttl)
	{
		byte[] array = new byte[rdLength - 1];
		Array.Copy(reply, offset + 1, array, 0, rdLength - 1);
		return new TXT_Record(Encoding.Default.GetString(array).Trim(), ttl);
	}

	private A_Record ParseAAAARecord(byte[] reply, ref int offset, int rdLength, int ttl)
	{
		byte[] array = new byte[rdLength];
		Array.Copy(reply, offset, array, 0, rdLength);
		string text = "";
		if (rdLength == 16)
		{
			for (int i = 1; i < 16; i += 2)
			{
				text += ((long)((array[i - 1] << 8) | array[i])).ToString("x");
				if (i < 15)
				{
					text += ":";
				}
			}
		}
		return new A_Record(text, ttl);
	}

	private DnsServerResponse QueryServer(string qname, QTYPE qtype, int qclass)
	{
		if (m_DnsServers == null || m_DnsServers.Length == 0)
		{
			throw new Exception("Dns server isn't specified !!!");
		}
		if (m_UseDnsCache)
		{
			DnsServerResponse fromCache = DnsCache.GetFromCache(qname, (int)qtype);
			if (fromCache != null)
			{
				return fromCache;
			}
		}
		int iD = ID;
		byte[] buffer = CreateQuery(iD, qname, qtype, qclass);
		int num = 0;
		for (int i = 0; i < m_DnsServers.Length * 2; i++)
		{
			if (num >= m_DnsServers.Length)
			{
				num = 0;
			}
			try
			{
				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 10000);
				socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 10000);
				socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Debug, 1);
				socket.Connect(new IPEndPoint(IPAddress.Parse(m_DnsServers[num]), 53));
				socket.Send(buffer);
				byte[] array = new byte[512];
				int num2 = socket.Receive(array);
				socket.Close();
				DnsServerResponse dnsServerResponse = ParseQuery(array, iD);
				if (m_UseDnsCache && dnsServerResponse.ResponseCode == RCODE.NO_ERROR)
				{
					DnsCache.AddToCache(qname, (int)qtype, dnsServerResponse);
				}
				return dnsServerResponse;
			}
			catch
			{
			}
			num++;
		}
		return new DnsServerResponse(connectionOk: false, RCODE.SERVER_FAILURE, null, null, null);
	}

	private byte[] CreateQuery(int ID, string qname, QTYPE qtype, int qclass)
	{
		byte[] array = new byte[512];
		array[0] = (byte)(ID >> 8);
		array[1] = (byte)((uint)ID & 0xFFu);
		array[2] = 1;
		array[3] = 0;
		array[4] = 0;
		array[5] = 1;
		array[6] = 0;
		array[7] = 0;
		array[8] = 0;
		array[9] = 0;
		array[10] = 0;
		array[11] = 0;
		string[] array2 = qname.Split('.');
		int num = 12;
		string[] array3 = array2;
		foreach (string text in array3)
		{
			array[num++] = (byte)text.Length;
			byte[] bytes = Encoding.ASCII.GetBytes(text);
			bytes.CopyTo(array, num);
			num += bytes.Length;
		}
		array[num++] = 0;
		array[num++] = 0;
		array[num++] = (byte)qtype;
		array[num++] = 0;
		array[num++] = (byte)qclass;
		return array;
	}

	private bool GetQName(byte[] reply, ref int offset, ref string name)
	{
		try
		{
			while (reply[offset] != 0)
			{
				if ((reply[offset] & 0xC0) == 192)
				{
					int offset2 = ((reply[offset] & 0x3F) << 8) | reply[++offset];
					offset++;
					return GetQName(reply, ref offset2, ref name);
				}
				int num = reply[offset] & 0x3F;
				offset++;
				name += Encoding.ASCII.GetString(reply, offset, num);
				offset += num;
				if (reply[offset] != 0)
				{
					name += ".";
				}
			}
			offset++;
			return true;
		}
		catch
		{
			return false;
		}
	}

	private DnsServerResponse ParseQuery(byte[] reply, int queryID)
	{
		int num = (reply[0] << 8) | reply[1];
		OPCODE oPCODE = (OPCODE)((reply[2] >> 3) & 0xF);
		RCODE rcode = (RCODE)(reply[3] & 0xF);
		int num2 = (reply[4] << 8) | reply[5];
		int answerCount = (reply[6] << 8) | reply[7];
		int answerCount2 = (reply[8] << 8) | reply[9];
		int answerCount3 = (reply[10] << 8) | reply[11];
		if (queryID != num)
		{
			throw new Exception("This isn't query with ID what we expected");
		}
		int offset = 12;
		for (int i = 0; i < num2; i++)
		{
			string name = "";
			GetQName(reply, ref offset, ref name);
			offset += 4;
		}
		ArrayList answers = ParseAnswers(reply, answerCount, ref offset);
		ArrayList authoritiveAnswers = ParseAnswers(reply, answerCount2, ref offset);
		ArrayList additionalAnswers = ParseAnswers(reply, answerCount3, ref offset);
		return new DnsServerResponse(connectionOk: true, rcode, answers, authoritiveAnswers, additionalAnswers);
	}

	private ArrayList ParseAnswers(byte[] reply, int answerCount, ref int offset)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < answerCount; i++)
		{
			string name = "";
			if (!GetQName(reply, ref offset, ref name))
			{
				throw new Exception("Error parisng anser");
			}
			int num = (reply[offset++] << 8) | reply[offset++];
			int num2 = (reply[offset++] << 8) | reply[offset++];
			int ttl = (reply[offset++] << 24) | (reply[offset++] << 16) | (reply[offset++] << 8) | reply[offset++];
			int num3 = (reply[offset++] << 8) | reply[offset++];
			object obj = null;
			switch ((QTYPE)num)
			{
			case QTYPE.A:
				obj = ParseARecord(reply, ref offset, num3, ttl);
				offset += num3;
				break;
			case QTYPE.NS:
				obj = ParseNSRecord(reply, ref offset, num3, ttl);
				break;
			case QTYPE.CNAME:
				obj = ParseCNAMERecord(reply, ref offset, num3, ttl);
				break;
			case QTYPE.SOA:
				obj = ParseSOARecord(reply, ref offset, num3, ttl);
				break;
			case QTYPE.PTR:
				obj = ParsePTRRecord(reply, ref offset, num3, ttl);
				break;
			case QTYPE.HINFO:
				obj = ParseHINFORecord(reply, ref offset, num3, ttl);
				break;
			case QTYPE.MX:
				obj = ParseMxRecord(reply, ref offset, ttl);
				break;
			case QTYPE.TXT:
				obj = ParseTXTRecord(reply, ref offset, num3, ttl);
				offset += num3;
				break;
			case QTYPE.AAAA:
				obj = ParseAAAARecord(reply, ref offset, num3, ttl);
				offset += num3;
				break;
			default:
				obj = "dummy";
				offset += num3;
				break;
			}
			arrayList.Add(obj);
		}
		return arrayList;
	}
}
