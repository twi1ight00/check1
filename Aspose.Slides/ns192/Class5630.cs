using System.Text;
using ns187;
using ns197;

namespace ns192;

internal class Class5630
{
	public static int int_0 = 0;

	public static int int_1 = 1;

	public static int int_2 = 2;

	public static int int_3 = 3;

	private Class5631 class5631_0;

	protected Class5157 class5157_0;

	private Class5155 class5155_0;

	private int int_4;

	private int int_5;

	private byte byte_0;

	internal Class5722 class5722_0;

	internal Class5722 class5722_1;

	internal Class5706 class5706_0;

	internal Class5706 class5706_1;

	protected Class5711 class5711_0;

	protected Class5630(Class5156 table, int colSpanIndex, int rowSpanIndex)
		: this(colSpanIndex, rowSpanIndex)
	{
		method_0(table);
	}

	protected Class5630(Class5157 cell, int colSpanIndex, int rowSpanIndex)
		: this(colSpanIndex, rowSpanIndex)
	{
		class5157_0 = cell;
		method_0(cell.vmethod_32());
	}

	internal Class5630(Class5631 primary, int colSpanIndex, int rowSpanIndex)
		: this(primary.method_1(), colSpanIndex, rowSpanIndex)
	{
		class5631_0 = primary;
	}

	private Class5630(int colSpanIndex, int rowSpanIndex)
	{
		int_4 = colSpanIndex;
		int_5 = rowSpanIndex;
	}

	private void method_0(Class5156 table)
	{
		if (!table.method_72())
		{
			class5711_0 = Class5711.smethod_0(table.method_71());
			vmethod_0();
		}
	}

	protected virtual void vmethod_0()
	{
		class5722_0 = class5157_0.class5722_0.method_3();
		if (int_5 > 0)
		{
			class5722_0.class5706_0 = Class5706.smethod_0();
		}
		class5722_1 = class5157_0.class5722_1.method_3();
		if (!vmethod_4())
		{
			class5722_1.class5706_0 = Class5706.smethod_0();
		}
		if (int_4 == 0)
		{
			class5706_0 = class5157_0.class5706_0;
		}
		else
		{
			class5706_0 = Class5706.smethod_0();
		}
		if (vmethod_3())
		{
			class5706_1 = class5157_0.class5706_1;
		}
		else
		{
			class5706_1 = Class5706.smethod_0();
		}
	}

	public Class5157 method_1()
	{
		return class5157_0;
	}

	public Class5155 method_2()
	{
		return class5155_0;
	}

	internal void method_3(Class5155 row)
	{
		class5155_0 = row;
	}

	public virtual Class5631 vmethod_1()
	{
		return class5631_0;
	}

	public virtual bool vmethod_2()
	{
		return false;
	}

	public bool method_4()
	{
		return class5157_0 == null;
	}

	public virtual bool vmethod_3()
	{
		return int_4 == class5157_0.method_53() - 1;
	}

	public virtual bool vmethod_4()
	{
		return int_5 == class5157_0.method_54() - 1;
	}

	public int method_5()
	{
		return int_5;
	}

	public int method_6()
	{
		return int_4;
	}

	public Class5703.Class5704 method_7(int which)
	{
		return which switch
		{
			0 => class5722_0.class5706_0.method_0(), 
			1 => class5722_0.class5706_1.method_0(), 
			2 => class5722_0.class5706_2.method_0(), 
			_ => null, 
		};
	}

	public Class5703.Class5704 method_8(int which)
	{
		return which switch
		{
			0 => class5722_1.class5706_0.method_0(), 
			1 => class5722_1.class5706_1.method_0(), 
			2 => class5722_1.class5706_2.method_0(), 
			_ => null, 
		};
	}

	public Class5703.Class5704 method_9()
	{
		return class5706_0.method_0();
	}

	public Class5703.Class5704 method_10()
	{
		return class5706_1.method_0();
	}

	internal void method_11(Class5630 other, int side)
	{
		switch (side)
		{
		case 0:
			class5722_0.method_0(other.class5722_1, withNormal: true, withLeadingTrailing: false, withRest: false);
			break;
		case 1:
			class5722_1.method_0(other.class5722_0, withNormal: true, withLeadingTrailing: false, withRest: false);
			break;
		case 2:
		{
			Class5706 @class = class5711_0.vmethod_1(class5706_0, other.class5706_1);
			if (@class != null)
			{
				class5706_0 = @class;
				other.class5706_1 = @class;
			}
			break;
		}
		case 3:
		{
			Class5706 @class = class5711_0.vmethod_1(class5706_1, other.class5706_0);
			if (@class != null)
			{
				class5706_1 = @class;
				other.class5706_0 = @class;
			}
			break;
		}
		}
	}

	internal void method_12(int side, Class5149 parent, bool withNormal, bool withLeadingTrailing, bool withRest)
	{
		switch (side)
		{
		case 0:
			class5722_0.method_2(parent.class5722_0, withNormal, withLeadingTrailing, withRest);
			break;
		case 1:
			class5722_1.method_2(parent.class5722_1, withNormal, withLeadingTrailing, withRest);
			break;
		}
	}

	internal void method_13(int side, Class5149 parent)
	{
		switch (side)
		{
		case 0:
		case 1:
			method_12(side, parent, withNormal: true, withLeadingTrailing: true, withRest: true);
			break;
		case 2:
			class5706_0 = class5711_0.vmethod_1(class5706_0, parent.class5706_0);
			break;
		case 3:
			class5706_1 = class5711_0.vmethod_1(class5706_1, parent.class5706_1);
			break;
		}
	}

	internal void method_14(int side, Class5706 segment)
	{
		switch (side)
		{
		case 2:
			class5706_0 = class5711_0.vmethod_1(class5706_0, segment);
			break;
		case 3:
			class5706_1 = class5711_0.vmethod_1(class5706_1, segment);
			break;
		}
	}

	internal void method_15(int side, Class5722 competitor, bool withNormal, bool withLeadingTrailing, bool withRest)
	{
		switch (side)
		{
		case 0:
			class5722_0.method_1(competitor, withNormal, withLeadingTrailing, withRest);
			break;
		case 1:
			class5722_1.method_1(competitor, withNormal, withLeadingTrailing, withRest);
			break;
		}
	}

	public bool method_16(int which)
	{
		return (byte_0 & (1 << which)) != 0;
	}

	public void method_17(int which, bool value)
	{
		if (value)
		{
			byte_0 |= (byte)(1 << which);
		}
		else
		{
			byte_0 &= (byte)(~(1 << which));
		}
	}

	public void method_18(int which)
	{
		method_17(which, value: true);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (method_4())
		{
			stringBuilder.Append("EMPTY");
		}
		else if (vmethod_2())
		{
			stringBuilder.Append("Primary");
		}
		stringBuilder.Append("GridUnit:");
		if (int_4 > 0)
		{
			stringBuilder.Append(" colSpan=").Append(int_4);
			if (vmethod_3())
			{
				stringBuilder.Append("(last)");
			}
		}
		if (int_5 > 0)
		{
			stringBuilder.Append(" rowSpan=").Append(int_5);
			if (vmethod_4())
			{
				stringBuilder.Append("(last)");
			}
		}
		if (!vmethod_2() && vmethod_1() != null)
		{
			stringBuilder.Append(" primary=").Append(vmethod_1().method_31());
			stringBuilder.Append("/").Append(vmethod_1().method_32());
			if (vmethod_1().method_1() != null)
			{
				stringBuilder.Append(" id=" + vmethod_1().method_1().vmethod_31());
			}
		}
		stringBuilder.Append(" flags=").Append(byte_0);
		return stringBuilder.ToString();
	}
}
