using System.Drawing;

namespace ns18;

internal class Class457 : Class453
{
	private SizeF sizeF_0;

	public SizeF Size => sizeF_0;

	public float Width => sizeF_0.Width;

	public float Height => sizeF_0.Height;

	public Class457(SizeF sizeF_1)
	{
		sizeF_0 = sizeF_1;
	}

	public Class457()
	{
	}

	public Class457(float float_0, float float_1)
		: this(new SizeF(float_0, float_1))
	{
	}

	public override void vmethod_0(Class468 class468_0)
	{
		class468_0.vmethod_1(this);
		base.vmethod_0(class468_0);
		class468_0.vmethod_2(this);
	}
}
