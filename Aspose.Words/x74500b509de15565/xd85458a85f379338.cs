using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using x1c8faa688b1f0b0c;
using xa7850104c8d8c135;

namespace x74500b509de15565;

internal class xd85458a85f379338 : x1183fab9204ba68f
{
	private StringCollection x844a06e73f5fb69e;

	internal static StringCollection x06b0e25aa6ad68a9(byte[] x5ea23756051aae03)
	{
		xd85458a85f379338 xd85458a85f379339 = new xd85458a85f379338(x5ea23756051aae03);
		return xd85458a85f379339.x06b0e25aa6ad68a9();
	}

	private xd85458a85f379338(byte[] emfBytes)
		: base(new x3fa09e8d7b952fbc(emfBytes), new xb0d8039f74776744())
	{
	}

	private StringCollection x06b0e25aa6ad68a9()
	{
		x844a06e73f5fb69e = new StringCollection();
		x0613827d1b6c81c9(default(SizeF), x48c97d04abed82b6: false);
		return x844a06e73f5fb69e;
	}

	protected override void PlayRecord()
	{
		if (xe3e99d3417159bec.x3146d638ec378671 == xec95ecd2fe18d5f2.x32a832cf175b0e64)
		{
			int count = xf86de1bd2f396938.ReadInt32();
			string @string = Encoding.Unicode.GetString(xf86de1bd2f396938.ReadBytes(count));
			x844a06e73f5fb69e.Add(@string.Substring(0, @string.Length - 1));
		}
	}

	protected override void InitPlayer()
	{
	}

	protected override xb8e7e788f6d59708 GetResult()
	{
		return null;
	}
}
