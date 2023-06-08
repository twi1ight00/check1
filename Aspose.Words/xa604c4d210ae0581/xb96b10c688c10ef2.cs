using System.IO;
using Aspose.Words.Fields;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class xb96b10c688c10ef2 : xf67718a36ff889c3
{
	internal const int xa230444f4711f2cc = 2;

	private int x9ce272387e6cb84b;

	private int x13064e2ae52b8dc3;

	internal int xca1fee94682538da
	{
		get
		{
			return x13064e2ae52b8dc3;
		}
		set
		{
			x13064e2ae52b8dc3 = value;
		}
	}

	internal FieldType x3146d638ec378671 => (FieldType)x13064e2ae52b8dc3;

	internal bool xc077cfa8d6f9e3c5
	{
		get
		{
			return (x13064e2ae52b8dc3 & 0x80) != 0;
		}
		set
		{
			x13064e2ae52b8dc3 = (byte)x26000ce44ebda9ea.x5ef51986c8da8183(x13064e2ae52b8dc3, 128, value);
		}
	}

	internal bool x752cfab9af626fd5
	{
		get
		{
			return (x13064e2ae52b8dc3 & 0x40) != 0;
		}
		set
		{
			x13064e2ae52b8dc3 = (byte)x26000ce44ebda9ea.x5ef51986c8da8183(x13064e2ae52b8dc3, 64, value);
		}
	}

	internal bool xf465195459605ef8
	{
		get
		{
			return (x13064e2ae52b8dc3 & 0x20) != 0;
		}
		set
		{
			x13064e2ae52b8dc3 = (byte)x26000ce44ebda9ea.x5ef51986c8da8183(x13064e2ae52b8dc3, 32, value);
		}
	}

	internal bool x991897f13cf6aadc
	{
		get
		{
			return (x13064e2ae52b8dc3 & 0x10) != 0;
		}
		set
		{
			x13064e2ae52b8dc3 = (byte)x26000ce44ebda9ea.x5ef51986c8da8183(x13064e2ae52b8dc3, 16, value);
		}
	}

	internal bool xeb7fdc71f3103e2e
	{
		get
		{
			return (x13064e2ae52b8dc3 & 8) != 0;
		}
		set
		{
			x13064e2ae52b8dc3 = (byte)x26000ce44ebda9ea.x5ef51986c8da8183(x13064e2ae52b8dc3, 8, value);
		}
	}

	internal bool x6e94079169d5a06e
	{
		get
		{
			return (x13064e2ae52b8dc3 & 4) != 0;
		}
		set
		{
			x13064e2ae52b8dc3 = (byte)x26000ce44ebda9ea.x5ef51986c8da8183(x13064e2ae52b8dc3, 4, value);
		}
	}

	internal xb96b10c688c10ef2(int ch, int flt)
	{
		x9ce272387e6cb84b = ch;
		x13064e2ae52b8dc3 = flt;
	}

	internal xb96b10c688c10ef2(BinaryReader reader)
	{
		x9ce272387e6cb84b = reader.ReadByte();
		x13064e2ae52b8dc3 = reader.ReadByte();
	}

	private void x85313d56ab6f266e(BinaryWriter xbdfb620b7167944b)
	{
		xbdfb620b7167944b.Write((byte)x9ce272387e6cb84b);
		xbdfb620b7167944b.Write((byte)x13064e2ae52b8dc3);
	}

	void xf67718a36ff889c3.x6210059f049f0d48(BinaryWriter xbdfb620b7167944b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x85313d56ab6f266e
		this.x85313d56ab6f266e(xbdfb620b7167944b);
	}
}
