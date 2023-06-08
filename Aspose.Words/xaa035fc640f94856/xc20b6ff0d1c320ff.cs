using System.IO;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;

namespace xaa035fc640f94856;

internal class xc20b6ff0d1c320ff
{
	private xc20b6ff0d1c320ff()
	{
	}

	internal static string x06b0e25aa6ad68a9(BinaryReader xe134235b3526fa75)
	{
		int num = xe134235b3526fa75.ReadUInt16();
		int num2 = num & 0x7FFF;
		bool flag = (num & 0x8000) == 0;
		if (num2 > 0)
		{
			int count = (flag ? (num2 * 2) : num2);
			byte[] bytes = xe134235b3526fa75.ReadBytes(count);
			return x93b05c1ad709a695.x9cfd780d6fc703c5(flag).GetString(bytes);
		}
		return "";
	}

	internal static void x6210059f049f0d48(BinaryWriter xbdfb620b7167944b, string xe4115acdf4fbfccc)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xe4115acdf4fbfccc))
		{
			xbdfb620b7167944b.Write((ushort)xe4115acdf4fbfccc.Length);
			byte[] bytes = x93b05c1ad709a695.x9cfd780d6fc703c5(x5be1cad1d00af914: true).GetBytes(xe4115acdf4fbfccc);
			xbdfb620b7167944b.Write(bytes);
		}
		else
		{
			xbdfb620b7167944b.Write((ushort)0);
		}
	}

	internal static int x1deebb03a3d03a50(string xe4115acdf4fbfccc)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xe4115acdf4fbfccc))
		{
			return 2 + xe4115acdf4fbfccc.Length * 2;
		}
		return 2;
	}
}
