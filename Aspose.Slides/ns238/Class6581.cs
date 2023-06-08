namespace ns238;

internal class Class6581 : Class6568
{
	private int int_0;

	private int int_1;

	public int CurrentX => int_0;

	public int CurrentY => int_1;

	public Class6581(Class6567 context)
		: base(context)
	{
	}

	public void method_0()
	{
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_6(0, 5, closeByte: true);
	}

	public void method_1(int dx, int dy)
	{
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: true, closeByte: false);
		int num = Class6566.smethod_0(new int[2] { dx, dy });
		base.Writer.method_6(num, 5, closeByte: false);
		base.Writer.method_5(dx, num, closeByte: false);
		base.Writer.method_5(dy, num, closeByte: false);
		int_0 = dx;
		int_1 = dy;
	}

	public void method_2()
	{
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: true, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_6(1, 1, closeByte: false);
	}

	public void method_3()
	{
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_4(bit: true, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		base.Writer.method_6(1, 1, closeByte: false);
	}

	public void method_4(int controldx, int controldy, int anchordx, int anchordy)
	{
		base.Writer.method_4(bit: true, closeByte: false);
		base.Writer.method_4(bit: false, closeByte: false);
		int num = Class6566.smethod_0(new int[4] { controldx, controldy, anchordx, anchordy });
		base.Writer.method_6(num - 2, 4, closeByte: false);
		base.Writer.method_5(controldx, num, closeByte: false);
		base.Writer.method_5(controldy, num, closeByte: false);
		base.Writer.method_5(anchordx, num, closeByte: false);
		base.Writer.method_5(anchordy, num, closeByte: false);
		int_0 += controldx + anchordx;
		int_1 += controldy + anchordy;
	}

	public void method_5(int dx, int dy)
	{
		if (dx != 0 || dy != 0)
		{
			base.Writer.method_4(bit: true, closeByte: false);
			base.Writer.method_4(bit: true, closeByte: false);
			int num = Class6566.smethod_0(new int[2] { dx, dy });
			base.Writer.method_6(num - 2, 4, closeByte: false);
			bool flag = dx != 0 && dy != 0;
			bool bit = dx == 0;
			base.Writer.method_4(flag, closeByte: false);
			if (!flag)
			{
				base.Writer.method_4(bit, closeByte: false);
			}
			if (dx != 0)
			{
				base.Writer.method_5(dx, num, closeByte: false);
			}
			if (dy != 0)
			{
				base.Writer.method_5(dy, num, closeByte: false);
			}
			int_0 += dx;
			int_1 += dy;
		}
	}
}
