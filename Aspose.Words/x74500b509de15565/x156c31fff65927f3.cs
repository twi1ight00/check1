using System.Drawing;
using System.IO;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;

namespace x74500b509de15565;

internal class x156c31fff65927f3 : x055feb40a6f16001
{
	private MemoryStream x0499b2039c518566;

	private bool xa4b2b2823a6aaa9f;

	private int x896ea69fd9db6c8e;

	public x156c31fff65927f3(x3fa09e8d7b952fbc metafileInfo)
		: base(metafileInfo)
	{
	}

	internal byte[] x2ebb73bd61f0b1e0()
	{
		x0499b2039c518566 = new MemoryStream();
		x0613827d1b6c81c9(default(SizeF), x48c97d04abed82b6: false);
		byte[] array = x0499b2039c518566.ToArray();
		x0d299f323d241756.x40fc7e8a0d01195b(x0499b2039c518566);
		x0499b2039c518566 = null;
		if (xa4b2b2823a6aaa9f && array.Length > 0)
		{
			return array;
		}
		return null;
	}

	protected override bool DoPlayRecord(x58dacb9696b2ceb9 recordType, int dataSize)
	{
		if (recordType == x58dacb9696b2ceb9.x70af8406c596bd40)
		{
			x2272448a69283655 x2272448a = (x2272448a69283655)base.xf86de1bd2f396938.ReadInt16();
			if (x2272448a != x2272448a69283655.xd647d6e24552fb57)
			{
				return false;
			}
			base.xf86de1bd2f396938.ReadUInt16();
			int num = base.xf86de1bd2f396938.ReadInt32();
			int num2 = base.xf86de1bd2f396938.ReadInt32();
			int num3 = base.xf86de1bd2f396938.ReadInt32();
			if (num != 1128680791 || num2 != 1 || num3 != 65536)
			{
				return false;
			}
			base.xf86de1bd2f396938.ReadUInt16();
			base.xf86de1bd2f396938.ReadInt32();
			int num4 = base.xf86de1bd2f396938.ReadInt32();
			int count = base.xf86de1bd2f396938.ReadInt32();
			int num5 = base.xf86de1bd2f396938.ReadInt32();
			int num6 = base.xf86de1bd2f396938.ReadInt32();
			byte[] array = base.xf86de1bd2f396938.ReadBytes(count);
			x0499b2039c518566.Write(array, 0, array.Length);
			x896ea69fd9db6c8e++;
			xa4b2b2823a6aaa9f = num6 == x0499b2039c518566.Length && num5 == 0 && num4 == x896ea69fd9db6c8e;
			return x0499b2039c518566.Length < num6;
		}
		return false;
	}
}
