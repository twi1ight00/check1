using ns224;

namespace ns238;

internal class Class6574 : Class6568
{
	public Class6574(Class6567 context)
		: base(context)
	{
	}

	public void method_0(Class5993 brush)
	{
		base.Writer.method_6(2, 2, closeByte: false);
		base.Writer.method_6(0, 2, closeByte: false);
		if (brush.InterpolationColors == null)
		{
			base.Writer.method_6(2, 4, closeByte: false);
			method_1(brush.StartColor, 0);
			method_1(brush.EndColor, byte.MaxValue);
			return;
		}
		base.Writer.method_6(brush.InterpolationColors.Length, 4, closeByte: false);
		for (int i = 0; i < brush.InterpolationColors.Length; i++)
		{
			Class5998 color = brush.InterpolationColors[i].Color;
			byte ratio = (byte)(brush.InterpolationColors[i].Position * 255f);
			method_1(color, ratio);
		}
	}

	private void method_1(Class5998 color, byte ratio)
	{
		base.Writer.WriteByte(ratio);
		base.Writer.method_11(color);
	}
}
