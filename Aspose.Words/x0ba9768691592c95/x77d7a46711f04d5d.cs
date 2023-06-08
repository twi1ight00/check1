using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x0ba9768691592c95;

internal class x77d7a46711f04d5d
{
	private const short x404ae9799ae57318 = 1252;

	private const short x3eba0e3819c0dbc1 = 1200;

	private const int x293daa59ba8f094b = 4;

	private const int x90568ad9e66dda8f = 0;

	private const int x6ba44fc2a9f1eaac = 1;

	private const int xf708bf074d6ca12d = 2;

	private const int x32e989d32ed4ab0d = int.MaxValue;

	private const int xe20664a4cb08d468 = int.MinValue;

	private const int x7a545446030223f5 = -2147483645;

	private Guid xfc613fb1b959d073 = Guid.Empty;

	private readonly x721d5a5fac797586 x66cd11f407255d70;

	private readonly int x023c308f3fe07673;

	public static Guid x81b8eab21d0ad59b = new Guid("F29F85E0-4FF9-1068-AB91-08002B27B3D9");

	public static Guid x3cf382f9d0ce3e4b = new Guid("D5CDD502-2E9C-101B-9397-08002B2CF9AE");

	public static Guid x4a71b6aa10d36864 = new Guid("D5CDD505-2E9C-101B-9397-08002B2CF9AE");

	public x721d5a5fac797586 x4e35c79189b28e26 => x66cd11f407255d70;

	public Guid x11f221c54c2b65e6 => xfc613fb1b959d073;

	public int xe4b3641e8e4ef359 => x023c308f3fe07673;

	private x77d7a46711f04d5d(Guid fmtId)
	{
		xfc613fb1b959d073 = fmtId;
		x66cd11f407255d70 = new x721d5a5fac797586();
	}

	public x77d7a46711f04d5d(Guid fmtId, int codePage)
		: this(fmtId)
	{
		if (codePage <= 0)
		{
			throw new ArgumentOutOfRangeException("codePage");
		}
		x023c308f3fe07673 = codePage;
	}

	public x77d7a46711f04d5d(Guid fmtId, BinaryReader reader)
		: this(fmtId)
	{
		long position = reader.BaseStream.Position;
		reader.ReadInt32();
		int num = reader.ReadInt32();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < num; i++)
		{
			arrayList.Add(new x3ea449289926ff85(reader));
		}
		x023c308f3fe07673 = 1252;
		int num2 = xafd59df422892830(arrayList, 1);
		if (num2 != -1)
		{
			reader.BaseStream.Position = position + num2;
			if (xcab7864539e5adf4(reader, 0) is short num3)
			{
				x023c308f3fe07673 = num3 & 0xFFFF;
			}
		}
		Hashtable hashtable = new Hashtable();
		int num4 = xafd59df422892830(arrayList, 0);
		if (num4 != -1)
		{
			reader.BaseStream.Position = position + num4;
			x394421a53f87578a(reader, hashtable, x023c308f3fe07673);
		}
		for (int j = 0; j < arrayList.Count; j++)
		{
			x3ea449289926ff85 x3ea449289926ff86 = (x3ea449289926ff85)arrayList[j];
			long num5 = (long)x3ea449289926ff86.xea1e81378298fa81 & 0xFFFFFFFL;
			if (num5 >= 2 && num5 <= int.MaxValue)
			{
				reader.BaseStream.Position = position + x3ea449289926ff86.xf1d9b91c9700c401;
				object obj = xcab7864539e5adf4(reader, x023c308f3fe07673);
				if (obj != null)
				{
					string name = (string)hashtable[x3ea449289926ff86.xea1e81378298fa81];
					x66cd11f407255d70.xd6b6ed77479ef68c(new x879a106b0501b9dc(x3ea449289926ff86.xea1e81378298fa81, name, obj));
				}
			}
		}
	}

	private static int xafd59df422892830(ArrayList x05ea99a9d8fb979b, int x5b898c7a7c731e45)
	{
		for (int i = 0; i < x05ea99a9d8fb979b.Count; i++)
		{
			x3ea449289926ff85 x3ea449289926ff86 = (x3ea449289926ff85)x05ea99a9d8fb979b[i];
			if (x3ea449289926ff86.xea1e81378298fa81 == x5b898c7a7c731e45)
			{
				return x3ea449289926ff86.xf1d9b91c9700c401;
			}
		}
		return -1;
	}

	public byte[] x2797b998ab68f4ab()
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		int num = 16 + 8 * x66cd11f407255d70.xd44988f225497f3a;
		bool flag = x66cd11f407255d70.x0b282179752635da || xfc613fb1b959d073.Equals(x4a71b6aa10d36864);
		if (flag)
		{
			num += 8;
		}
		memoryStream.Position = num;
		ArrayList arrayList = new ArrayList();
		if (flag)
		{
			arrayList.Add(new x3ea449289926ff85(0, (int)memoryStream.Position));
			x1d006bd416bb23cb(binaryWriter, x66cd11f407255d70, x023c308f3fe07673);
		}
		arrayList.Add(new x3ea449289926ff85(1, (int)memoryStream.Position));
		x6442637562be0651(binaryWriter, (short)x023c308f3fe07673, x023c308f3fe07673, xcd297e9720647d98: true);
		for (int i = 0; i < x66cd11f407255d70.xd44988f225497f3a; i++)
		{
			x879a106b0501b9dc x879a106b0501b9dc2 = x66cd11f407255d70.get_xe6d4b1b411ed94b5(i);
			arrayList.Add(new x3ea449289926ff85(x879a106b0501b9dc2.xea1e81378298fa81, (int)memoryStream.Position));
			x6442637562be0651(binaryWriter, x879a106b0501b9dc2.xd2f68ee6f47e9dfb, x023c308f3fe07673, xcd297e9720647d98: true);
		}
		memoryStream.Position = 0L;
		binaryWriter.Write((int)memoryStream.Length);
		binaryWriter.Write(arrayList.Count);
		for (int j = 0; j < arrayList.Count; j++)
		{
			x3ea449289926ff85 x3ea449289926ff86 = (x3ea449289926ff85)arrayList[j];
			x3ea449289926ff86.x6210059f049f0d48(binaryWriter);
		}
		return memoryStream.ToArray();
	}

	private static void x394421a53f87578a(BinaryReader xe134235b3526fa75, Hashtable x0f3514d757a58ec7, int xc1690d3515e1ed6c)
	{
		int num = xe134235b3526fa75.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			int num2 = xe134235b3526fa75.ReadInt32();
			string text = x2a1ea9d24e62bf84(xe134235b3526fa75, xc1690d3515e1ed6c);
			if (!x0d299f323d241756.x5959bccb67bbf051(text))
			{
				break;
			}
			x0f3514d757a58ec7.Add(num2, text);
		}
	}

	private static void x1d006bd416bb23cb(BinaryWriter xbdfb620b7167944b, x721d5a5fac797586 xa5ea04da0b735c3b, int xc1690d3515e1ed6c)
	{
		xbdfb620b7167944b.Write(xa5ea04da0b735c3b.x5cd4620946d48c1a);
		for (int i = 0; i < xa5ea04da0b735c3b.xd44988f225497f3a; i++)
		{
			x879a106b0501b9dc x879a106b0501b9dc2 = xa5ea04da0b735c3b.get_xe6d4b1b411ed94b5(i);
			if (x879a106b0501b9dc2.x420916cc68dc98ad)
			{
				xbdfb620b7167944b.Write(x879a106b0501b9dc2.xea1e81378298fa81);
				x3d1be38abe5723e3(xbdfb620b7167944b, x879a106b0501b9dc2.x759aa16c2016a289, xc1690d3515e1ed6c);
			}
		}
	}

	private static object xcab7864539e5adf4(BinaryReader xe134235b3526fa75, int xc1690d3515e1ed6c)
	{
		switch ((VarEnum)xe134235b3526fa75.ReadInt32())
		{
		case VarEnum.VT_LPSTR:
			return xfa1f0074ea24621b(xe134235b3526fa75, xc1690d3515e1ed6c);
		case VarEnum.VT_LPWSTR:
		{
			string result = x6deb919b636a771e(xe134235b3526fa75);
			x0d299f323d241756.xb66a70c14b63a912(xe134235b3526fa75.BaseStream, 4);
			return result;
		}
		case VarEnum.VT_FILETIME:
		{
			long num = xe134235b3526fa75.ReadInt64();
			if (num <= DateTime.MinValue.Ticks || num > DateTime.MaxValue.Ticks)
			{
				return DateTime.MinValue;
			}
			return x7546e38fbb25d738.xede8042111f14852(num, "ticks");
		}
		case VarEnum.VT_UI4:
			return xe134235b3526fa75.ReadUInt32();
		case VarEnum.VT_I4:
			return xe134235b3526fa75.ReadInt32();
		case VarEnum.VT_I2:
			return xe134235b3526fa75.ReadInt16();
		case VarEnum.VT_BOOL:
			return xe134235b3526fa75.ReadInt16() != 0;
		case VarEnum.VT_R8:
			return xe134235b3526fa75.ReadDouble();
		case VarEnum.VT_BLOB:
		{
			int count = xe134235b3526fa75.ReadInt32();
			return xe134235b3526fa75.ReadBytes(count);
		}
		case (VarEnum)4108:
			return x87d43649714b8351(xe134235b3526fa75, xc1690d3515e1ed6c);
		case (VarEnum)4126:
		{
			int xc1690d3515e1ed6c2 = ((xc1690d3515e1ed6c != 1200) ? xc1690d3515e1ed6c : 1252);
			return xb5f055b49e1a7bd6(xe134235b3526fa75, xc1690d3515e1ed6c2);
		}
		case (VarEnum)4127:
			return xb5f055b49e1a7bd6(xe134235b3526fa75, xc1690d3515e1ed6c);
		default:
			return null;
		}
	}

	private static string[] xb5f055b49e1a7bd6(BinaryReader xe134235b3526fa75, int xc1690d3515e1ed6c)
	{
		int num = xe134235b3526fa75.ReadInt32();
		string[] array = new string[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = x2a1ea9d24e62bf84(xe134235b3526fa75, xc1690d3515e1ed6c);
		}
		return array;
	}

	private static object[] x87d43649714b8351(BinaryReader xe134235b3526fa75, int xc1690d3515e1ed6c)
	{
		int num = xe134235b3526fa75.ReadInt32();
		object[] array = new object[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = xcab7864539e5adf4(xe134235b3526fa75, xc1690d3515e1ed6c);
		}
		bool flag = true;
		for (int j = 0; j < array.Length; j++)
		{
			object obj = array[j];
			flag &= (x0d299f323d241756.x7e32f71c3f39b6bc(j) ? (obj is int && (int)obj > 0) : (obj is string));
		}
		if (!flag)
		{
			return null;
		}
		return array;
	}

	private static void x6442637562be0651(BinaryWriter xbdfb620b7167944b, object xbcea506a33cf9111, int xc1690d3515e1ed6c, bool xcd297e9720647d98)
	{
		if (xbcea506a33cf9111 is string)
		{
			if (xc1690d3515e1ed6c == 1200)
			{
				xbdfb620b7167944b.Write(31);
			}
			else
			{
				xbdfb620b7167944b.Write(30);
			}
			x3d1be38abe5723e3(xbdfb620b7167944b, (string)xbcea506a33cf9111, xc1690d3515e1ed6c);
		}
		else if (xbcea506a33cf9111 is short)
		{
			xbdfb620b7167944b.Write(2);
			xbdfb620b7167944b.Write((short)xbcea506a33cf9111);
		}
		else if (xbcea506a33cf9111 is int)
		{
			xbdfb620b7167944b.Write(3);
			xbdfb620b7167944b.Write((int)xbcea506a33cf9111);
		}
		else if (xbcea506a33cf9111 is uint)
		{
			xbdfb620b7167944b.Write(19);
			xbdfb620b7167944b.Write((uint)xbcea506a33cf9111);
		}
		else if (xbcea506a33cf9111 is double)
		{
			xbdfb620b7167944b.Write(5);
			xbdfb620b7167944b.Write((double)xbcea506a33cf9111);
		}
		else if (xbcea506a33cf9111 is bool)
		{
			xbdfb620b7167944b.Write(11);
			bool flag = (bool)xbcea506a33cf9111;
			xbdfb620b7167944b.Write((short)(flag ? (-1) : 0));
		}
		else if (xbcea506a33cf9111 is DateTime)
		{
			xbdfb620b7167944b.Write(64);
			DateTime dateTime = (DateTime)xbcea506a33cf9111;
			if (dateTime != DateTime.MinValue)
			{
				xbdfb620b7167944b.Write(x7546e38fbb25d738.xb78c684ef88c5aa4(dateTime, "dateTime"));
			}
			else
			{
				xbdfb620b7167944b.Write(0L);
			}
		}
		else if (xbcea506a33cf9111 is byte[])
		{
			xbdfb620b7167944b.Write(65);
			byte[] array = (byte[])xbcea506a33cf9111;
			xbdfb620b7167944b.Write(array.Length);
			xbdfb620b7167944b.Write(array);
		}
		else if (xbcea506a33cf9111 is string[])
		{
			if (xc1690d3515e1ed6c == 1200)
			{
				xbdfb620b7167944b.Write(4127);
			}
			else
			{
				xbdfb620b7167944b.Write(4126);
			}
			string[] array2 = (string[])xbcea506a33cf9111;
			xbdfb620b7167944b.Write(array2.Length);
			string[] array3 = array2;
			foreach (string xe4115acdf4fbfccc in array3)
			{
				x3d1be38abe5723e3(xbdfb620b7167944b, xe4115acdf4fbfccc, xc1690d3515e1ed6c);
			}
		}
		else
		{
			if (!(xbcea506a33cf9111 is object[]))
			{
				throw new NotSupportedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lfaddihdbdodmhfekhmemhdffckfngbgngiglgpgahghgbnhlfeipfliegcjkajjlfakdfhkbaokffflnemlbedmjekmhdbnpohnncpnjofogdnofdeppclpnccapbjajcabichbkcobomecbcmcjaddbbkdhbbeeaiemloeiagfmpmfdldgealgfpbhdpihkpphekgifpnihpejloljnnckdkjk", 1770270743)));
			}
			xbdfb620b7167944b.Write(4108);
			object[] array4 = (object[])xbcea506a33cf9111;
			xbdfb620b7167944b.Write(array4.Length);
			object[] array5 = array4;
			foreach (object xbcea506a33cf9112 in array5)
			{
				x6442637562be0651(xbdfb620b7167944b, xbcea506a33cf9112, xc1690d3515e1ed6c, xcd297e9720647d98: false);
			}
		}
		if (xcd297e9720647d98)
		{
			x0d299f323d241756.xb66a70c14b63a912(xbdfb620b7167944b.BaseStream, 4);
		}
	}

	private static string xfa1f0074ea24621b(BinaryReader xe134235b3526fa75, int xc1690d3515e1ed6c)
	{
		int num = xe134235b3526fa75.ReadInt32();
		if (!x0d299f323d241756.xd7d2f6dd32a72a3b(xe134235b3526fa75, num))
		{
			num = 0;
		}
		byte[] bytes = xe134235b3526fa75.ReadBytes(num);
		string @string = Encoding.GetEncoding(xc1690d3515e1ed6c).GetString(bytes, 0, num);
		char[] trimChars = new char[1];
		return @string.TrimEnd(trimChars);
	}

	private static void xfcf7834b09cc1d66(BinaryWriter xbdfb620b7167944b, string xe4115acdf4fbfccc, int xc1690d3515e1ed6c)
	{
		xe4115acdf4fbfccc += '\0';
		byte[] bytes = Encoding.GetEncoding(xc1690d3515e1ed6c).GetBytes(xe4115acdf4fbfccc);
		xbdfb620b7167944b.Write(bytes.Length);
		xbdfb620b7167944b.Write(bytes);
	}

	private static string x6deb919b636a771e(BinaryReader xe134235b3526fa75)
	{
		int num = xe134235b3526fa75.ReadInt32() * 2;
		byte[] bytes = xe134235b3526fa75.ReadBytes(num);
		return Encoding.Unicode.GetString(bytes, 0, num - 2);
	}

	private static void x03d2f910329c8a83(BinaryWriter xbdfb620b7167944b, string xe4115acdf4fbfccc)
	{
		xbdfb620b7167944b.Write(xe4115acdf4fbfccc.Length + 1);
		xbdfb620b7167944b.Write(Encoding.Unicode.GetBytes(xe4115acdf4fbfccc));
		xbdfb620b7167944b.Write((short)0);
	}

	private static string x2a1ea9d24e62bf84(BinaryReader xe134235b3526fa75, int xc1690d3515e1ed6c)
	{
		string result;
		if (xc1690d3515e1ed6c == 1200)
		{
			result = x6deb919b636a771e(xe134235b3526fa75);
			x0d299f323d241756.xb66a70c14b63a912(xe134235b3526fa75.BaseStream, 4);
		}
		else
		{
			result = xfa1f0074ea24621b(xe134235b3526fa75, xc1690d3515e1ed6c);
		}
		return result;
	}

	private static void x3d1be38abe5723e3(BinaryWriter xbdfb620b7167944b, string xe4115acdf4fbfccc, int xc1690d3515e1ed6c)
	{
		if (xc1690d3515e1ed6c == 1200)
		{
			x03d2f910329c8a83(xbdfb620b7167944b, xe4115acdf4fbfccc);
			x0d299f323d241756.xb66a70c14b63a912(xbdfb620b7167944b.BaseStream, 4);
		}
		else
		{
			xfcf7834b09cc1d66(xbdfb620b7167944b, xe4115acdf4fbfccc, xc1690d3515e1ed6c);
		}
	}
}
