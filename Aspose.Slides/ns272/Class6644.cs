using System;
using System.Text;
using ns218;
using ns271;

namespace ns272;

internal class Class6644
{
	private ushort ushort_0;

	private ushort ushort_1;

	private Class6634 class6634_0;

	internal Class6634 BaseTable => class6634_0;

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

	public Class6644(Class6634 baseTable)
	{
		class6634_0 = baseTable;
	}

	public Class6644(ushort platformID, ushort platformSpecificID, Class6634 baseTable)
		: this(baseTable)
	{
		ushort_0 = platformID;
		ushort_1 = platformSpecificID;
	}

	internal virtual void vmethod_0(Class5950 ttfReader)
	{
	}

	internal virtual void Save(Class5951 ttfWriter)
	{
	}

	internal virtual void vmethod_1(ushort code, ushort glyphIndex)
	{
	}

	internal virtual Class6735 vmethod_2(Class6728 hMetrics)
	{
		return null;
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

	public virtual int vmethod_3(char charCode)
	{
		return 0;
	}
}
