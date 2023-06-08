using x5794c252ba25e723;

namespace x1c8faa688b1f0b0c;

internal class xb8e7e788f6d59708 : xbaec545ec01f92ca, x0c06161ccb9341e4
{
	private x54366fa5f75a02f7 x06b983e52d670ed8;

	private xab391c46ff9a0a38 xa8548d289a49a30a;

	private xa702b771604efc86 xcbb1563eca0c21f2;

	public x54366fa5f75a02f7 x52dde376accdec7d
	{
		get
		{
			return x06b983e52d670ed8;
		}
		set
		{
			x06b983e52d670ed8 = value;
		}
	}

	public xab391c46ff9a0a38 x0e1bf8242ad10272
	{
		get
		{
			return xa8548d289a49a30a;
		}
		set
		{
			xa8548d289a49a30a = value;
		}
	}

	public xa702b771604efc86 xc9bcfb2d9630b0c7
	{
		get
		{
			return xcbb1563eca0c21f2;
		}
		set
		{
			xcbb1563eca0c21f2 = value;
		}
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitCanvasStart(this);
		base.Accept(visitor);
		visitor.VisitCanvasEnd(this);
	}

	public xb8e7e788f6d59708 xfe8f67360e300e88()
	{
		return (xb8e7e788f6d59708)MemberwiseClone();
	}
}
