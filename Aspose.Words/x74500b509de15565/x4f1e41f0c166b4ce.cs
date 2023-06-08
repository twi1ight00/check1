using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using xa7850104c8d8c135;

namespace x74500b509de15565;

internal class x4f1e41f0c166b4ce : x055feb40a6f16001
{
	private const int xd647d6e24552fb57 = 15;

	private StringCollection x844a06e73f5fb69e;

	internal static StringCollection x06b0e25aa6ad68a9(byte[] xd4accd67a64cf92b)
	{
		x4f1e41f0c166b4ce x4f1e41f0c166b4ce2 = new x4f1e41f0c166b4ce(xd4accd67a64cf92b);
		return x4f1e41f0c166b4ce2.x06b0e25aa6ad68a9();
	}

	private x4f1e41f0c166b4ce(byte[] wmfBytes)
		: base(new x3fa09e8d7b952fbc(wmfBytes))
	{
	}

	private StringCollection x06b0e25aa6ad68a9()
	{
		x844a06e73f5fb69e = new StringCollection();
		x0613827d1b6c81c9(default(SizeF), x48c97d04abed82b6: false);
		return x844a06e73f5fb69e;
	}

	protected override bool DoPlayRecord(x58dacb9696b2ceb9 recordType, int dataSize)
	{
		switch (recordType)
		{
		case x58dacb9696b2ceb9.x70af8406c596bd40:
		{
			int num2 = base.xf86de1bd2f396938.ReadInt16();
			int count = base.xf86de1bd2f396938.ReadUInt16();
			if (num2 == 15)
			{
				string @string = Encoding.ASCII.GetString(base.xf86de1bd2f396938.ReadBytes(count));
				x844a06e73f5fb69e.Add(@string.Substring(0, @string.Length - 1));
			}
			break;
		}
		case x58dacb9696b2ceb9.x1123d3ce5a92413f:
		{
			base.xf86de1bd2f396938.x7e2a3c059f5793af();
			int num = base.xf86de1bd2f396938.ReadUInt16();
			if (base.xf86de1bd2f396938.ReadInt16() != 0)
			{
				base.xf86de1bd2f396938.x70a5bafbe8fbfeb2();
			}
			if (num != 0)
			{
				x844a06e73f5fb69e.Add(Encoding.ASCII.GetString(base.xf86de1bd2f396938.ReadBytes(num)));
			}
			break;
		}
		}
		return true;
	}
}
