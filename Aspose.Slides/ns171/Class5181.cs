using System.Collections;

namespace ns171;

internal class Class5181 : Class5180
{
	private class Class5186 : Class5185
	{
		public override Class5088 vmethod_0(Class5088 parent)
		{
			return new Class5090(parent);
		}
	}

	private class Class5187 : Class5185
	{
		public override Class5088 vmethod_0(Class5088 parent)
		{
			return new Class5091(parent);
		}
	}

	public static string string_2 = "http://www.w3.org/2000/svg";

	public Class5181()
	{
		string_1 = string_2;
	}

	protected override void vmethod_2()
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
			hashtable_0.Add("svg", new Class5187());
			hashtable_0.Add(Class5180.string_0, new Class5186());
		}
	}

	public override string vmethod_0()
	{
		return "svg";
	}
}
