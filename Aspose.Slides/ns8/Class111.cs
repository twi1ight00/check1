using System;
using ns56;

namespace ns8;

internal class Class111 : Class103
{
	private Enum129 enum129_0;

	private int int_0;

	private bool bool_0;

	private bool bool_1;

	private Enum130 enum130_0;

	private bool bool_2;

	private Enum120 enum120_1;

	private Enum121 enum121_1;

	public Enum129 Breakpoint => enum129_0;

	public int BreakpointFixedValue => int_0;

	public bool IsCentred => bool_0;

	public bool IsSameDirection => bool_1;

	public Enum130 Direction => enum130_0;

	public bool IsFlowByRows => bool_2;

	public Enum120 HorizontalNodeAlignment => enum120_1;

	public Enum121 VerticalNodeAlignment => enum121_1;

	public Class111(Class2146 algorithm)
	{
		enum129_0 = Enum129.const_0;
		int_0 = 2;
		bool_0 = false;
		bool_1 = true;
		enum130_0 = Enum130.const_0;
		bool_2 = true;
		enum120_1 = Enum120.const_2;
		enum121_1 = Enum121.const_2;
		base.HorizontalAlignment = Enum120.const_2;
		base.VerticalAlignment = Enum121.const_2;
		Class2177[] paramList = algorithm.ParamList;
		foreach (Class2177 @class in paramList)
		{
			if (@class.Type == Enum304.const_6)
			{
				enum129_0 = method_0(@class.Val);
			}
			else if (@class.Type == Enum304.const_7)
			{
				int_0 = Convert.ToInt32(@class.Val);
			}
			else if (@class.Type == Enum304.const_29)
			{
				bool_0 = @class.Val == "ctr";
			}
			else if (@class.Type == Enum304.const_11)
			{
				bool_1 = @class.Val == "sameDir";
			}
			else if (@class.Type == Enum304.const_19)
			{
				enum130_0 = method_1(@class.Val);
			}
			else if (@class.Type == Enum304.const_18)
			{
				bool_2 = @class.Val == "row";
			}
			else if (@class.Type == Enum304.const_27)
			{
				enum120_1 = Class103.smethod_1(@class.Val);
			}
			else if (@class.Type == Enum304.const_28)
			{
				enum121_1 = Class103.smethod_2(@class.Val);
			}
			else if (@class.Type == Enum304.const_21)
			{
				base.HorizontalAlignment = Class103.smethod_1(@class.Val);
			}
			else if (@class.Type == Enum304.const_54)
			{
				base.VerticalAlignment = Class103.smethod_2(@class.Val);
			}
		}
	}

	private Enum129 method_0(string value)
	{
		return value switch
		{
			"fixed" => Enum129.const_2, 
			"bal" => Enum129.const_1, 
			_ => Enum129.const_0, 
		};
	}

	private Enum130 method_1(string value)
	{
		return value switch
		{
			"bR" => Enum130.const_3, 
			"bL" => Enum130.const_2, 
			"tR" => Enum130.const_1, 
			_ => Enum130.const_0, 
		};
	}
}
