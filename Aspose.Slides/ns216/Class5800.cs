using System;
using ns215;
using ns224;

namespace ns216;

internal class Class5800 : Class5783
{
	internal static string Tag => "color";

	internal string Value => (string)method_5("value").Value;

	public Class5800()
	{
		Class5906.smethod_4(this, "cSpace", "SRGB");
		Class5906.smethod_4(this, "value", string.Empty);
		Class5906.smethod_4(this, "use", string.Empty);
		Class5906.smethod_4(this, "usehref", string.Empty);
	}

	internal override void vmethod_4(Class5911 visitor)
	{
		visitor.vmethod_35(this);
		base.vmethod_4(visitor);
		visitor.vmethod_36(this);
	}

	internal override string[] vmethod_10()
	{
		return new string[1] { Class5816.Tag };
	}

	internal override Class5782 vmethod_7()
	{
		return new Class5800();
	}

	internal Class5998 method_8()
	{
		try
		{
			string[] array = Value.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			return new Class5998(int.Parse(array[0]), int.Parse(array[1]), int.Parse(array[2]));
		}
		catch (Exception)
		{
			return Class5998.class5998_7;
		}
	}

	internal override string vmethod_8()
	{
		return Tag;
	}

	internal bool method_9()
	{
		return ((string)method_5("cSpace").Value).ToUpper() == "SRGB";
	}
}
