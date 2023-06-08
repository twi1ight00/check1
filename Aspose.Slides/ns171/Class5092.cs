using ns178;

namespace ns171;

internal class Class5092 : Class5089
{
	internal class Class5190 : Class5180.Class5185
	{
		private string string_0;

		public Class5190(string ns)
		{
			string_0 = ns;
		}

		public override Class5088 vmethod_0(Class5088 parent)
		{
			return new Class5092(parent, string_0);
		}
	}

	private string string_3;

	protected Class5092(Class5088 parent, string space)
		: base(parent)
	{
		string_3 = space;
	}

	public override string vmethod_23()
	{
		return string_3;
	}

	public override string vmethod_22()
	{
		return null;
	}

	internal override void vmethod_12(Class5088 child)
	{
		if (xmlDocument_0 == null)
		{
			method_29();
		}
		base.vmethod_12(child);
	}

	internal override void vmethod_9(char[] data, int start, int length, Class5634 pList, Interface243 locatoR)
	{
		if (xmlDocument_0 == null)
		{
			method_29();
		}
		base.vmethod_9(data, start, length, pList, locatoR);
	}
}
