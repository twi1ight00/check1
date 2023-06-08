using System;
using System.IO;
using ns22;

namespace ns18;

internal abstract class Class1432
{
	protected abstract string Name { get; }

	internal virtual MemoryStream vmethod_0(MemoryStream memoryStream_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		Stream14 stream = vmethod_2(memoryStream);
		memoryStream_0.WriteTo(stream);
		return memoryStream;
	}

	internal virtual void vmethod_1(Class1447 class1447_0)
	{
		class1447_0.method_11("/Filter", $"/{Name}");
	}

	[Attribute0(true)]
	internal static Class1432 smethod_0(Enum205 enum205_0, Enum208 enum208_0)
	{
		return enum205_0 switch
		{
			Enum205.const_0 => null, 
			Enum205.const_3 => new Class1436(), 
			Enum205.const_4 => new Class1435(), 
			Enum205.const_5 => new Class1437(), 
			Enum205.const_6 => new Class1433(enum208_0), 
			Enum205.const_8 => new Class1434(), 
			_ => throw new Exception("Unknown filter type."), 
		};
	}

	[Attribute0(true)]
	protected abstract Stream14 vmethod_2(Stream stream_0);
}
