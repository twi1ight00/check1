using System.Drawing;
using ns175;
using ns187;
using ns195;

namespace ns186;

internal class Class5047 : Class5024
{
	private string string_1;

	public Class5047(string ncName)
	{
		string_1 = ncName;
	}

	public override Color vmethod_1(Class5738 foUserAgent)
	{
		try
		{
			return Class5713.smethod_0(foUserAgent, string_1);
		}
		catch (Exception55)
		{
			return Color.Empty;
		}
	}

	public override string vmethod_13()
	{
		return string_1;
	}

	public override object vmethod_12()
	{
		return string_1;
	}

	public override string vmethod_11()
	{
		return string_1;
	}

	public override int GetHashCode()
	{
		return Class5721.smethod_1(string_1);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (!(obj is Class5047))
		{
			return false;
		}
		Class5047 @class = (Class5047)obj;
		return Class5721.smethod_0(string_1, @class.string_1);
	}
}
