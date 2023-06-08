using System;
using System.IO;
using ns22;

namespace ns18;

internal class Class1433 : Class1432
{
	private Enum208 enum208_0;

	protected override string Name => "CCITTFaxDecode";

	internal Class1433(Enum208 enum208_1)
	{
		enum208_0 = enum208_1;
	}

	internal override MemoryStream vmethod_0(MemoryStream memoryStream_0)
	{
		return memoryStream_0;
	}

	internal override void vmethod_1(Class1447 class1447_0)
	{
		base.vmethod_1(class1447_0);
		class1447_0.method_6("/DecodeParms <<");
		class1447_0.method_16("/K", method_0());
		class1447_0.method_16("/Columns", 173);
		class1447_0.method_6(">>");
	}

	protected override Stream14 vmethod_2(Stream stream_0)
	{
		return null;
	}

	[Attribute0(true)]
	private int method_0()
	{
		return enum208_0 switch
		{
			Enum208.const_5 => 0, 
			Enum208.const_6 => -1, 
			_ => throw new Exception("Unexpected compression."), 
		};
	}
}
