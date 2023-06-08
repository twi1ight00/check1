using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ClassInterface(ClassInterfaceType.None)]
[Guid("99ed6b73-87fa-4a5d-b614-2d6eddd40022")]
[ComVisible(true)]
public class ShapeFrame : ICloneable, IShapeFrame
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private NullableBool nullableBool_0;

	private NullableBool nullableBool_1;

	public float X => float_0;

	public float Y => float_1;

	public float Width => float_2;

	public float Height => float_3;

	public float Rotation => float_4;

	public float CenterX => float_0 + float_2 / 2f;

	public float CenterY => float_1 + float_3 / 2f;

	public NullableBool FlipH => nullableBool_0;

	public NullableBool FlipV => nullableBool_1;

	public RectangleF Rectangle => new RectangleF(float_0, float_1, float_2, float_3);

	ICloneable IShapeFrame.AsICloneable => this;

	public ShapeFrame(float x, float y, float width, float height, NullableBool flipH, NullableBool flipV, float rotationAngle)
	{
		float_0 = x;
		float_1 = y;
		float_2 = width;
		float_3 = height;
		float_4 = rotationAngle;
		nullableBool_0 = flipH;
		nullableBool_1 = flipV;
	}

	internal ShapeFrame(double x, double y, double width, double height, NullableBool flipH, NullableBool flipV, float rotationAngle)
		: this((float)x, (float)y, (float)width, (float)height, flipH, flipV, rotationAngle)
	{
	}

	internal ShapeFrame()
	{
	}

	internal static float smethod_0(double rotation)
	{
		if (rotation < 0.0)
		{
			rotation += 360.0 + Math.Floor((0.0 - rotation) / 360.0) * 360.0;
		}
		rotation %= 360.0;
		return (float)rotation;
	}

	public override bool Equals(object obj)
	{
		if (obj is ShapeFrame value)
		{
			return Equals(value);
		}
		return false;
	}

	public bool Equals(ShapeFrame value)
	{
		if (nullableBool_0 == value.nullableBool_0 && nullableBool_1 == value.nullableBool_1)
		{
			return (double)(Math.Abs(float_0 - value.float_0) + Math.Abs(float_1 - value.float_1) + Math.Abs(float_2 - value.float_2) + Math.Abs(float_3 - value.float_3) + Math.Abs(smethod_0(float_4) - smethod_0(value.float_4))) < 0.001;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return RuntimeHelpers.GetHashCode(this);
	}

	public object Clone()
	{
		return CloneShapeFrame();
	}

	public IShapeFrame CloneShapeFrame()
	{
		return new ShapeFrame(float_0, float_1, float_2, float_3, nullableBool_0, nullableBool_1, float_4);
	}
}
