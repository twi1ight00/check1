namespace ns237;

internal class Class6518 : Class6514
{
	private readonly byte[] byte_0;

	private readonly int int_1;

	private readonly int int_2;

	internal Class6518(Class6672 context, byte[] alphaValues, int width, int height)
		: base(context)
	{
		byte_0 = alphaValues;
		int_1 = width;
		int_2 = height;
	}

	public override void vmethod_0(Class6679 writer)
	{
		Write(byte_0, 0, byte_0.Length);
		base.vmethod_0(writer);
	}

	internal override void vmethod_2(Class6679 writer)
	{
		writer.method_8("/Type", "/XObject");
		writer.method_8("/Subtype", "/Image");
		writer.method_18("/Width", int_1);
		writer.method_18("/Height", int_2);
		writer.method_8("/ColorSpace", "/DeviceGray");
		writer.method_18("/BitsPerComponent", 8);
	}

	internal override Class6662 vmethod_3()
	{
		switch (class6672_0.Options.TextCompression)
		{
		default:
			return base.vmethod_3();
		case Enum890.const_0:
		case Enum890.const_2:
		{
			Class6666 @class = new Class6666();
			@class.BitsPerComponent = 8;
			@class.Columns = int_1;
			@class.Colors = 1;
			@class.IsBaselinePredictor = true;
			return @class;
		}
		}
	}
}
