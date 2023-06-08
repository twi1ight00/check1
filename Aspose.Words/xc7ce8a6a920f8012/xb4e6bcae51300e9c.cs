using System.IO;

namespace xc7ce8a6a920f8012;

internal class xb4e6bcae51300e9c : x0096796e2eb81db6
{
	private long x558f176dc2e279e5;

	public xb4e6bcae51300e9c(x34b34bf589d8ec1e context)
		: base(context)
	{
	}

	public void xacf4b9ddf32bef06()
	{
		x558f176dc2e279e5 = base.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream.Position;
		base.x5aa326f374b3d0ef.x4c116b70372a3c6d(new byte[6]);
	}

	public void xc463dec5a3ab6e2d(xf066f1f57515a14c x63d966043264a891)
	{
		int xb3bea56f1f = (int)(base.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream.Position - x558f176dc2e279e5 - 6);
		base.x5aa326f374b3d0ef.x7fdc1bfc45368624.Seek((int)x558f176dc2e279e5, SeekOrigin.Begin);
		base.x5aa326f374b3d0ef.x4eadf767e5f91a38(x63d966043264a891, xb3bea56f1f);
		base.x5aa326f374b3d0ef.x7fdc1bfc45368624.Seek(0, SeekOrigin.End);
	}
}
