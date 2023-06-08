using System.Drawing;
using x38a89dee67fc7a16;
using x74500b509de15565;
using xa7850104c8d8c135;

namespace x0097836593a6a96a;

internal class x2244346d6dd1a19e : x055feb40a6f16001
{
	private byte[] x3846e3312ef6eb7b;

	public x2244346d6dd1a19e(x3fa09e8d7b952fbc metafileInfo)
		: base(metafileInfo)
	{
	}

	protected override bool DoPlayRecord(x58dacb9696b2ceb9 recordType, int dataSize)
	{
		switch (recordType)
		{
		case x58dacb9696b2ceb9.xa7ae776108b4fcb8:
		case x58dacb9696b2ceb9.x52dba942ff997276:
			return true;
		case x58dacb9696b2ceb9.x97a22b82bda979bd:
		{
			base.xf86de1bd2f396938.BaseStream.Position += 22L;
			int xf3df8caccbf90f = dataSize - 22;
			x3846e3312ef6eb7b = xdd1b8f14cc8ba86d.x10e7a0599aa303ae(base.xf86de1bd2f396938, xf3df8caccbf90f);
			return false;
		}
		default:
			return false;
		}
	}

	internal byte[] x2226c0b12a7471f1()
	{
		x0613827d1b6c81c9(default(SizeF), x48c97d04abed82b6: false);
		return x3846e3312ef6eb7b;
	}
}
