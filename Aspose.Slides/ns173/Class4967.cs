using System;
using System.Collections;
using System.Text;
using ns171;
using ns205;

namespace ns173;

internal class Class4967 : Class4942
{
	private ArrayList arrayList_1;

	private int int_15;

	private int int_16;

	private int int_17;

	private int int_18;

	public Class4967(int colCount, int colGap, int ipd)
	{
		method_29(Class5757.int_24, true);
		int_15 = colCount;
		int_16 = colGap;
		int_12 = ipd;
		int_18 = 0;
		method_37();
	}

	private void method_37()
	{
		arrayList_1 = new ArrayList(int_15);
		int_17 = (int_12 - (int_15 - 1) * int_16) / int_15;
		for (int i = 0; i < int_15; i++)
		{
			Class4961 value = new Class4961(int_17);
			arrayList_1.Add(value);
		}
	}

	public int method_38()
	{
		return int_15;
	}

	public int method_39()
	{
		return int_17;
	}

	public int method_40()
	{
		return vmethod_1();
	}

	public Class4961 method_41(int colRequested)
	{
		if (colRequested < 0 || colRequested >= int_15)
		{
			throw new ArgumentException("Invalid column number " + colRequested + " requested; only 0-" + (int_15 - 1) + " available.");
		}
		return (Class4961)arrayList_1[colRequested];
	}

	public Class4961 method_42()
	{
		return method_41(int_18);
	}

	public int method_43()
	{
		return int_18;
	}

	public Class4961 method_44()
	{
		if (!method_45())
		{
			throw new InvalidOperationException("(Internal error.) No more flows left in span.");
		}
		int_18++;
		return method_41(int_18);
	}

	public bool method_45()
	{
		return int_18 < int_15 - 1;
	}

	public void method_46()
	{
		int val = int.MinValue;
		for (int i = 0; i < int_15; i++)
		{
			val = Math.Max(val, method_41(i).method_15());
		}
		int_13 = val;
	}

	public bool method_47()
	{
		int num = 0;
		for (int i = 0; i < method_38(); i++)
		{
			Class4961 @class = method_41(i);
			if (@class != null && @class.method_37() != null)
			{
				num += @class.method_37().Count;
			}
		}
		return num == 0;
	}

	public override void vmethod_4(Interface231 wmtg)
	{
		Enum679 @enum = (Enum679)wmtg.imethod_4().method_1();
		if (@enum == Enum679.const_289)
		{
			method_16(1);
			{
				foreach (Class4961 item in arrayList_1)
				{
					item.method_16(1);
				}
				return;
			}
		}
		method_17();
		foreach (Class4961 item2 in arrayList_1)
		{
			item2.method_17();
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(base.ToString());
		if (int_15 > 1)
		{
			stringBuilder.Append(" {colCount=").Append(int_15);
			stringBuilder.Append(", colWidth=").Append(int_17);
			stringBuilder.Append(", curFlowIdx=").Append(int_18);
			stringBuilder.Append("}");
		}
		return stringBuilder.ToString();
	}
}
