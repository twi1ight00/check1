using System;
using System.IO;
using System.Text;
using Aspose.Words.Drawing;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x1a62aaf14e3c5909;

internal class x00f3419456bbf9dc : xddf6304144fd3863
{
	private int x0a129ee9242ae7ba;

	private int x78d052a41e2fa75b;

	internal int xdd2aea3eb7514107
	{
		get
		{
			return x0a129ee9242ae7ba;
		}
		set
		{
			x0a129ee9242ae7ba = value;
		}
	}

	internal bool xe23970fbd4f20532
	{
		get
		{
			return (x78d052a41e2fa75b & 1) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 1, value);
		}
	}

	internal bool x3b9e71c3ee8a81a6
	{
		get
		{
			return (x78d052a41e2fa75b & 2) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 2, value);
		}
	}

	internal bool xab3829a04b8614ba
	{
		get
		{
			return (x78d052a41e2fa75b & 4) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 4, value);
		}
	}

	internal bool x65fd966a6b330c28
	{
		get
		{
			return (x78d052a41e2fa75b & 8) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 8, value);
		}
	}

	internal bool xa170cce2bc40bdf5
	{
		get
		{
			return (x78d052a41e2fa75b & 0x10) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 16, value);
		}
	}

	internal bool x6bdb609ccd53a4a0
	{
		get
		{
			return (x78d052a41e2fa75b & 0x20) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 32, value);
		}
	}

	internal bool xf22c54e7f5f5aa8b
	{
		get
		{
			return (x78d052a41e2fa75b & 0x40) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 64, value);
		}
	}

	internal bool x1417fc1cb1e5c874
	{
		get
		{
			return (x78d052a41e2fa75b & 0x80) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 128, value);
		}
	}

	internal bool x6dcbdae8b4f7f447
	{
		get
		{
			return (x78d052a41e2fa75b & 0x100) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 256, value);
		}
	}

	internal bool x1a3b93a566584a7d
	{
		get
		{
			return (x78d052a41e2fa75b & 0x400) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 1024, value);
		}
	}

	internal bool x0cf12e39ba2fb49f
	{
		get
		{
			return (x78d052a41e2fa75b & 0x200) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 512, value);
		}
	}

	internal bool xf94637ee9e16822d
	{
		get
		{
			return (x78d052a41e2fa75b & 0x800) != 0;
		}
		set
		{
			x78d052a41e2fa75b = x26000ce44ebda9ea.x5ef51986c8da8183(x78d052a41e2fa75b, 2048, value);
		}
	}

	internal ShapeType xbed4d3b2bc339f99
	{
		get
		{
			return (ShapeType)base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996;
		}
		set
		{
			base.x1ea60bde2b5d0d28.x9834ddb0e0bd5996 = (int)value;
		}
	}

	internal FlipOrientation x6c63cd63ecbef700
	{
		get
		{
			if (xf22c54e7f5f5aa8b && x1417fc1cb1e5c874)
			{
				return FlipOrientation.Both;
			}
			if (xf22c54e7f5f5aa8b)
			{
				return FlipOrientation.Horizontal;
			}
			if (x1417fc1cb1e5c874)
			{
				return FlipOrientation.Vertical;
			}
			return FlipOrientation.None;
		}
		set
		{
			switch (value)
			{
			case FlipOrientation.None:
				xf22c54e7f5f5aa8b = false;
				x1417fc1cb1e5c874 = false;
				break;
			case FlipOrientation.Horizontal:
				xf22c54e7f5f5aa8b = true;
				x1417fc1cb1e5c874 = false;
				break;
			case FlipOrientation.Vertical:
				xf22c54e7f5f5aa8b = false;
				x1417fc1cb1e5c874 = true;
				break;
			case FlipOrientation.Both:
				xf22c54e7f5f5aa8b = true;
				x1417fc1cb1e5c874 = true;
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lidhbkkhljbiljiijjpiojgjcjnjbeekeilkhiclbijlfiamcdhmdiomfifnjhmnlgdobdko", 1066758966)));
			}
		}
	}

	internal x00f3419456bbf9dc()
		: base(x773fe540042dad03.xa9993ed2e0c64574, 2)
	{
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}\n", base.ToString());
		stringBuilder.AppendFormat("ShapeId:{0:X}, ShapeRecordFlags:{1:X} ({2})\n", x0a129ee9242ae7ba, x78d052a41e2fa75b, (x796f29db17acf9a2)x78d052a41e2fa75b);
		return stringBuilder.ToString();
	}

	protected override void DoRead(BinaryReader reader)
	{
		x0a129ee9242ae7ba = reader.ReadInt32();
		x78d052a41e2fa75b = reader.ReadInt32();
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x0a129ee9242ae7ba);
		writer.Write(x78d052a41e2fa75b);
	}
}
