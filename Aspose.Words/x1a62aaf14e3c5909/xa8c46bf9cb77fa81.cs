using System.IO;

namespace x1a62aaf14e3c5909;

internal class xa8c46bf9cb77fa81 : xddf6304144fd3863
{
	private int x933fbdb4e4f6c448;

	private int x51556d800a83de54;

	private int xd74c65b8d28b1740;

	private int x8918dc7c534575e5;

	internal int x72d92bd1aff02e37
	{
		get
		{
			return x933fbdb4e4f6c448;
		}
		set
		{
			x933fbdb4e4f6c448 = value;
		}
	}

	internal int xe360b1885d8d4a41
	{
		get
		{
			return x51556d800a83de54;
		}
		set
		{
			x51556d800a83de54 = value;
		}
	}

	internal int xdc1bf80853046136
	{
		get
		{
			return xd74c65b8d28b1740;
		}
		set
		{
			xd74c65b8d28b1740 = value;
		}
	}

	internal int xb0f146032f47c24e
	{
		get
		{
			return x8918dc7c534575e5;
		}
		set
		{
			x8918dc7c534575e5 = value;
		}
	}

	internal xa8c46bf9cb77fa81()
		: base(x773fe540042dad03.x8615a69be17cd289, 0)
	{
	}

	protected override void DoRead(BinaryReader reader)
	{
		x933fbdb4e4f6c448 = reader.ReadInt32();
		x51556d800a83de54 = reader.ReadInt32();
		int num = reader.ReadInt32();
		xdc1bf80853046136 = num - x933fbdb4e4f6c448;
		int num2 = reader.ReadInt32();
		xb0f146032f47c24e = num2 - x51556d800a83de54;
	}

	protected override void DoWrite(BinaryWriter writer)
	{
		writer.Write(x933fbdb4e4f6c448);
		writer.Write(x51556d800a83de54);
		writer.Write(x933fbdb4e4f6c448 + xd74c65b8d28b1740);
		writer.Write(x51556d800a83de54 + x8918dc7c534575e5);
	}
}
