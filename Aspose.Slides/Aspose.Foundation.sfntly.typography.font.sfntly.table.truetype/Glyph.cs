using System.Text;
using ns226;
using ns229;
using ns231;

namespace Aspose.Foundation.sfntly.typography.font.sfntly.table.truetype;

internal abstract class Glyph : Class6041
{
	public enum GlyphType
	{
		Simple,
		Composite
	}

	public abstract class Class6113
	{
	}

	public abstract class Class6084 : Class6073
	{
		protected int int_0;

		protected Class6084(Class6017 data)
			: base(data)
		{
		}

		protected Class6084(Class6016 data)
			: base(data)
		{
		}

		protected Class6084(Class6017 data, int offset, int length)
			: this((Class6017)data.vmethod_0(offset, length))
		{
		}

		internal static Class6084 smethod_0(Class6030.Class6071 tableBuilder, Class6016 data)
		{
			return smethod_1(tableBuilder, data, 0, data.method_2());
		}

		internal static Class6084 smethod_1(Class6030.Class6071 tableBuilder, Class6016 data, int offset, int length)
		{
			if (Glyph.smethod_0(data, offset, length) == GlyphType.Simple)
			{
				return new Class6053.Class6086(data, offset, length);
			}
			return new Class6052.Class6085(data, offset, length);
		}

		protected override void vmethod_5()
		{
		}

		internal override int vmethod_4()
		{
			return method_6().method_2();
		}

		internal override bool vmethod_3()
		{
			return true;
		}

		internal override int vmethod_2(Class6017 newData)
		{
			return method_6().CopyTo(newData);
		}
	}

	protected volatile bool bool_0;

	protected object object_0 = new object();

	private GlyphType glyphType_0;

	private int int_1;

	protected Glyph(Class6016 data, GlyphType glyphType)
		: base(data)
	{
		glyphType_0 = glyphType;
		if (class6016_0.method_2() == 0)
		{
			int_1 = 0;
		}
		else
		{
			int_1 = class6016_0.method_17(0);
		}
	}

	protected Glyph(Class6016 data, int offset, int length, GlyphType glyphType)
		: base(data, offset, length)
	{
		glyphType_0 = glyphType;
		if (class6016_0.method_2() == 0)
		{
			int_1 = 0;
		}
		else
		{
			int_1 = class6016_0.method_17(0);
		}
	}

	private static GlyphType smethod_0(Class6016 data, int offset, int length)
	{
		if (length == 0)
		{
			return GlyphType.Simple;
		}
		int num = data.method_17(offset);
		if (num >= 0)
		{
			return GlyphType.Simple;
		}
		return GlyphType.Composite;
	}

	internal static Glyph smethod_1(Class6030 table, Class6016 data, int offset, int length)
	{
		if (smethod_0(data, offset, length) == GlyphType.Simple)
		{
			return new Class6053(data, offset, length);
		}
		return new Class6052(data, offset, length);
	}

	protected abstract void Initialize();

	public override int vmethod_0()
	{
		Initialize();
		return base.vmethod_0();
	}

	public GlyphType method_7()
	{
		return glyphType_0;
	}

	public int method_8()
	{
		return int_1;
	}

	public int method_9()
	{
		return class6016_0.method_17(2);
	}

	public int method_10()
	{
		return class6016_0.method_17(6);
	}

	public int method_11()
	{
		return class6016_0.method_17(4);
	}

	public int method_12()
	{
		return class6016_0.method_17(8);
	}

	public abstract int vmethod_1();

	public abstract Class6016 vmethod_2();

	public string method_13()
	{
		return method_14(0);
	}

	public string method_14(int length)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(method_7());
		stringBuilder.Append(", contours=");
		stringBuilder.Append(method_8());
		stringBuilder.Append(", [xmin=");
		stringBuilder.Append(method_9());
		stringBuilder.Append(", ymin=");
		stringBuilder.Append(method_11());
		stringBuilder.Append(", xmax=");
		stringBuilder.Append(method_10());
		stringBuilder.Append(", ymax=");
		stringBuilder.Append(method_12());
		stringBuilder.Append("]");
		stringBuilder.Append("\n");
		return stringBuilder.ToString();
	}
}
