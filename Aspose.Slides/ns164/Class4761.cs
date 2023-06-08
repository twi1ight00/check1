using System.Drawing;
using ns165;
using ns167;

namespace ns164;

internal class Class4761 : Class4755
{
	private readonly bool bool_0;

	private readonly Class4790 class4790_0;

	private readonly bool bool_1;

	private readonly Class4767 class4767_1;

	private readonly bool bool_2;

	internal Class4761(Class4790 picture, bool warpTextAround, bool isRelativePosition, bool isBehindText, Class4767 format)
	{
		class4790_0 = picture;
		bool_1 = warpTextAround;
		bool_2 = isRelativePosition;
		class4767_1 = format;
		class4767_1.Add(Enum670.const_24, class4790_0.ZId);
		bool_0 = isBehindText;
	}

	internal override void vmethod_0(Interface145 builder)
	{
		builder.imethod_22(new PointF(class4790_0.BoundingBox.Left, class4790_0.BoundingBox.Top), class4790_0.BoundingBox.Size, class4790_0.ImageData, bool_1, bool_2, bool_0, class4767_1);
	}
}
