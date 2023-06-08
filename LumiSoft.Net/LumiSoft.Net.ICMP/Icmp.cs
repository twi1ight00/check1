using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace LumiSoft.Net.ICMP;

public class Icmp
{
	public static EchoMessage[] Trace(string destIP)
	{
		ArrayList arrayList = new ArrayList();
		Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
		IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(destIP), 80);
		EndPoint remoteEP2 = new IPEndPoint(System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0], 80);
		ushort id = (ushort)DateTime.Now.Millisecond;
		byte[] array = CreatePacket(id);
		int num = 0;
		for (int num2 = 1; num2 <= 30; num2++)
		{
			byte[] array2 = new byte[256];
			try
			{
				socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, num2);
				socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 4000);
				socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 4000);
				DateTime now = DateTime.Now;
				socket.SendTo(array, array.Length, SocketFlags.None, remoteEP);
				socket.ReceiveFrom(array2, array2.Length, SocketFlags.None, ref remoteEP2);
				TimeSpan timeSpan = DateTime.Now - now;
				arrayList.Add(new EchoMessage(((IPEndPoint)remoteEP2).Address.ToString(), num2, timeSpan.Milliseconds));
				if (array2[20] == 0)
				{
					break;
				}
				if (array2[20] != 11)
				{
					throw new Exception("UnKnown error !");
				}
				num = 0;
				goto IL_013a;
			}
			catch
			{
				num++;
				goto IL_013a;
			}
			IL_013a:
			if (num >= 3)
			{
				break;
			}
		}
		EchoMessage[] array3 = new EchoMessage[arrayList.Count];
		arrayList.CopyTo(array3);
		return array3;
	}

	private static byte[] CreatePacket(ushort id)
	{
		byte[] array = new byte[10] { 8, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		Array.Copy(BitConverter.GetBytes(id), 0, array, 4, 2);
		for (int i = 0; i < 2; i++)
		{
			array[i + 8] = 120;
		}
		int num = 0;
		for (int i = 0; i < array.Length; i += 2)
		{
			num += Convert.ToInt32(BitConverter.ToUInt16(array, i));
		}
		num &= 0xFFFF;
		Array.Copy(BitConverter.GetBytes((ushort)(~num)), 0, array, 2, 2);
		return array;
	}
}
