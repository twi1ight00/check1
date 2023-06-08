using System.IO;
using x6c95d9cf46ff5f25;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace x24e0e4e48dc84bd8;

internal class x9cbf8b59bdd6cd61
{
	private readonly x4e88096751fad171 xd995695f8e3419d6;

	private MemoryStream x75695dee32239965;

	private int xc6f5168692fc3511;

	private x6d569a893c7802a9 x0ce5bb654ee42bd2;

	private int xcd43f99b11aab3ea;

	private bool xb47db6c16ebb1e4f;

	private x7cf45d99b6b735e8 xe3e99d3417159bec => xd995695f8e3419d6.xe3e99d3417159bec;

	private x28a5d52551b64191 xf86de1bd2f396938 => xd995695f8e3419d6.xf86de1bd2f396938;

	public x9cbf8b59bdd6cd61(x4e88096751fad171 serviceLocator)
	{
		xd995695f8e3419d6 = serviceLocator;
	}

	public void xd944399e85e1af75()
	{
		bool flag = xe3e99d3417159bec.x586b7652ac7cefe0.x375aed0ef1326002(0);
		x6d569a893c7802a9 x6d569a893c7802a = (x6d569a893c7802a9)xe3e99d3417159bec.x586b7652ac7cefe0.x02995f229cff83b4(1, 7);
		int num = xe3e99d3417159bec.x586b7652ac7cefe0.x02995f229cff83b4(8, 15);
		if (xb47db6c16ebb1e4f)
		{
			xf86de1bd2f396938.ReadInt32();
			byte[] array = xf86de1bd2f396938.ReadBytes(xe3e99d3417159bec.xd407167a86d34054 - 4);
			x75695dee32239965.Write(array, 0, array.Length);
			if (!flag || x75695dee32239965.Length >= xcd43f99b11aab3ea)
			{
				x64ab21d29ed7793a();
			}
			return;
		}
		x75695dee32239965 = new MemoryStream();
		xc6f5168692fc3511 = num;
		x0ce5bb654ee42bd2 = x6d569a893c7802a;
		if (flag)
		{
			xb47db6c16ebb1e4f = true;
			xcd43f99b11aab3ea = xf86de1bd2f396938.ReadInt32();
			byte[] array2 = xf86de1bd2f396938.ReadBytes(xe3e99d3417159bec.xd407167a86d34054 - 4);
			x75695dee32239965.Write(array2, 0, array2.Length);
		}
		else
		{
			xcd43f99b11aab3ea = xe3e99d3417159bec.xd407167a86d34054;
			byte[] array3 = xf86de1bd2f396938.ReadBytes(xe3e99d3417159bec.xd407167a86d34054);
			x75695dee32239965.Write(array3, 0, array3.Length);
			x64ab21d29ed7793a();
		}
	}

	private void x64ab21d29ed7793a()
	{
		x75695dee32239965.Position = 0L;
		x9e0567ffafb175ee x9e0567ffafb175ee2 = new x9e0567ffafb175ee(x75695dee32239965, xd995695f8e3419d6);
		object obj = x9e0567ffafb175ee2.x5645da3ef786a86f(x0ce5bb654ee42bd2, (int)x75695dee32239965.Length);
		if (obj != null)
		{
			xd995695f8e3419d6.x9deec9457dc2451d.xd6b6ed77479ef68c(xc6f5168692fc3511, obj);
			x0d299f323d241756.x40fc7e8a0d01195b(x75695dee32239965);
			x75695dee32239965 = null;
			xb47db6c16ebb1e4f = false;
		}
	}
}
