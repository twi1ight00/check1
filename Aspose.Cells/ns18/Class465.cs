using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using ns22;

namespace ns18;

internal class Class465 : Class452
{
	private readonly long long_0;

	private readonly PointF pointF_0;

	private SizeF sizeF_0;

	private byte[] byte_0;

	private Class464 class464_0;

	private Enum158 enum158_0 = Enum158.const_0;

	internal Class458 class458_0;

	public SizeF Size
	{
		get
		{
			return sizeF_0;
		}
		set
		{
			sizeF_0 = value;
		}
	}

	public Enum200 ImageType => Class1404.smethod_1(byte_0);

	public Class464 Hyperlink => class464_0;

	public Class465(PointF pointF_1, SizeF sizeF_1, byte[] byte_1)
	{
		pointF_0 = pointF_1;
		sizeF_0 = sizeF_1;
		byte_0 = byte_1;
		Class935 @class = new Class935();
		@class.Update(byte_1);
		long_0 = @class.method_0();
		@class = null;
	}

	public static Class465 smethod_0(PointF pointF_1, SizeF sizeF_1, Stream stream_0)
	{
		byte[] byte_ = Class936.smethod_1(stream_0, bool_0: false);
		return new Class465(pointF_1, sizeF_1, byte_);
	}

	public override void vmethod_0(Class468 class468_0)
	{
		class468_0.vmethod_13(this);
	}

	[SpecialName]
	public long method_1()
	{
		return long_0;
	}

	[SpecialName]
	public PointF method_2()
	{
		return pointF_0;
	}

	[SpecialName]
	public byte[] method_3()
	{
		return byte_0;
	}

	[SpecialName]
	public Class1403 method_4()
	{
		return Class1404.smethod_4(byte_0);
	}

	[SpecialName]
	public void method_5(Class464 class464_1)
	{
		class464_0 = class464_1;
	}

	[SpecialName]
	public void method_6(Enum158 enum158_1)
	{
		enum158_0 = enum158_1;
	}

	[SpecialName]
	public RectangleF method_7()
	{
		return new RectangleF(method_2(), sizeF_0);
	}
}
