using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns18;

internal class Class1199 : Brush
{
	private PointF pointF_0;

	private PointF pointF_1;

	private Color color_0;

	private Color color_1;

	private float float_0;

	public Class1199(PointF pointF_2, PointF pointF_3, Color color_2, Color color_3, float float_1)
	{
		pointF_0 = pointF_2;
		pointF_1 = pointF_3;
		color_0 = color_2;
		color_1 = color_3;
		float_0 = 1f;
	}

	[SpecialName]
	public Color method_0()
	{
		return color_1;
	}

	[SpecialName]
	public Color method_1()
	{
		return color_0;
	}

	[SpecialName]
	public PointF method_2()
	{
		return pointF_1;
	}

	[SpecialName]
	public PointF method_3()
	{
		return pointF_0;
	}

	public override object Clone()
	{
		throw new NotImplementedException();
	}
}
