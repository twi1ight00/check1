using System.Drawing;
using ns171;
using ns175;
using ns195;

namespace ns187;

internal class Class5040 : Class5024
{
	internal class Class5073 : Class5052
	{
		public Class5073(int propId)
			: base(propId)
		{
		}

		public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			if (p is Class5040)
			{
				return p;
			}
			Class5738 foUserAgent = ((fo == null) ? propertyList.method_0() : fo)?.method_2();
			Color value = p.vmethod_1(foUserAgent);
			if (!value.IsEmpty)
			{
				return new Class5040(value);
			}
			return vmethod_12(p, propertyList, fo);
		}
	}

	private static Class5749 class5749_0 = new Class5749();

	protected Color color_0;

	public static Class5040 smethod_0(Class5738 foUserAgent, string value)
	{
		Class5040 obj = new Class5040(Class5713.smethod_0(foUserAgent, value));
		return (Class5040)class5749_0.method_0(obj);
	}

	private Class5040(Color value)
	{
		color_0 = value;
	}

	public override Color vmethod_1(Class5738 foUserAgent)
	{
		return color_0;
	}

	public override string ToString()
	{
		return Class5713.smethod_10(color_0);
	}

	public Class5040 method_3()
	{
		return this;
	}

	public override object vmethod_12()
	{
		return this;
	}

	public override int GetHashCode()
	{
		return color_0.GetHashCode();
	}
}
