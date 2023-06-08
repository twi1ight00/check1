using ns215;

namespace ns216;

internal class Class5832 : Class5783
{
	internal static string Tag => "occur";

	public int Max
	{
		get
		{
			return (int)method_5("max").Value;
		}
		set
		{
			method_5("max").Value = value;
		}
	}

	public Class5832()
	{
		Class5906.smethod_2(this, "initial", 1);
		Class5906.smethod_2(this, "max", 1);
		Class5906.smethod_2(this, "min", 1);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_114(this);
		base.vmethod_4(visitor);
		visitor.vmethod_115(this);
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5832();
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5816.Tag };
	}
}
