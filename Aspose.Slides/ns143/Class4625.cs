using System;
using System.Text;
using ns147;
using ns149;

namespace ns143;

internal class Class4625
{
	private ushort ushort_0;

	private ushort ushort_1;

	private Class4657 class4657_0;

	internal Class4657 BaseTable => class4657_0;

	public ushort PlatformID
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public ushort PlatformSpecificID
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
		}
	}

	internal bool IsUnicodeEncoding
	{
		get
		{
			if (ushort_0 == 3)
			{
				return ushort_1 != 4;
			}
			return true;
		}
	}

	internal Class4625(Class4657 baseTable)
	{
		class4657_0 = baseTable;
	}

	internal Class4625(ushort platformID, ushort platformSpecificID, Class4657 baseTable)
		: this(baseTable)
	{
		ushort_0 = platformID;
		ushort_1 = platformSpecificID;
	}

	internal virtual void vmethod_0(Class4689 ttfReader)
	{
	}

	internal virtual void Save(out byte[] tableBytes, out uint length)
	{
		tableBytes = new byte[0];
		length = 0u;
	}

	internal byte[] method_0(char charCode)
	{
		if (ushort_0 == 3 && ushort_1 == 4)
		{
			Encoding encoding = Encoding.GetEncoding("big5");
			byte[] bytes = Encoding.Unicode.GetBytes(new char[1] { charCode });
			return Encoding.Convert(Encoding.Unicode, encoding, bytes);
		}
		return BitConverter.GetBytes((short)charCode);
	}

	public virtual void vmethod_1(ushort code, ushort glyphIndex)
	{
	}

	public virtual int vmethod_2(char charCode)
	{
		return 0;
	}
}
