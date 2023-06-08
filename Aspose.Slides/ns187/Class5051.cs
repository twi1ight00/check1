using ns171;

namespace ns187;

internal class Class5051 : Class5024
{
	internal class Class5086 : Class5052
	{
		public Class5086(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5051)
			{
				return p;
			}
			return new Class5051(method_0());
		}
	}

	public Class5051(int propId)
	{
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override bool Equals(object obj)
	{
		return true;
	}
}
