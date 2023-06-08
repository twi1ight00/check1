using System.IO;
using ns60;

namespace ns63;

internal class Class2788 : Class2623
{
	internal const int int_0 = 1060;

	private byte byte_0;

	public bool FIncludeDate
	{
		get
		{
			return (byte_0 & 1) == 1;
		}
		set
		{
			if (value)
			{
				byte_0 |= 1;
			}
			else
			{
				byte_0 = (byte)(byte_0 & 0xFFFFFFFEu);
			}
		}
	}

	public bool FIncludeFooter
	{
		get
		{
			return (byte_0 & 2) == 2;
		}
		set
		{
			if (value)
			{
				byte_0 |= 2;
			}
			else
			{
				byte_0 = (byte)(byte_0 & 0xFFFFFFFDu);
			}
		}
	}

	public bool FIncludeHeader
	{
		get
		{
			return (byte_0 & 4) == 4;
		}
		set
		{
			if (value)
			{
				byte_0 |= 4;
			}
			else
			{
				byte_0 = (byte)(byte_0 & 0xFFFFFFFBu);
			}
		}
	}

	public bool FIncludeSlideNumber
	{
		get
		{
			return (byte_0 & 8) == 8;
		}
		set
		{
			if (value)
			{
				byte_0 |= 8;
			}
			else
			{
				byte_0 = (byte)(byte_0 & 0xFFFFFFF7u);
			}
		}
	}

	internal Class2788()
	{
		base.Header.Type = 1060;
	}

	protected override void vmethod_0(BinaryReader reader)
	{
		byte_0 = reader.ReadByte();
	}

	public override void vmethod_1(BinaryWriter writer)
	{
		writer.Write(byte_0);
	}

	public override int vmethod_2()
	{
		return 1;
	}
}
