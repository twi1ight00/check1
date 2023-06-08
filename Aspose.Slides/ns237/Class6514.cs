using System;
using System.Drawing;
using System.IO;
using ns221;
using ns224;

namespace ns237;

internal class Class6514 : Class6511
{
	private readonly MemoryStream memoryStream_0;

	private readonly Class6678 class6678_0;

	private Class6513 class6513_0;

	internal Stream BaseStream => memoryStream_0;

	internal Class6678 Writer => class6678_0;

	protected Class6513 StreamLength => class6513_0;

	public Class6514(Class6672 context)
		: base(context)
	{
		memoryStream_0 = new MemoryStream();
		class6678_0 = new Class6678(memoryStream_0);
	}

	internal void Write(string text)
	{
		class6678_0.Write(text);
	}

	public void method_1(string text)
	{
		class6678_0.method_3(text);
	}

	internal void method_2(string format, string arg0)
	{
		class6678_0.method_4(format, arg0);
	}

	internal void method_3(string format, string arg0, string arg1)
	{
		class6678_0.method_5(format, arg0, arg1);
	}

	internal void method_4(string text)
	{
		class6678_0.method_0(text);
	}

	internal void method_5(string format, string arg0)
	{
		class6678_0.Write(format, arg0);
		class6678_0.method_1();
	}

	internal void method_6(string format, string arg0, string arg1)
	{
		class6678_0.Write(format, arg0, arg1);
		class6678_0.method_1();
	}

	internal void Write(byte[] buffer, int index, int count)
	{
		class6678_0.Write(buffer, index, count);
	}

	internal void WriteByte(byte value)
	{
		class6678_0.WriteByte(value);
	}

	internal void method_7(PointF point)
	{
		class6678_0.Write(point.X);
		class6678_0.method_1();
		class6678_0.Write(point.Y);
	}

	internal void method_8(float[] values)
	{
		class6678_0.method_25(values);
	}

	internal void method_9(Class6002 matrix, string op)
	{
		class6678_0.method_27(matrix);
		class6678_0.method_1();
		class6678_0.Write(op);
		class6678_0.method_1();
	}

	internal void method_10(string text)
	{
		class6678_0.method_21(text);
	}

	public void method_11(int value)
	{
		class6678_0.method_22(value);
	}

	[Attribute7(true)]
	internal virtual void vmethod_2(Class6679 writer)
	{
	}

	public override void vmethod_0(Class6679 writer)
	{
		writer.method_29(this);
		writer.method_6();
		class6513_0 = new Class6513(class6672_0);
		vmethod_2(writer);
		writer.method_8("/Length", class6513_0.IndirectReference);
		Class6662 @class = vmethod_3();
		@class?.vmethod_1(writer);
		writer.method_7();
		writer.method_3("stream");
		Stream stream = writer.BaseStream;
		Class6549 class2 = method_0();
		if (class2 != null)
		{
			stream = class2.method_0(stream);
		}
		if (@class != null)
		{
			stream = @class.vmethod_0(stream);
		}
		long length = stream.Length;
		stream.Write(memoryStream_0.GetBuffer(), 0, (int)memoryStream_0.Length);
		long num = stream.Length - length;
		writer.method_2();
		writer.Write("endstream");
		writer.method_30();
		class6513_0.Length = (int)num;
		class6513_0.vmethod_0(writer);
	}

	internal virtual Class6662 vmethod_3()
	{
		if (class6672_0.PdfaCompliant)
		{
			return null;
		}
		if (memoryStream_0.Length < 200L)
		{
			return null;
		}
		return class6672_0.Options.TextCompression switch
		{
			Enum890.const_0 => null, 
			Enum890.const_1 => new Class6667(), 
			Enum890.const_2 => new Class6666(), 
			Enum890.const_3 => new Class6665(), 
			_ => throw new InvalidOperationException("Unknown text compression filter type."), 
		};
	}
}
