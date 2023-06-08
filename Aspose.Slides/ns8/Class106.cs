using System;
using System.Collections.Generic;
using ns33;
using ns56;

namespace ns8;

internal class Class106 : Class103
{
	private string string_0;

	private string string_1;

	private Enum123[] enum123_0;

	private Enum123[] enum123_1;

	private float float_0;

	private Enum125 enum125_0;

	private Enum126 enum126_0;

	private bool bool_0;

	private bool bool_1;

	private Enum124 enum124_0;

	private bool bool_2;

	private string string_2;

	private string string_3;

	private static readonly Class1151 class1151_0 = new Class1151("auto", "bCtr", "bL", "bR", "ctr", "midL", "midR", "tCtr", "tL", "tR", "radial");

	public string SourceNode => string_0;

	public string DestionationNode => string_1;

	public Enum124 Dimension => enum124_0;

	public Enum123[] BeginningPoints => enum123_0;

	public Enum123[] EndPoints => enum123_1;

	public Enum125 Routing => enum125_0;

	public float ShaftThickness
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public Enum126 BendPoint => enum126_0;

	public bool HasBeginningArrowhead => bool_0;

	public bool HasEndingArrowhead => bool_1;

	public Class106(Class2146 algorithm)
	{
		bool_0 = false;
		bool_1 = true;
		enum124_0 = Enum124.const_1;
		enum123_0 = new Enum123[4]
		{
			Enum123.const_1,
			Enum123.const_5,
			Enum123.const_6,
			Enum123.const_7
		};
		enum123_1 = new Enum123[4]
		{
			Enum123.const_1,
			Enum123.const_5,
			Enum123.const_6,
			Enum123.const_7
		};
		enum125_0 = Enum125.const_0;
		Class2177[] paramList = algorithm.ParamList;
		foreach (Class2177 @class in paramList)
		{
			if (@class.Type == Enum304.const_44)
			{
				string_0 = @class.Val;
			}
			else if (@class.Type == Enum304.const_14)
			{
				string_1 = @class.Val;
			}
			else if (@class.Type == Enum304.const_3)
			{
				enum123_0 = method_3(@class.Val).ToArray();
			}
			else if (@class.Type == Enum304.const_15)
			{
				enum123_1 = method_3(@class.Val).ToArray();
			}
			else if (@class.Type == Enum304.const_10)
			{
				enum125_0 = method_4(@class.Val);
			}
			else if (@class.Type == Enum304.const_4)
			{
				bool_0 = method_0(@class.Val);
			}
			else if (@class.Type == Enum304.const_16)
			{
				bool_1 = method_0(@class.Val);
			}
			else if (@class.Type == Enum304.const_13)
			{
				enum124_0 = method_1(@class.Val);
			}
			else if (@class.Type == Enum304.const_0)
			{
				bool_2 = Convert.ToBoolean(@class.Val);
			}
			else if (@class.Type == Enum304.const_21)
			{
				string_2 = @class.Val;
			}
			else if (@class.Type == Enum304.const_54)
			{
				string_3 = @class.Val;
			}
			else if (@class.Type == Enum304.const_5)
			{
				enum126_0 = method_2(@class.Val);
			}
		}
	}

	private bool method_0(string value)
	{
		return value == "arr";
	}

	private Enum124 method_1(string value)
	{
		return value switch
		{
			"1D" => Enum124.const_0, 
			"2D" => Enum124.const_1, 
			"custom" => Enum124.const_2, 
			_ => Enum124.const_1, 
		};
	}

	private Enum126 method_2(string value)
	{
		if (value == "beg")
		{
			return Enum126.const_1;
		}
		if (value == "end")
		{
			return Enum126.const_2;
		}
		return Enum126.const_0;
	}

	private List<Enum123> method_3(string value)
	{
		List<Enum123> list = new List<Enum123>();
		string[] array = value.Replace(',', ' ').Split(' ');
		for (int i = 0; i < array.Length; i++)
		{
			string name = array[i].Trim();
			if (class1151_0.Contains(name))
			{
				list.Add((Enum123)class1151_0[name]);
			}
		}
		if (list.Count == 0)
		{
			list.Add(Enum123.const_0);
		}
		return list;
	}

	private Enum125 method_4(string value)
	{
		return value switch
		{
			"bend" => Enum125.const_1, 
			"curve" => Enum125.const_2, 
			"longCurve" => Enum125.const_3, 
			_ => Enum125.const_0, 
		};
	}
}
