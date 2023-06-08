using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using ns22;
using ns40;

namespace ns18;

internal class Class939 : Class938
{
	private MemoryStream memoryStream_0;

	private Class1446 class1446_0;

	private readonly bool bool_0;

	private Class1432 class1432_0;

	protected Class1432 Filter
	{
		get
		{
			if (class1432_0 == null)
			{
				class1432_0 = Class1432.smethod_0(FilterType, class1440_0.method_1().method_1());
			}
			return class1432_0;
		}
	}

	private Enum205 FilterType
	{
		get
		{
			if (vmethod_4())
			{
				return class1440_0.method_1().method_6();
			}
			return class1440_0.method_1().method_5();
		}
	}

	public Class939(Class1440 class1440_1)
		: this(class1440_1, bool_1: false)
	{
	}

	public Class939(Class1440 class1440_1, bool bool_1)
		: base(class1440_1)
	{
		bool_0 = bool_1;
		memoryStream_0 = new MemoryStream();
		class1446_0 = new Class1446(memoryStream_0);
	}

	[SpecialName]
	internal Stream method_4()
	{
		return memoryStream_0;
	}

	internal void Write(string string_1)
	{
		class1446_0.Write(string_1);
	}

	internal void Write(string string_1, object object_0)
	{
		class1446_0.Write(string_1, object_0);
	}

	public void method_5(string string_1)
	{
		class1446_0.method_6(string_1);
	}

	internal void method_6(string string_1, object object_0)
	{
		class1446_0.method_7(string_1, object_0);
	}

	internal void method_7(string string_1, object object_0, object object_1)
	{
		class1446_0.method_8(string_1, object_0, object_1);
	}

	internal void method_8(string string_1)
	{
		class1446_0.method_2(string_1);
	}

	internal void method_9(string string_1, object object_0)
	{
		class1446_0.method_3(string_1, object_0);
	}

	internal void method_10(string string_1, object object_0, object object_1)
	{
		class1446_0.method_4(string_1, object_0, object_1);
	}

	internal void Write(byte[] byte_0, int int_1, int int_2)
	{
		class1446_0.Write(byte_0, int_1, int_2);
	}

	internal void WriteByte(byte byte_0)
	{
		class1446_0.Write(byte_0);
	}

	internal void method_11(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, string string_1)
	{
		method_8($"{Class1446.smethod_5(float_0)} {Class1446.smethod_5(float_1)} {Class1446.smethod_5(float_2)} {Class1446.smethod_5(float_3)} {Class1446.smethod_5(float_4)} {Class1446.smethod_5(float_5)} {string_1}");
	}

	internal void method_12(float[] float_0, string string_1)
	{
		method_11(float_0[0], float_0[1], float_0[2], float_0[3], float_0[4], float_0[5], string_1);
	}

	internal void method_13(Matrix matrix_0, string string_1)
	{
		method_12(matrix_0.Elements, string_1);
	}

	internal void method_14(string string_1)
	{
		class1446_0.method_18(string_1);
	}

	internal void method_15(byte[] byte_0)
	{
		class1446_0.method_19(byte_0);
	}

	[Attribute0(true)]
	internal virtual void vmethod_3(Class1447 class1447_0)
	{
	}

	public void method_16(Class1447 class1447_0)
	{
		MemoryStream memoryStream = memoryStream_0;
		if (Filter != null)
		{
			memoryStream = Filter.vmethod_0(memoryStream_0);
		}
		class1447_0.method_24(this);
		class1447_0.method_9();
		vmethod_3(class1447_0);
		class1447_0.method_17("/Length", memoryStream.Length);
		if (bool_0)
		{
			class1447_0.method_17("/Length1", memoryStream_0.Length);
		}
		if (Filter != null)
		{
			Filter.vmethod_1(class1447_0);
		}
		class1447_0.method_10();
		class1447_0.Write("\r\nstream\r\n");
		memoryStream.WriteTo(class1447_0.method_0());
		class1447_0.Write("\r\nendstream\r\n");
		class1447_0.method_25();
		memoryStream_0.Dispose();
		memoryStream.Dispose();
		memoryStream_0 = null;
		memoryStream = null;
	}

	public void method_17(Class1447 class1447_0)
	{
		MemoryStream memoryStream = memoryStream_0;
		if (Filter != null)
		{
			memoryStream = Filter.vmethod_0(memoryStream_0);
		}
		class1447_0.method_24(this);
		class1447_0.method_9();
		vmethod_3(class1447_0);
		class1447_0.method_17("/Length", memoryStream.Length);
		if (bool_0)
		{
			class1447_0.method_17("/Length1", memoryStream.Length);
		}
		if (Filter != null)
		{
			Filter.vmethod_1(class1447_0);
		}
		class1447_0.method_10();
		class1447_0.Write("\r\nstream\r\n");
		Class945 @class = class1440_0.method_7();
		@class.method_10(this);
		@class.method_5(memoryStream);
		memoryStream.WriteTo(class1447_0.method_0());
		class1447_0.Write("\r\nendstream\r\n");
		class1447_0.method_25();
	}

	public override void vmethod_1(Class1447 class1447_0)
	{
		if (class1440_0.method_1().SecurityOptions != null)
		{
			method_17(class1447_0);
		}
		else
		{
			method_16(class1447_0);
		}
	}

	[SpecialName]
	protected virtual bool vmethod_4()
	{
		return false;
	}
}
