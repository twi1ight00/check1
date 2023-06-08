using System.Collections;
using ns173;
using ns182;
using ns184;

namespace ns181;

internal class Class4949 : Class4948, Interface160
{
	private bool bool_1;

	private string string_0;

	private string string_1;

	private bool bool_2;

	public static bool bool_3 = true;

	public static bool bool_4 = false;

	private Class5729 class5729_0;

	public Class4949(string id, Class5729 f)
		: this(id, f, bool_3)
	{
	}

	public Class4949(string id, Class5729 f, bool type)
	{
		string_0 = id;
		class5729_0 = f;
		string_1 = "?";
		bool_2 = type;
	}

	public string[] imethod_3()
	{
		return new string[1] { string_0 };
	}

	public override string vmethod_10()
	{
		return string_1;
	}

	public void imethod_4(string id, ArrayList pages)
	{
		if (!bool_1 && string_0.Equals(id) && pages != null)
		{
			bool_1 = true;
			int index = ((!bool_2) ? (pages.Count - 1) : 0);
			Class4974 @class = (Class4974)pages[index];
			method_60();
			string_1 = @class.method_15();
			method_62(string_1, 0, method_18());
			if (class5729_0 != null)
			{
				method_47(class5729_0.method_18(string_1) - method_12());
				class5729_0 = null;
			}
		}
	}

	public bool imethod_2()
	{
		return bool_1;
	}

	public override bool vmethod_5(double variationFactor, int lineStretch, int lineShrink)
	{
		return true;
	}

	public override ArrayList vmethod_8(ArrayList runs)
	{
		runs.Add(new Class5742(this, new int[1] { method_18() }));
		return runs;
	}
}
